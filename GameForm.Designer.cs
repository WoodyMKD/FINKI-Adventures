namespace FINKI_Adventures
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.gamePanel = new System.Windows.Forms.Panel();
            this.formPanel = new System.Windows.Forms.Panel();
            this.lbl_formPanel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.levelPanel = new System.Windows.Forms.Panel();
            this.lblPointsHealth = new System.Windows.Forms.Label();
            this.helpPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Timer(this.components);
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.levelPanel.SuspendLayout();
            this.helpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.gamePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.gamePanel.Location = new System.Drawing.Point(317, 156);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(138, 93);
            this.gamePanel.TabIndex = 0;
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.Transparent;
            this.formPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("formPanel.BackgroundImage")));
            this.formPanel.Controls.Add(this.lbl_formPanel);
            this.formPanel.Controls.Add(this.closeButton);
            this.formPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formPanel.Location = new System.Drawing.Point(0, 0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(800, 25);
            this.formPanel.TabIndex = 1;
            // 
            // lbl_formPanel
            // 
            this.lbl_formPanel.AutoSize = true;
            this.lbl_formPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_formPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_formPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_formPanel.Location = new System.Drawing.Point(0, 0);
            this.lbl_formPanel.Name = "lbl_formPanel";
            this.lbl_formPanel.Size = new System.Drawing.Size(166, 22);
            this.lbl_formPanel.TabIndex = 3;
            this.lbl_formPanel.Text = "FINKI Adventures";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.Image = global::FINKI_Adventures.Properties.Resources.close_btn;
            this.closeButton.Location = new System.Drawing.Point(775, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 25);
            this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeButton.TabIndex = 2;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // lblLevel
            // 
            this.lblLevel.BackColor = System.Drawing.Color.Black;
            this.lblLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLevel.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.Gray;
            this.lblLevel.Location = new System.Drawing.Point(0, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(428, 50);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // levelPanel
            // 
            this.levelPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.levelPanel.BackColor = System.Drawing.Color.Black;
            this.levelPanel.Controls.Add(this.lblPointsHealth);
            this.levelPanel.Controls.Add(this.lblLevel);
            this.levelPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.levelPanel.Location = new System.Drawing.Point(4, 100);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(784, 50);
            this.levelPanel.TabIndex = 1;
            // 
            // lblPointsHealth
            // 
            this.lblPointsHealth.BackColor = System.Drawing.Color.Black;
            this.lblPointsHealth.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPointsHealth.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsHealth.ForeColor = System.Drawing.Color.Gray;
            this.lblPointsHealth.Location = new System.Drawing.Point(434, 0);
            this.lblPointsHealth.Name = "lblPointsHealth";
            this.lblPointsHealth.Size = new System.Drawing.Size(350, 50);
            this.lblPointsHealth.TabIndex = 3;
            this.lblPointsHealth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // helpPanel
            // 
            this.helpPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.helpPanel.BackColor = System.Drawing.Color.Black;
            this.helpPanel.Controls.Add(this.label2);
            this.helpPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.helpPanel.Location = new System.Drawing.Point(12, 255);
            this.helpPanel.Name = "helpPanel";
            this.helpPanel.Size = new System.Drawing.Size(784, 50);
            this.helpPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(784, 50);
            this.label2.TabIndex = 3;
            this.label2.Text = "Притиснете \"R\" за да го рестартирате нивото | Притиснете \"ESC\" за да го отворите " +
    "менито";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimer
            // 
            this.lblTimer.Enabled = true;
            this.lblTimer.Interval = 300;
            this.lblTimer.Tick += new System.EventHandler(this.lblTimer_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FINKI_Adventures.Properties.Resources.form_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.helpPanel);
            this.Controls.Add(this.levelPanel);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.gamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.levelPanel.ResumeLayout(false);
            this.helpPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.Label lbl_formPanel;
        public System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Panel levelPanel;
        public System.Windows.Forms.Label lblPointsHealth;
        private System.Windows.Forms.Panel helpPanel;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer lblTimer;
    }
}

