namespace FINKI_Adventures
{
    partial class GameView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            this.sceneControl = new System.Windows.Forms.PictureBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btn_HowToPlay = new System.Windows.Forms.PictureBox();
            this.btn_Iskluci = new System.Windows.Forms.PictureBox();
            this.btn_newgame = new System.Windows.Forms.PictureBox();
            this.btn_continue = new System.Windows.Forms.PictureBox();
            this.imgHowToPlay = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.sceneControl.SuspendLayout();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_HowToPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Iskluci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_newgame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_continue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHowToPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // sceneControl
            // 
            this.sceneControl.BackColor = System.Drawing.Color.Black;
            this.sceneControl.Controls.Add(this.menuPanel);
            this.sceneControl.Location = new System.Drawing.Point(0, -780);
            this.sceneControl.Name = "sceneControl";
            this.sceneControl.Size = new System.Drawing.Size(1280, 1500);
            this.sceneControl.TabIndex = 10;
            this.sceneControl.Paint += new System.Windows.Forms.PaintEventHandler(this.sceneControl_Paint);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Black;
            this.menuPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuPanel.BackgroundImage")));
            this.menuPanel.Controls.Add(this.btnBack);
            this.menuPanel.Controls.Add(this.imgHowToPlay);
            this.menuPanel.Controls.Add(this.btn_HowToPlay);
            this.menuPanel.Controls.Add(this.btn_Iskluci);
            this.menuPanel.Controls.Add(this.btn_newgame);
            this.menuPanel.Controls.Add(this.btn_continue);
            this.menuPanel.Location = new System.Drawing.Point(0, 780);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1280, 720);
            this.menuPanel.TabIndex = 5;
            // 
            // btn_HowToPlay
            // 
            this.btn_HowToPlay.BackgroundImage = global::FINKI_Adventures.Properties.Resources.btn_HowToPlay;
            this.btn_HowToPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_HowToPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_HowToPlay.Location = new System.Drawing.Point(515, 375);
            this.btn_HowToPlay.Name = "btn_HowToPlay";
            this.btn_HowToPlay.Size = new System.Drawing.Size(179, 60);
            this.btn_HowToPlay.TabIndex = 3;
            this.btn_HowToPlay.TabStop = false;
            this.btn_HowToPlay.Click += new System.EventHandler(this.btn_HowToPlay_Click);
            // 
            // btn_Iskluci
            // 
            this.btn_Iskluci.BackgroundImage = global::FINKI_Adventures.Properties.Resources.btn_iskluci;
            this.btn_Iskluci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Iskluci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Iskluci.Location = new System.Drawing.Point(515, 456);
            this.btn_Iskluci.Name = "btn_Iskluci";
            this.btn_Iskluci.Size = new System.Drawing.Size(179, 60);
            this.btn_Iskluci.TabIndex = 2;
            this.btn_Iskluci.TabStop = false;
            this.btn_Iskluci.Click += new System.EventHandler(this.btn_Iskluci_Click);
            // 
            // btn_newgame
            // 
            this.btn_newgame.BackgroundImage = global::FINKI_Adventures.Properties.Resources.btn_newgame;
            this.btn_newgame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_newgame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_newgame.Location = new System.Drawing.Point(515, 220);
            this.btn_newgame.Name = "btn_newgame";
            this.btn_newgame.Size = new System.Drawing.Size(179, 60);
            this.btn_newgame.TabIndex = 1;
            this.btn_newgame.TabStop = false;
            this.btn_newgame.Click += new System.EventHandler(this.btn_newgame_Click);
            // 
            // btn_continue
            // 
            this.btn_continue.BackgroundImage = global::FINKI_Adventures.Properties.Resources.btn_ProdolziDisabled;
            this.btn_continue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_continue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_continue.Enabled = false;
            this.btn_continue.Location = new System.Drawing.Point(515, 297);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(179, 60);
            this.btn_continue.TabIndex = 0;
            this.btn_continue.TabStop = false;
            this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
            // 
            // imgHowToPlay
            // 
            this.imgHowToPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgHowToPlay.Image = global::FINKI_Adventures.Properties.Resources.instructionsBG;
            this.imgHowToPlay.InitialImage = global::FINKI_Adventures.Properties.Resources.instructionsBG1;
            this.imgHowToPlay.Location = new System.Drawing.Point(0, 0);
            this.imgHowToPlay.Name = "imgHowToPlay";
            this.imgHowToPlay.Size = new System.Drawing.Size(1280, 720);
            this.imgHowToPlay.TabIndex = 4;
            this.imgHowToPlay.TabStop = false;
            this.imgHowToPlay.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::FINKI_Adventures.Properties.Resources.btn_Back;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Location = new System.Drawing.Point(515, 610);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(179, 60);
            this.btnBack.TabIndex = 5;
            this.btnBack.TabStop = false;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // GameView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.sceneControl);
            this.DoubleBuffered = true;
            this.Name = "GameView";
            this.Size = new System.Drawing.Size(1280, 720);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameView_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameView_PreviewKeyDown);
            this.sceneControl.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_HowToPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Iskluci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_newgame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_continue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHowToPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sceneControl;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.PictureBox btn_continue;
        private System.Windows.Forms.PictureBox btn_newgame;
        private System.Windows.Forms.PictureBox btn_Iskluci;
        private System.Windows.Forms.PictureBox btn_HowToPlay;
        private System.Windows.Forms.PictureBox imgHowToPlay;
        private System.Windows.Forms.PictureBox btnBack;
    }
}
