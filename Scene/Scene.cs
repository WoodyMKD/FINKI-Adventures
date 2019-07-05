using FINKI_Adventures.Models.EnemyModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace FINKI_Adventures
{
    public class Scene
    {
        // Visual Objects
        public Player player { get; }
        public List<Bullet> activeBullets { get; }
        public List<Enemy> enemies { get; }
        public Boss gameBoss { get; set; }

        SoundPlayer enemyDead;

        // Current Game State
        private PictureBox Map { get; set; }
        public Constants.LEVELS currentLevel { get; set; }

        public Scene(PictureBox Map)
        {
            // Initialize visual object variables
            this.player = new Player();
            this.activeBullets = new List<Bullet>();
            this.enemies = new List<Enemy>();
            
            Stream str = Properties.Resources.enemyDead;
            this.enemyDead = new SoundPlayer(str);

            // Initialize the starting game state
            this.Map = Map;
            changeLevel(Constants.LEVELS.BARAKI_VLEZ);
        }

        public void Draw(Graphics g)
        {
            // Draw the player
            player.Animate(g);

            if(currentLevel == Constants.LEVELS.ISPIT)
            {
                gameBoss.Animate(g);
            }
            
            // Draw the active bullets 
            foreach (Bullet bullet in activeBullets)
            {
                bullet.Animate(g);
            }

            // Draw active enemies
            foreach (Enemy enemy in enemies)
            {
                enemy.Animate(g);
                enemy.showHealth(g);
            }
        }

        public void changeLevel(Constants.LEVELS level)
        {
            enemies.Clear();
            activeBullets.Clear();

            if (level == Constants.LEVELS.KAMPUS_DVOR)
            {
                GameSettings.mapHasWalls = false;
                GameSettings.wallBounds = 0;
                Map.Location = new Point(0, -780);
                GameSettings.mapLowerBoundY = 1500;
                GameSettings.mapUpperBoundY = 780;
                this.Map.BackgroundImage = Properties.Resources.kampus_dvor;
                this.currentLevel = Constants.LEVELS.KAMPUS_DVOR;
            }
            else if(level == Constants.LEVELS.BARAKI_VLEZ)
            {
                GameSettings.mapHasWalls = true;
                GameSettings.wallBounds = 150;
                Map.Location = new Point(0, -780);
                GameSettings.mapLowerBoundY = 1500;
                GameSettings.mapUpperBoundY = 780;
                this.Map.BackgroundImage = Properties.Resources.baraki_vlez;
                this.currentLevel = Constants.LEVELS.BARAKI_VLEZ;
            }
            else if(level == Constants.LEVELS.ISPIT)
            {
                GameSettings.mapHasWalls = true;
                GameSettings.wallBounds = 150;
                Map.Location = new Point(0, 0);
                GameSettings.mapLowerBoundY = 720;
                GameSettings.mapUpperBoundY = 0;
                this.Map.BackgroundImage = Properties.Resources.B22;
                this.currentLevel = Constants.LEVELS.ISPIT;
                
                gameBoss = new Boss(Constants.BossTargetLocations[0].X, Constants.BossTargetLocations[0].Y);
                gameBoss.targetLocation = Constants.BossTargetLocations[0];
                this.enemies.Add(gameBoss);
            }

            player.resetPosition(currentLevel);
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
                
                if (currentLevel != Constants.LEVELS.ISPIT && enemies.Count < enemyCount)
                {
                    int locationX = Constants.randomGenerator.Next(0, 1280);
                    int locationY = GameSettings.mapUpperBoundY - 100;
                    int type = Constants.randomGenerator.Next(0, 2);

                    if (type == 0)
                    {
                        this.enemies.Add(new Book(locationX, locationY));
                    }
                    else
                    {
                        this.enemies.Add(new Paper(locationX, locationY));
                    }
                }
            }
        }

        public void createBossKids()
        {
            int locationX = (int)gameBoss.PositionX;
            int locationY = (int)gameBoss.PositionY;
            int type = Constants.randomGenerator.Next(0, 2);

            if (type == 0)
            {
                this.enemies.Add(new Book(locationX, locationY));
            }
            else
            {
                this.enemies.Add(new Paper(locationX, locationY));
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
                        enemy.Health -= 10;
                        if (enemy.Health <= 0)
                        {
                            enemy.IsDead = true;
                            player.Score += enemy.Reward;

                            enemyDead.Play();
                        }
                        bullet.RemoveMark = true;
                    }
                }
            }
        }

        public void moveEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Move(player);
                if (enemy.hasCollided(player))
                {
                    if (!(enemy is Boss))
                    { 
                        enemy.IsDead = true;
                        player.Health -= enemy.Damage;
                    }
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

        public void restartGame()
        {
            changeLevel(Constants.LEVELS.KAMPUS_DVOR);
            Map.Location = new Point(0, -780);
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
