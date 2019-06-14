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
        public GameForm()
        {
            InitializeComponent();

            levelPanel.Size = new Size(1280, 50);
            helpPanel.Size = new Size(1280, 50);
            gamePanel.Size = new Size(1280, 720);

            levelPanel.Location = new Point(
                this.ClientSize.Width / 2 - gamePanel.Size.Width / 2,
                this.ClientSize.Height / 2 - gamePanel.Size.Height / 2 - 50);


            helpPanel.Location = new Point(
                this.ClientSize.Width / 2 - gamePanel.Size.Width / 2,
                this.ClientSize.Height / 2 - gamePanel.Size.Height / 2 + 720);


            gamePanel.Location = new Point(
                this.ClientSize.Width / 2 - gamePanel.Size.Width / 2,
                this.ClientSize.Height / 2 - gamePanel.Size.Height / 2);


            GameView myForm = new GameView(this);
            myForm.BackColor = Color.Black;
            gamePanel.Controls.Add(myForm);
            myForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
