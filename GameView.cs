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
        GameForm gameForm = null;
        Scene gameScene = null;
        int animationTick = 2;
        static public Timer sceneTimer;
        bool isInGame = false;

        public GameView(GameForm gameForm)
        {
            InitializeComponent();

            // Trick for doubleBuffering panel
            SetStyle(ControlStyles.DoubleBuffer, true);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, sceneControl, new object[] { true });

            this.gameForm = gameForm;
            AllAnimations.InitializeAnimations();
            this.gameScene = new Scene(sceneControl);
            
            menuPanel.Location = new Point(0, gameScene.mapBottomY - 700); // Adjust the location of the menu

            // Main timer for the game
            sceneTimer = new Timer();
            sceneTimer.Tick += new EventHandler(sceneTimer_Tick);
            sceneTimer.Interval = 50;
            sceneTimer.Start();
            sceneTimer.Enabled = true;
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
                    gameScene.MovePlayerLeft();
                }

                // Right Arrow Key is pressed
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    gameScene.MovePlayerRight();
                }

                // Up Arrow Key is pressed
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    gameScene.MovePlayerUp();
                }

                // Down Arrow Key is pressed
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    gameScene.MovePlayerDown();
                }

                if (e.KeyCode == Keys.Space)
                {
                    gameScene.createBullet(gameScene.player);
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

                // Iterate through animation sprites
                if (--animationTick <= 0)
                {
                    AllAnimations.nextImage();
                    animationTick = 2;
                }

                // If the map has "eaten" the player
                if (gameScene.player.Y > gameScene.mapBottomY - 10)
                {
                    gameScene.resetLevel();
                    openMenu();
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
            menuPanel.Location = new Point(0, gameScene.mapBottomY - 700); // Adjust the location of the menu
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
