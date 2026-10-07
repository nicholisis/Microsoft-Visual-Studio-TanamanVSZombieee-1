namespace M3VP
{
    public partial class Form1 : Form
    {
        PictureBox[,] gridTiles = new PictureBox[5, 8];
        int totalSun = 150;
        Plant[,] activePlants = new Plant[5, 8];

        int timeLeft = 100;
        bool isGameOver = false;

        List<Plant> listPlants = new List<Plant>();
        List<Zombie> listZombies = new List<Zombie>();
        List<Bullet> listBullets = new List<Bullet>();
        List<SunItem> listSuns = new List<SunItem>();

        Color activeBg = Color.FromArgb(255, 221, 120);
        Color activeBorder = Color.FromArgb(217, 142, 48);

        Color defaultBg = Color.FromArgb(228, 242, 205);
        Color defaultBorder = Color.FromArgb(170, 205, 140);

        int zombieSpawnCooldown = 0;
        int naturalSunCooldown = 0;

        Random rand = new Random();


        string selectedPlant = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateGameGrid()
        {
            int start_x = panelEnd.Location.X + panelEnd.Width;
            int start_y = panelEnd.Location.Y;

            int tile_width = 90;
            int tile_height = 80;

            Color color1 = Color.FromArgb(154, 194, 102);
            Color color2 = Color.FromArgb(144, 184, 93);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PictureBox tile = new PictureBox();

                    tile.Size = new Size(tile_width, tile_height);
                    tile.Location = new Point(
                        start_x + j * tile_width,
                        start_y + i * tile_height
                    );

                    tile.BorderStyle = BorderStyle.FixedSingle;

                    if ((i + j) % 2 == 0)
                    {
                        tile.BackColor = color1;
                    }
                    else
                    {
                        tile.BackColor = color2;
                    }

                    tile.Click += Tile_Click;

                    gridTiles[i, j] = tile;
                    this.Controls.Add(tile);
                    tile.BringToFront();
                }
            }
        }

        private void ResetPlantButtons()
        {
            Button[] plantButtons = { btnSunflower, btnPeashooter, btnWallnut };

            foreach (Button btn in plantButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = defaultBg;
                btn.FlatAppearance.BorderColor = defaultBorder;
                btn.FlatAppearance.BorderSize = 1;
            }
        }

        private void TogglePlantButton(Button btn, string plantName)
        {
            if (selectedPlant == plantName)
            {
                selectedPlant = "";
                ResetPlantButtons();
            }
            else
            {
                ResetPlantButtons();

                selectedPlant = plantName;
                btn.BackColor = activeBg;
                btn.FlatAppearance.BorderColor = activeBorder;
                btn.FlatAppearance.BorderSize = 3;
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            PictureBox clickedTile = sender as PictureBox;
            if (clickedTile == null) return;

            int target_row = -1;
            int target_col = -1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gridTiles[i, j] == clickedTile)
                    {
                        target_row = i;
                        target_col = j;
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(selectedPlant))
            {
                MessageBox.Show("Pilih tanaman di menu samping terlebih dahulu!");
                return;
            }

            if (activePlants[target_row, target_col] != null)
            {
                MessageBox.Show("Petak ini sudah ada tanamannya!");
                return;
            }

            int cost = 0;
            int maxHp = 0;
            Image plantImg = null;

            if (selectedPlant == "SUNFLOWER")
            {
                cost = 50;
                maxHp = 160;
                plantImg = Properties.Resources.sunflower;
            }
            else if (selectedPlant == "PEASHOOTER")
            {
                cost = 100;
                maxHp = 160;
                plantImg = Properties.Resources.peashooter;
            }
            else if (selectedPlant == "WALLNUT")
            {
                cost = 75;
                maxHp = 200;
                plantImg = Properties.Resources.wallnut;
            }

            if (totalSun < cost)
            {
                MessageBox.Show("SUN tidak cukup!");
                return;
            }

            totalSun -= cost;
            lblSunCount.Text = "SUN\n" + totalSun.ToString();

            PictureBox plantPic = new PictureBox();
            plantPic.Size = new Size(60, 52);
            plantPic.Location = new Point(
                clickedTile.Location.X + 15,
                clickedTile.Location.Y + 4
            );
            plantPic.Image = plantImg;
            plantPic.SizeMode = PictureBoxSizeMode.Zoom;
            plantPic.BackColor = Color.FromArgb(124, 171, 85);

            Label plantHp = new Label();
            plantHp.AutoSize = false;
            plantHp.Size = new Size(60, 18);

            plantHp.Location = new Point(
                clickedTile.Location.X + 15,
                clickedTile.Location.Y + 58
            );

            plantHp.Text = maxHp + "/" + maxHp;
            plantHp.TextAlign = ContentAlignment.MiddleCenter;
            plantHp.ForeColor = Color.White;
            plantHp.BackColor = Color.FromArgb(48, 92, 51);
            plantHp.Font = new Font("Arial", 8, FontStyle.Bold);

            this.Controls.Add(plantPic);
            this.Controls.Add(plantHp);

            plantPic.BringToFront();
            plantHp.BringToFront();

            Plant newPlant = new Plant(plantPic, plantHp, selectedPlant, maxHp, target_row, target_col);
            activePlants[target_row, target_col] = newPlant;
            listPlants.Add(newPlant);

            selectedPlant = "";
            ResetPlantButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetPlantButtons();

            CreateGameGrid();

            lblSunCount.Text = "SUN\n" + totalSun.ToString();
            lblTime.Text = "TIME\n" + timeLeft + "s";

            SpawnNaturalSun();

            timerMain.Start();
            timerMove.Start();
        }

        private void btnSunflower_Click(object sender, EventArgs e)
        {
            TogglePlantButton(btnSunflower, "SUNFLOWER");
        }

        private void btnPeashooter_Click(object sender, EventArgs e)
        {
            TogglePlantButton(btnPeashooter, "PEASHOOTER");
        }

        private void btnWallnut_Click(object sender, EventArgs e)
        {
            TogglePlantButton(btnWallnut, "WALLNUT");
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            timeLeft--;
            lblTime.Text = "TIME\n" + timeLeft + "s";

            if (timeLeft <= 0)
            {
                EndGame(true);
                return;
            }

            int spawnInterval = 7;
            if (timeLeft <= 30) spawnInterval = 1;
            else if (timeLeft <= 60) spawnInterval = 3;

            zombieSpawnCooldown++;
            if (zombieSpawnCooldown >= spawnInterval)
            {
                SpawnZombie();
                zombieSpawnCooldown = 0;
            }

            naturalSunCooldown++;
            if (naturalSunCooldown >= 9)
            {
                SpawnNaturalSun();
                naturalSunCooldown = 0;
            }

            for (int i = 0; i < listPlants.Count; i++)
            {
                Plant p = listPlants[i];
                p.timerAction++;

                if (p.type == "SUNFLOWER" && p.timerAction >= 5)
                {
                    SpawnSunflowerSun(p);
                    p.timerAction = 0;
                }
                else if (p.type == "PEASHOOTER" && p.timerAction >= 1)
                {
                    if (IsZombieInRow(p.row))
                    {
                        SpawnBullet(p);
                    }
                    p.timerAction = 0;
                }
            }

            for (int i = listSuns.Count - 1; i >= 0; i--)
            {
                listSuns[i].lifeTime--;
                if (listSuns[i].lifeTime <= 0)
                {
                    this.Controls.Remove(listSuns[i].pic);
                    listSuns[i].pic.Dispose();
                    listSuns.RemoveAt(i);
                }
            }

            for (int i = 0; i < listZombies.Count; i++)
            {
                Zombie z = listZombies[i];
                if (z.isEating && z.targetPlant != null)
                {
                    z.targetPlant.currentHp -= 20;
                    if (z.targetPlant.currentHp < 0) z.targetPlant.currentHp = 0;
                    z.targetPlant.lblHp.Text = z.targetPlant.currentHp + "/" + z.targetPlant.maxHp;

                    if (z.targetPlant.currentHp <= 0)
                    {
                        this.Controls.Remove(z.targetPlant.pic);
                        this.Controls.Remove(z.targetPlant.lblHp);
                        z.targetPlant.pic.Dispose();
                        z.targetPlant.lblHp.Dispose();

                        activePlants[z.targetPlant.row, z.targetPlant.col] = null;
                        listPlants.Remove(z.targetPlant);

                        z.isEating = false;
                        z.targetPlant = null;
                    }
                }
            }
        }

        private void timerMove_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            for (int i = 0; i < listSuns.Count; i++)
            {
                if (listSuns[i].isFalling)
                {
                    if (listSuns[i].pic.Top < listSuns[i].targetY)
                    {
                        listSuns[i].pic.Top += 3;
                    }
                    else
                    {
                        listSuns[i].isFalling = false;
                    }
                }
            }

            for (int b = listBullets.Count - 1; b >= 0; b--)
            {
                Bullet bullet = listBullets[b];
                bullet.pic.Left += 10;

                bool hit = false;
                for (int z = listZombies.Count - 1; z >= 0; z--)
                {
                    Zombie zombie = listZombies[z];
                    if (bullet.row == zombie.row && bullet.pic.Bounds.IntersectsWith(zombie.pic.Bounds))
                    {
                        zombie.currentHp -= 20;
                        if (zombie.currentHp < 0) zombie.currentHp = 0;
                        zombie.lblHp.Text = zombie.currentHp + "/" + zombie.maxHp;

                        if (zombie.currentHp <= 0)
                        {
                            this.Controls.Remove(zombie.pic);
                            this.Controls.Remove(zombie.lblHp);
                            zombie.pic.Dispose();
                            zombie.lblHp.Dispose();
                            listZombies.RemoveAt(z);
                        }

                        hit = true;
                        break;
                    }
                }

                if (hit || bullet.pic.Left > panelStart.Right)
                {
                    this.Controls.Remove(bullet.pic);
                    bullet.pic.Dispose();
                    listBullets.RemoveAt(b);
                }
            }

            for (int i = 0; i < listZombies.Count; i++)
            {
                Zombie z = listZombies[i];

                if (z.pic.Left <= panelEnd.Location.X + panelEnd.Width)
                {
                    EndGame(false);
                    return;
                }

                if (z.isEating)
                {
                    if (z.targetPlant == null || z.targetPlant.currentHp <= 0)
                    {
                        z.isEating = false;
                        z.targetPlant = null;
                    }
                    continue;
                }

                Plant targetToEat = null;
                for (int p = 0; p < listPlants.Count; p++)
                {
                    Plant plant = listPlants[p];
                    if (z.row == plant.row)
                    {
                        if (z.pic.Left <= plant.pic.Right && z.pic.Right >= plant.pic.Left)
                        {
                            targetToEat = plant;
                            break;
                        }
                    }
                }

                if (targetToEat != null)
                {
                    z.isEating = true;
                    z.targetPlant = targetToEat;
                }
                else
                {
                    z.pic.Left -= 1;
                    z.lblHp.Left = z.pic.Left;
                }
            }
        }

        private bool IsZombieInRow(int row)
        {
            for (int i = 0; i < listZombies.Count; i++)
            {
                if (listZombies[i].row == row) return true;
            }
            return false;
        }

        private void SpawnZombie()
        {
            int randomRow = rand.Next(0, 5);
            int startY = panelEnd.Location.Y + (randomRow * 80);

            PictureBox picZombie = new PictureBox();
            picZombie.Size = new Size(60, 60);
            picZombie.Location = new Point(panelStart.Location.X + 10, startY + 5);
            picZombie.Image = Properties.Resources.zombie;
            picZombie.SizeMode = PictureBoxSizeMode.Zoom;
            picZombie.BackColor = Color.FromArgb(124, 171, 85);

            Label lblHp = new Label();
            lblHp.AutoSize = false;
            lblHp.Size = new Size(60, 16);
            lblHp.Location = new Point(picZombie.Left, startY + 62);
            lblHp.Text = "100/100";
            lblHp.ForeColor = Color.White;
            lblHp.TextAlign = ContentAlignment.MiddleCenter;
            lblHp.BackColor = Color.FromArgb(48, 92, 51);
            lblHp.Font = new Font("Arial", 7, FontStyle.Bold);

            this.Controls.Add(picZombie);
            this.Controls.Add(lblHp);
            picZombie.BringToFront();
            lblHp.BringToFront();

            listZombies.Add(new Zombie(picZombie, lblHp, randomRow));
        }

        private void SpawnBullet(Plant p)
        {
            PictureBox picBullet = new PictureBox();
            picBullet.Size = new Size(18, 18);
            picBullet.Location = new Point(p.pic.Right - 5, p.pic.Top + 14);
            picBullet.Image = Properties.Resources.pea;
            picBullet.SizeMode = PictureBoxSizeMode.Zoom;
            picBullet.BackColor = Color.FromArgb(124, 171, 85);

            this.Controls.Add(picBullet);
            picBullet.BringToFront();

            listBullets.Add(new Bullet(picBullet, p.row));
        }

        private void SpawnNaturalSun()
        {
            int minX = panelEnd.Location.X + panelEnd.Width + 20;
            int maxX = panelStart.Location.X - 60;
            int randX = rand.Next(minX, maxX);

            int targetY = rand.Next(panelEnd.Location.Y + 20, panelEnd.Location.Y + 300);

            PictureBox picSun = new PictureBox();
            picSun.Size = new Size(45, 45);

            picSun.Location = new Point(randX, panelEnd.Location.Y - 45);
            picSun.Image = Properties.Resources.sun;
            picSun.SizeMode = PictureBoxSizeMode.Zoom;
            picSun.BackColor = Color.FromArgb(124, 171, 85);
            picSun.Cursor = Cursors.Hand;
            picSun.Click += Sun_Click;

            this.Controls.Add(picSun);
            picSun.BringToFront();

            listSuns.Add(new SunItem(picSun, targetY, true));
        }

        private void SpawnSunflowerSun(Plant p)
        {
            PictureBox picSun = new PictureBox();
            picSun.Size = new Size(45, 45);

            picSun.Location = new Point(p.pic.Left + 8, p.pic.Top + 5);
            picSun.Image = Properties.Resources.sun;
            picSun.SizeMode = PictureBoxSizeMode.Zoom;
            picSun.BackColor = Color.FromArgb(124, 171, 85);
            picSun.Cursor = Cursors.Hand; 
            picSun.Click += Sun_Click;

            this.Controls.Add(picSun);
            picSun.BringToFront();

            listSuns.Add(new SunItem(picSun, picSun.Top, false));
        }

        private void Sun_Click(object sender, EventArgs e)
        {
            PictureBox clickedSun = sender as PictureBox;
            if (clickedSun == null) return;

            totalSun += 25;
            lblSunCount.Text = "SUN\n" + totalSun.ToString();

            for (int i = 0; i < listSuns.Count; i++)
            {
                if (listSuns[i].pic == clickedSun)
                {
                    listSuns.RemoveAt(i);
                    break;
                }
            }

            this.Controls.Remove(clickedSun);
            clickedSun.Dispose();
        }

        private void EndGame(bool isWin)
        {
            isGameOver = true;
            timerMain.Stop();
            timerMove.Stop();

            if (pnlResult.Parent != this)
            {
                this.Controls.Add(pnlResult);
            }

            if (pnlResult.Width == 0 || pnlResult.Height == 0)
            {
                pnlResult.Size = new Size(320, 190);
            }

            if (isWin)
            {
                lblResultTitle.Text = "YOU WIN!";
                lblResultTitle.ForeColor = Color.FromArgb(43, 103, 48);
                pnlResult.BackColor = Color.FromArgb(233, 245, 214);
            }
            else
            {
                lblResultTitle.Text = "GAME OVER";
                lblResultTitle.ForeColor = Color.FromArgb(159, 59, 45);
                pnlResult.BackColor = Color.FromArgb(251, 226, 213);
            }

            pnlResult.Location = new Point(
                    (this.ClientSize.Width - pnlResult.Width) / 2,
                    (this.ClientSize.Height - pnlResult.Height) / 2
            );

            lblResultSun.Text = "Sun tersisa: " + totalSun;

            pnlResult.Visible = true;
            pnlResult.BringToFront();
        }

        private void RestartGame()
        {
            pnlResult.Visible = false;

            for (int i = 0; i < listPlants.Count; i++)
            {
                this.Controls.Remove(listPlants[i].pic);
                this.Controls.Remove(listPlants[i].lblHp);
                listPlants[i].pic.Dispose();
                listPlants[i].lblHp.Dispose();
            }
            listPlants.Clear();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    activePlants[i, j] = null;
                }
            }

            for (int i = 0; i < listZombies.Count; i++)
            {
                this.Controls.Remove(listZombies[i].pic);
                this.Controls.Remove(listZombies[i].lblHp);
                listZombies[i].pic.Dispose();
                listZombies[i].lblHp.Dispose();
            }
            listZombies.Clear();

            for (int i = 0; i < listBullets.Count; i++)
            {
                this.Controls.Remove(listBullets[i].pic);
                listBullets[i].pic.Dispose();
            }
            listBullets.Clear();

            for (int i = 0; i < listSuns.Count; i++)
            {
                this.Controls.Remove(listSuns[i].pic);
                listSuns[i].pic.Dispose();
            }
            listSuns.Clear();

            totalSun = 150;
            timeLeft = 100;
            isGameOver = false;
            selectedPlant = "";
            zombieSpawnCooldown = 0;
            naturalSunCooldown = 0;

            ResetPlantButtons();

            lblSunCount.Text = "SUN\n" + totalSun.ToString();
            lblTime.Text = "TIME\n" + timeLeft + "s";

            SpawnNaturalSun();
            timerMain.Start();
            timerMove.Start();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
