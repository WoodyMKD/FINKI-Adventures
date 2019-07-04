using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace FINKI_Adventures
{
    public partial class GameView : UserControl
    {
        // Variables for the parent form and the game scene
        public GameForm gameForm { get; set; }
        public Scene gameScene { get; set; }

        // Scene Options
        public int bossTick = 0; // animation tick in order to use it with the main timer
        public int fireTick = 0; // animation tick in order to use it with the main timer
        public bool canFire = true;
        public static Timer sceneTimer; // main game timer
        public bool isInGame = false; // variable for checking whether the player is playing or is in the pause menu
        public bool movingKeyPressed = false;

        public GameView(GameForm gameForm)
        {
            // Form settings
            InitializeComponent();
            this.DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, sceneControl, new object[] { true });

            // Scene setup
            this.gameForm = gameForm;
            AllAnimations.InitializeAnimations();
            this.gameScene = new Scene(sceneControl);
            menuPanel.Location = new Point(0, GameSettings.mapUpperBoundY); // Adjust the location of the menu

            // Main timer initialization
            sceneTimer = new Timer();
            sceneTimer.Tick += new EventHandler(sceneTimer_Tick);
            sceneTimer.Interval = 50;
            sceneTimer.Start();
            sceneTimer.Enabled = true;
        }

        private void GameView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        { 
            // Escape is pressed
            if (e.KeyCode == Keys.Escape)
            {
                if(isInGame)
                {
                    openMenu();
                } 
                else
                {
                    if(btn_continue.Enabled) closeMenu();
                }
            }

            if(isInGame)
            {
                // Left Arrow Key is pressed
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    gameScene.player.Direction = Constants.DIRECTIONS.LEFT;
                    if (gameScene.player.Direction != Constants.DIRECTIONS.LEFT) gameScene.MovePlayer();
                    movingKeyPressed = true;
                }

                // Right Arrow Key is pressed
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    gameScene.player.Direction = Constants.DIRECTIONS.RIGHT;
                    if (gameScene.player.Direction != Constants.DIRECTIONS.RIGHT) gameScene.MovePlayer();
                    movingKeyPressed = true;
                }

                // Up Arrow Key is pressed
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    gameScene.player.Direction = Constants.DIRECTIONS.UP;
                    if (gameScene.player.Direction != Constants.DIRECTIONS.UP) gameScene.MovePlayer();
                    movingKeyPressed = true;
                }

                // Down Arrow Key is pressed
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    gameScene.player.Direction = Constants.DIRECTIONS.DOWN;
                    if (gameScene.player.Direction != Constants.DIRECTIONS.DOWN) gameScene.MovePlayer();
                    movingKeyPressed = true;
                }

                // Space Key is pressed
                if (e.KeyCode == Keys.Space)
                {
                    if (canFire)
                    {
                        gameScene.createBullet(gameScene.player);
                        canFire = false;
                        fireTick = 5;
                    }
                }

                // Tab Key is pressed
                if (e.KeyCode == Keys.Tab)
                {
                    GameSettings.showHitBoxes = !GameSettings.showHitBoxes;
                }
            }
        }

        void sceneTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();

            if(isInGame)
            {
                btn_continue.Enabled = true;
                btn_continue.BackgroundImage = Properties.Resources.btn_continue;

                gameScene.moveMap(); // Scroll the map vertically]

                gameScene.moveBullets(); // Move current bullets on map
                gameScene.moveEnemies(); // Move the enemies if they are created
                gameScene.createEnemies();

                if(!canFire)
                {
                    fireTick -= 1;
                    if(fireTick <= 0)
                    {
                        canFire = true;
                    }
                }

                if(gameScene.currentLevel == Constants.LEVELS.ISPIT)
                {
                    bossTick++;
                    if (bossTick >= 40)
                    {
                        bossTick = 0;
                        gameScene.gameBoss.targetLocation = Constants.BossTargetLocations[Constants.randomGenerator.Next(4)];
                        gameScene.createBossKids();
                    }
                    if(bossTick % 10 == 0)
                    {
                        gameScene.gameBoss.Animation.nextImage();
                    }

                    if (gameScene.gameBoss.IsDead)
                    {
                        gameScene.restartGame();
                        openMenu();
                        MessageBox.Show("Колега, успешно го положивте испитот!");
                    }
                }

                // Iterate through animation sprites
                AllAnimations.nextImage();

                if(movingKeyPressed)
                {
                    gameScene.MovePlayer();
                    if(gameScene.enemies.Count == 0 && gameScene.playerAtEnd())
                    {
                        gameScene.changeLevel(gameScene.currentLevel + 1);
                    }
                }

                // If the map has "eaten" the player or the player died
                if (gameScene.player.PositionY > GameSettings.mapLowerBoundY || gameScene.player.Health <= 0)
                {
                    btn_continue.Enabled = false;
                    btn_continue.BackgroundImage = Properties.Resources.btn_ProdolziDisabled;
                    gameScene.restartGame();
                    openMenu();
                    MessageBox.Show("Жалам колега, не успеавте да го положивте испитот!");
                }

                //Collision detection removal of enemies
                gameScene.enemies.RemoveAll(enemy => enemy.IsDead);
                gameScene.activeBullets.RemoveAll(b => b.RemoveMark && b.Animation.isAnimFinished());
            }
        }

        private void btn_newgame_Click(object sender, EventArgs e)
        {
            btn_continue.Enabled = false;
            btn_continue.BackgroundImage = Properties.Resources.btn_ProdolziDisabled;
            gameScene.restartGame();
            closeMenu();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            closeMenu();
        }

        public void openMenu()
        {
            Cursor.Show();
            isInGame = false;
            menuPanel.Location = new Point(0, GameSettings.mapUpperBoundY); // Adjust the location of the menu
            menuPanel.Show();
        }

        public void closeMenu()
        {
            Cursor.Hide();
            isInGame = true;
            menuPanel.Hide();
        }

        private void sceneControl_Paint(object sender, PaintEventArgs e)
        {
            // Repaint the main game panel (scene)
            Graphics g = e.Graphics;
            gameScene.Draw(g);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            String s = "(";
            for(int i=0; i<fireTick; i++)
            {
                s += "-";
            }
            s += ")";
            if (fireTick == 0) s = "";
            g.DrawString(s, new Font("Arial", 15), new SolidBrush(Color.DarkMagenta),
                new Point(gameScene.player.PositionX, gameScene.player.PositionY + gameScene.player.Height/2 + 10), sf);
        }

        private void btn_Iskluci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GameView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W ||
                e.KeyCode == Keys.Down || e.KeyCode == Keys.S ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.A ||
                e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                movingKeyPressed = false;
                gameScene.player.updateAnimation();
            }
        }
    }
}
