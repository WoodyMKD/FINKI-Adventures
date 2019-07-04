using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Constants.LEVELS currentLevel { get; set; }

        public Scene(Panel Map)
        {
            // Initialize visual object variables
            this.player = new Player();
            this.activeBullets = new List<Bullet>();
            this.enemies = new List<Enemy>();

            // Initialize the starting game state
            this.Map = Map;
            changeLevel(Constants.LEVELS.KAMPUS_DVOR);

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

        public void changeLevel(Constants.LEVELS level)
        {
            if(level == Constants.LEVELS.KAMPUS_DVOR)
            {
                GameSettings.mapHasWalls = false;
                GameSettings.wallBounds = 0;
                this.Map.BackgroundImage = Properties.Resources.kampus_dvor;
                this.currentLevel = Constants.LEVELS.KAMPUS_DVOR;
            } else if(level == Constants.LEVELS.BARAKI_VLEZ)
            {
                GameSettings.mapHasWalls = true;
                GameSettings.wallBounds = 150;
                this.Map.BackgroundImage = Properties.Resources.baraki_vlez;
                this.currentLevel = Constants.LEVELS.BARAKI_VLEZ;
            }
            else if(level == Constants.LEVELS.VP_ISPIT)
            {

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

        public void createEnemies()
        {
            if (GameSettings.mapUpperBoundY > 0)
            {
                int enemyCount = 0;
                if (currentLevel == Constants.LEVELS.KAMPUS_DVOR) enemyCount = 2;
                else if (currentLevel == Constants.LEVELS.BARAKI_VLEZ) enemyCount = 3;
                else if (currentLevel == Constants.LEVELS.VP_ISPIT) enemyCount = 4;
                
                if (enemies.Count < enemyCount)
                {
                    int randomX = Constants.randomGenerator.Next(0, 1280);
                    int type = Constants.randomGenerator.Next(0, 2);

                    if (type == 0)
                    {
                        this.enemies.Add(new Book(randomX, GameSettings.mapUpperBoundY - 100));
                    }
                    else
                    {
                        this.enemies.Add(new Paper(randomX, GameSettings.mapUpperBoundY - 100));
                    }
                }
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

                foreach (Enemy enemy in enemies)
                {
                    if(bullet.hasCollided(enemy))
                    {
                        bullet.RemoveMark = true;
                        enemy.IsDead = true;
                        player.Score += enemy.Reward;
                    }
                }
            }
        }

        public void moveEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Move(player);
                if(enemy.hasCollided(player))
                {
                    enemy.IsDead = true;
                    player.Health -= enemy.Damage;
                }
            }
        }

        public bool playerAtEnd()
        {
            if(currentLevel == Constants.LEVELS.KAMPUS_DVOR)
            {
                if ((player.PositionX >= 0 && player.PositionX <= 10) &&
                    (player.PositionY > 260 && player.PositionY < 540))
                {
                    return true;
                }
            }
            else if (currentLevel == Constants.LEVELS.BARAKI_VLEZ)
            {
                if ((player.PositionX >= 150 && player.PositionX <= 160) &&
                    (player.PositionY > 280 && player.PositionY < 415))
                {
                    return true;
                }
            }

            return false;
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
            changeLevel(currentLevel);
            Map.Location = new Point(0, -780);
            player.resetPosition();

            enemies.Clear();
            player.Health = 100;
            player.Score = 0;

            GameSettings.mapLowerBoundY = 1500;
            GameSettings.mapUpperBoundY = 780;
        }

        public void MovePlayer()
        {
            player.Move();
        }
    }
}
