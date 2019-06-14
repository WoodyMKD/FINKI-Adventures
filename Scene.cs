using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINKI_Adventures
{

    enum Level
    {
        Kampus_Dvor = 1,
        Baraki = 2
    }

    class Scene
    {
        public Level currentLevel { get; set; }
        public Player player { get; }

        private Panel Map;
        private Bitmap currentMap = null;

        public int mapBottomY = 1480;

        public Scene(Panel Map)
        {
            this.Map = Map;
            player = new Player();

            currentMap = Properties.Resources.kampus_dvor;
            currentLevel = Level.Kampus_Dvor;
            Map.BackgroundImage = currentMap;
        }

        public void Draw(Graphics g)
        {
            player.Animate(g);
        }

        public void moveMap()
        {
            if(Map.Location.Y <= -10)
            {
                Map.Location = new Point(Map.Location.X, Map.Location.Y + 2);
                mapBottomY -= 2;
            }
        }

        public void resetLevel()
        {
            Map.BackgroundImage = currentMap;
            Map.Location = new Point(0, -780);
            player.resetPosition();
            mapBottomY = 1480;
        }

        public void MovePlayerLeft()
        {
            if(player.X > 5)
            {
                player.MoveLeft();
            }
        }

        public void MovePlayerUp()
        {
            if(player.Y > mapBottomY - 720)
            {
                player.MoveUp();
            }
        }

        public void MovePlayerDown()
        {
            player.MoveDown();
        }

        public void MovePlayerRight()
        {
            if (player.X < 1190)
            {
                player.MoveRight();
            }
        }
    }
}
