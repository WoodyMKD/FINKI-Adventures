using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINKI_Adventures
{
    public class Scene
    {
        // Visual Objects
        public Player player { get; }
        public List<Bullet> activeBullets { get; }
        public List<Enemy> enemies { get; }

        // Current Game State
        private Panel Map { get; set; }
        private Bitmap currentMap { get; set; }
        public Constants.LEVELS currentLevel { get; set; }

        public Scene(Panel Map)
        {
            // Initialize visual object variables
            player = new Player();
            activeBullets = new List<Bullet>();
            enemies = new List<Enemy>();

            // Initialize the starting game state
            this.Map = Map;
            this.currentMap = Properties.Resources.kampus_dvor;
            this.currentLevel = Constants.LEVELS.KAMPUS_DVOR;
            this.Map.BackgroundImage = currentMap;

            // Update settings
            GameSettings.mapLowerBoundY = 1500; // Helper variable to track the map
            GameSettings.mapUpperBoundY = 780; // Helper variable to track the map
        }

        public void Draw(Graphics g)
        {
            // Draw the player
            player.Animate(g);
            
            // Draw the active bullets 
            foreach (Bullet bullet in activeBullets)
            {
                bullet.Animate(g);
            }

            // Draw active enemies
            foreach (Enemy enemy in enemies)
            {
                enemy.Animate(g);
            }
        }

        public void createBullet(Player player)
        {
            Bullet firedBullet = new Bullet(player.Direction, player);

            if (player.Direction == Constants.DIRECTIONS.LEFT)
            {
                firedBullet.PositionX -= 120;
                firedBullet.PositionY -= 52;
            }

            if (player.Direction == Constants.DIRECTIONS.RIGHT)
            {
                firedBullet.PositionX += 15;
                firedBullet.PositionY -= 50;
            }

            if (player.Direction == Constants.DIRECTIONS.UP)
            {
                firedBullet.PositionX -= 52;
                firedBullet.PositionY -= 120;
            }

            if (player.Direction == Constants.DIRECTIONS.DOWN)
            {
                firedBullet.PositionX -= 50;
                firedBullet.PositionY += 15;
            }

            this.activeBullets.Add(firedBullet);
        }

        public void createEnemies(Player player)
        {
            Book book = new Book();
            Paper paper = new Paper();

            if (player.PositionY > 500)
            {
                this.enemies.Add(book);
            }

            if (player.PositionY > 900)
            {
                this.enemies.Add(paper);
            }
        }

        public void moveBullets()
        {
            foreach (Bullet bullet in activeBullets)
            {
                bullet.Move();

                if (!bullet.isInsideMap()) { 
                    bullet.RemoveMark = true;
                }
            }
        }

        public void moveEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Move(player);
                enemy.IsDead = enemy.hasCollided(player);
                player.Score += enemy.Reward;
                foreach(Bullet bullet in activeBullets)
                {
                    enemy.IsDead = bullet.RemoveMark = enemy.hasCollided(bullet);
                }
            }
        }

        public void moveMap()
        {
            if (Map.Location.Y <= 0) // if it didn't reach the end
            {
                // Move the map by 2 px vertically
                Map.Location = new Point(Map.Location.X, Map.Location.Y + 2);
                GameSettings.mapLowerBoundY -= 2;
                GameSettings.mapUpperBoundY -= 2;
            }
        }

        public void resetLevel()
        {
            Map.BackgroundImage = currentMap;
            Map.Location = new Point(0, -780);
            player.resetPosition();

            GameSettings.mapLowerBoundY = 1500;
            GameSettings.mapUpperBoundY = 780;
        }

        public void MovePlayer(Constants.DIRECTIONS direction)
        {
            player.Move(direction);
        }
    }
}
