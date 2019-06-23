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
        Baraki = 2,
        VP_Ispit = 3
    }

    class Scene
    {
        public Level currentLevel { get; set; }
        public Player player { get; }
        public List<Bullet> activeBullets { get; }
        public List<Enemy> enemies { get; }

        private Panel Map;
        private Bitmap currentMap = null;

        public int mapBottomY = 1480; // Helper variable to track the map

        public Scene(Panel Map)
        {
            this.Map = Map;
            player = new Player();
            activeBullets = new List<Bullet>();
            enemies = new List<Enemy>();

            // Initialize the first level
            currentMap = Properties.Resources.kampus_dvor;
            currentLevel = Level.Kampus_Dvor;
            Map.BackgroundImage = currentMap;
        }

        public void Draw(Graphics g)
        {
            // Draw the player
            player.Animate(g);

            //Console.WriteLine("ActiveBullets: " + activeBullets.Count);

            // Draw bullets
            foreach (Bullet bullet in activeBullets)
            {
                Console.WriteLine("Bullet " + bullet.Direction);
                bullet.Animate(g);
            }
            foreach (Enemy enemy in enemies)
            {
                enemy.Animate(g);
                Console.WriteLine("Moved enemy");
            }
        }

        public void createBullet(Player player)
        {
            Bullet firedBullet = new Bullet(player.Direction, player);
            if (player.Direction == "left")
            {
                firedBullet.X -= 45;
                firedBullet.Y -= 15;
            }
            if (player.Direction == "right")
            {
                firedBullet.X += 35;
                firedBullet.Y -= 10;
            }
            if (player.Direction == "up")
            {
                firedBullet.X -= 10;
                firedBullet.Y -= 45;
            }
            if (player.Direction == "down")
            {
                firedBullet.X -= 15;
                firedBullet.Y += 35;
            }

            this.activeBullets.Add(firedBullet);
            Console.WriteLine("Created");
        }
        public void createEnemies(Player player)
        {
            Book book = new Book();
            Paper paper = new Paper();
            if (player.Y > 500)
            {
                this.enemies.Add(book);
                Console.WriteLine("Created");
            }
            if (player.Y > 900)
            {
                this.enemies.Add(paper);
                Console.WriteLine("Created");
            }


            //Console.WriteLine("Created");
        }

        public void moveBullets()
        {
            foreach (Bullet bullet in activeBullets)
            {
                bullet.Move();
                bullet.remove = bullet.OutOfScene(Map.Top, Map.Bottom);//check map bounds
            }
        }
        public void moveEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Move(player);
                enemy.dead = enemy.remove = enemy.Collision(player);
                player.Score += enemy.Reward;
                foreach(Bullet bullet in activeBullets)
                {
                    enemy.dead = enemy.remove = bullet.remove = enemy.Collision(bullet);
                }
            }
        }

        public void moveMap()
        {
            if(Map.Location.Y <= -10) // if it didn't reach the end
            {
                // Move the map by 2 px vertically
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
