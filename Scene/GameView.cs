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
        public int animationTick = 2; // animation tick in order to use it with the main timer
        public static Timer sceneTimer; // main game timer
        public bool isInGame = false; // variable for checking whether the player is playing or is in the pause menu

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

            gameScene.createEnemies(gameScene.player);
        }

        private void GameView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // R is pressed
            if (e.KeyCode == Keys.R)
            {
                gameScene.resetLevel();
            }

            // Escape is pressed
            if (e.KeyCode == Keys.Escape)
            {
                if(isInGame)
                {
                    openMenu();
                } 
                else
                {
                    closeMenu();
                }
            }

            if(isInGame)
            {
                // Left Arrow Key is pressed
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    gameScene.MovePlayer(Constants.DIRECTIONS.LEFT);
                }

                // Right Arrow Key is pressed
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    gameScene.MovePlayer(Constants.DIRECTIONS.RIGHT);
                }

                // Up Arrow Key is pressed
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    gameScene.MovePlayer(Constants.DIRECTIONS.UP);
                }

                // Down Arrow Key is pressed
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    gameScene.MovePlayer(Constants.DIRECTIONS.DOWN);
                }

                // Space Key is pressed
                if (e.KeyCode == Keys.Space)
                {
                    gameScene.createBullet(gameScene.player);
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
                gameScene.moveMap(); // Scroll the map vertically
                gameScene.moveBullets(); // Move current bullets on map
                gameScene.moveEnemies(); // Move the enemies if they are created

                // Iterate through animation sprites
                if (--animationTick <= 0)
                {
                    AllAnimations.nextImage();
                    animationTick = 2;
                }

                // If the map has "eaten" the player
                if (gameScene.player.PositionY > GameSettings.mapLowerBoundY)
                {
                    gameScene.resetLevel();
                    openMenu();
                }

                //Collision detection removal of enemies
                for (int i=gameScene.enemies.Count-1;i>=0;i--)
                {
                    if(gameScene.enemies[i].IsDead)
                    {
                        gameScene.enemies.RemoveAt(i);
                    }
                }

                //Bullets removal
                for(int i = gameScene.activeBullets.Count-1; i >= 0; i--)
                {
                    if (gameScene.activeBullets[i].RemoveMark)
                    {
                        gameScene.activeBullets.RemoveAt(i);
                    }
                }
            }
        }

        private void btn_newgame_Click(object sender, EventArgs e)
        {
            gameScene.resetLevel();
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
        }
    }
}
