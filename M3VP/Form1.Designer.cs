namespace M3VP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel6 = new Panel();
            lblTime = new Label();
            panel5 = new Panel();
            lblSunCount = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btnWallnut = new Button();
            btnPeashooter = new Button();
            btnSunflower = new Button();
            label2 = new Label();
            panelMap = new Panel();
            pnlResult = new Panel();
            btnRestart = new Button();
            lblResultSun = new Label();
            lblResultTitle = new Label();
            panelEnd = new Panel();
            panelStart = new Panel();
            timerMain = new System.Windows.Forms.Timer(components);
            timerMove = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            panelMap.SuspendLayout();
            pnlResult.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 92, 55);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-5, -11);
            panel1.Name = "panel1";
            panel1.Size = new Size(1197, 120);
            panel1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(247, 239, 184);
            panel6.Controls.Add(lblTime);
            panel6.Location = new Point(872, 38);
            panel6.Name = "panel6";
            panel6.Size = new Size(171, 63);
            panel6.TabIndex = 2;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(41, 92, 55);
            lblTime.Location = new Point(51, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(67, 31);
            lblTime.TabIndex = 4;
            lblTime.Text = "TIME";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(247, 239, 184);
            panel5.Controls.Add(lblSunCount);
            panel5.Location = new Point(683, 38);
            panel5.Name = "panel5";
            panel5.Size = new Size(171, 63);
            panel5.TabIndex = 1;
            // 
            // lblSunCount
            // 
            lblSunCount.AutoSize = true;
            lblSunCount.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSunCount.ForeColor = Color.FromArgb(41, 92, 55);
            lblSunCount.Location = new Point(52, 0);
            lblSunCount.Name = "lblSunCount";
            lblSunCount.Size = new Size(61, 31);
            lblSunCount.TabIndex = 3;
            lblSunCount.Text = "SUN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(37, 38);
            label1.Name = "label1";
            label1.Size = new Size(217, 54);
            label1.TabIndex = 0;
            label1.Text = "ZOMBIEEE";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 250, 230);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnWallnut);
            panel2.Controls.Add(btnPeashooter);
            panel2.Controls.Add(btnSunflower);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(32, 133);
            panel2.Name = "panel2";
            panel2.Size = new Size(212, 400);
            panel2.TabIndex = 1;
            // 
            // btnWallnut
            // 
            btnWallnut.BackColor = Color.FromArgb(229, 239, 194);
            btnWallnut.FlatAppearance.BorderColor = Color.FromArgb(192, 210, 151);
            btnWallnut.FlatAppearance.BorderSize = 2;
            btnWallnut.FlatStyle = FlatStyle.Flat;
            btnWallnut.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWallnut.ForeColor = Color.FromArgb(105, 145, 76);
            btnWallnut.Location = new Point(14, 236);
            btnWallnut.Name = "btnWallnut";
            btnWallnut.Size = new Size(180, 62);
            btnWallnut.TabIndex = 5;
            btnWallnut.Text = "WALLNUT\r\n75 SUN";
            btnWallnut.UseVisualStyleBackColor = false;
            btnWallnut.Click += btnWallnut_Click;
            // 
            // btnPeashooter
            // 
            btnPeashooter.BackColor = Color.FromArgb(229, 239, 194);
            btnPeashooter.FlatAppearance.BorderColor = Color.FromArgb(192, 210, 151);
            btnPeashooter.FlatAppearance.BorderSize = 2;
            btnPeashooter.FlatStyle = FlatStyle.Flat;
            btnPeashooter.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPeashooter.ForeColor = Color.FromArgb(105, 145, 76);
            btnPeashooter.Location = new Point(14, 159);
            btnPeashooter.Name = "btnPeashooter";
            btnPeashooter.Size = new Size(180, 62);
            btnPeashooter.TabIndex = 4;
            btnPeashooter.Text = "PEASHOOTER\r\n100 SUN\r\n";
            btnPeashooter.UseVisualStyleBackColor = false;
            btnPeashooter.Click += btnPeashooter_Click;
            // 
            // btnSunflower
            // 
            btnSunflower.BackColor = Color.FromArgb(229, 239, 194);
            btnSunflower.FlatAppearance.BorderColor = Color.FromArgb(192, 210, 151);
            btnSunflower.FlatAppearance.BorderSize = 2;
            btnSunflower.FlatStyle = FlatStyle.Flat;
            btnSunflower.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSunflower.ForeColor = Color.FromArgb(105, 145, 76);
            btnSunflower.Location = new Point(14, 79);
            btnSunflower.Name = "btnSunflower";
            btnSunflower.Size = new Size(180, 62);
            btnSunflower.TabIndex = 1;
            btnSunflower.Text = "SUNFLOWER \r\n50 SUN";
            btnSunflower.UseVisualStyleBackColor = false;
            btnSunflower.Click += btnSunflower_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(51, 92, 49);
            label2.Location = new Point(3, 15);
            label2.Name = "label2";
            label2.Size = new Size(208, 31);
            label2.TabIndex = 3;
            label2.Text = "PILIH TANAMAN";
            // 
            // panelMap
            // 
            panelMap.BorderStyle = BorderStyle.FixedSingle;
            panelMap.Controls.Add(pnlResult);
            panelMap.Location = new Point(263, 133);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(720, 400);
            panelMap.TabIndex = 2;
            // 
            // pnlResult
            // 
            pnlResult.BackColor = Color.FromArgb(233, 245, 214);
            pnlResult.Controls.Add(btnRestart);
            pnlResult.Controls.Add(lblResultSun);
            pnlResult.Controls.Add(lblResultTitle);
            pnlResult.Location = new Point(167, 79);
            pnlResult.Name = "pnlResult";
            pnlResult.Size = new Size(430, 246);
            pnlResult.TabIndex = 0;
            // 
            // btnRestart
            // 
            btnRestart.BackColor = Color.FromArgb(74, 132, 68);
            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.ForeColor = SystemColors.ButtonHighlight;
            btnRestart.Location = new Point(136, 162);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(153, 45);
            btnRestart.TabIndex = 5;
            btnRestart.Text = "MAIN LAGI";
            btnRestart.UseVisualStyleBackColor = false;
            btnRestart.Click += btnRestart_Click;
            // 
            // lblResultSun
            // 
            lblResultSun.AutoSize = true;
            lblResultSun.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblResultSun.ForeColor = Color.FromArgb(41, 92, 55);
            lblResultSun.Location = new Point(165, 105);
            lblResultSun.Name = "lblResultSun";
            lblResultSun.Size = new Size(101, 23);
            lblResultSun.TabIndex = 4;
            lblResultSun.Text = "Sun tersisa: ";
            // 
            // lblResultTitle
            // 
            lblResultTitle.AutoSize = true;
            lblResultTitle.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultTitle.ForeColor = Color.FromArgb(43, 105, 46);
            lblResultTitle.Location = new Point(107, 33);
            lblResultTitle.Name = "lblResultTitle";
            lblResultTitle.Size = new Size(224, 54);
            lblResultTitle.TabIndex = 3;
            lblResultTitle.Text = "YOU WIN!";
            // 
            // panelEnd
            // 
            panelEnd.BackColor = Color.FromArgb(196, 60, 49);
            panelEnd.Location = new Point(255, 133);
            panelEnd.Name = "panelEnd";
            panelEnd.Size = new Size(10, 400);
            panelEnd.TabIndex = 100;
            // 
            // panelStart
            // 
            panelStart.BackColor = Color.FromArgb(105, 145, 76);
            panelStart.Location = new Point(982, 133);
            panelStart.Name = "panelStart";
            panelStart.Size = new Size(97, 400);
            panelStart.TabIndex = 100;
            // 
            // timerMain
            // 
            timerMain.Interval = 1000;
            timerMain.Tick += timerMain_Tick;
            // 
            // timerMove
            // 
            timerMove.Interval = 30;
            timerMove.Tick += timerMove_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 242, 219);
            ClientSize = new Size(1192, 587);
            Controls.Add(panelEnd);
            Controls.Add(panelMap);
            Controls.Add(panelStart);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "ZOMBIEEE - Dynamic Component & Timer";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelMap.ResumeLayout(false);
            pnlResult.ResumeLayout(false);
            pnlResult.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panelMap;
        private Panel panelStart;
        private Label label1;
        private Panel panel6;
        private Panel panel5;
        private Button btnSunflower;
        private Label label2;
        private Button btnWallnut;
        private Button btnPeashooter;
        private Panel panelEnd;
        private Label lblSunCount;
        private Label lblTime;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Timer timerMove;
        private Panel pnlResult;
        private Button btnRestart;
        private Label lblResultSun;
        private Label lblResultTitle;
    }
}
