using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINKI_Adventures
{
    public partial class GameForm : Form
    {
        GameView gameView;

        public GameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            // Initialize panel sizes
            levelPanel.Size = new Size(1280, 50);
            helpPanel.Size = new Size(1280, 50);
            gamePanel.Size = new Size(1280, 720);

            // Adjust panel locations
            gamePanel.Location = new Point(
                this.ClientSize.Width / 2 - gamePanel.Size.Width / 2,
                this.ClientSize.Height / 2 - gamePanel.Size.Height / 2); // center of the screen

            levelPanel.Location = new Point(
                this.ClientSize.Width / 2 - gamePanel.Size.Width / 2,
                this.ClientSize.Height / 2 - gamePanel.Size.Height / 2 - 50); // 50 px over the gamePanel
            
            helpPanel.Location = new Point(
                this.ClientSize.Width / 2 - gamePanel.Size.Width / 2,
                this.ClientSize.Height / 2 - gamePanel.Size.Height / 2 + 720); // below the gamePanel

            // Initialize and show the User Control used as game view
            this.gameView = new GameView(this);
            gameView.BackColor = Color.Black;
            gamePanel.Controls.Add(gameView);
            gameView.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTimer_Tick(object sender, EventArgs e)
        {
            Constants.LEVELS currentLevel = gameView.gameScene.currentLevel;
            lblPointsHealth.Text = "Поени: " + gameView.gameScene.player.Score.ToString() + " | Здравје: " + gameView.gameScene.player.Health + "%";
            lblLevel.Text = "Ниво: ";

            if(currentLevel == Constants.LEVELS.KAMPUS_DVOR)
            {
                lblLevel.Text += "Кампус двор";
            }
            else if (currentLevel == Constants.LEVELS.BARAKI_VLEZ)
            {
                lblLevel.Text += "Бараки";
            }
            else if (currentLevel == Constants.LEVELS.VP_ISPIT)
            {
                lblLevel.Text += "Б2.2";
            }
        }
    }
}
