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
            this.sceneControl = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btn_newgame = new System.Windows.Forms.PictureBox();
            this.btn_continue = new System.Windows.Forms.PictureBox();
            this.sceneControl.SuspendLayout();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_newgame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_continue)).BeginInit();
            this.SuspendLayout();
            // 
            // sceneControl
            // 
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
            this.menuPanel.Controls.Add(this.btn_newgame);
            this.menuPanel.Controls.Add(this.btn_continue);
            this.menuPanel.Location = new System.Drawing.Point(0, 780);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1280, 720);
            this.menuPanel.TabIndex = 5;
            // 
            // btn_newgame
            // 
            this.btn_newgame.BackgroundImage = global::FINKI_Adventures.Properties.Resources.btn_newgame;
            this.btn_newgame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_newgame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_newgame.Location = new System.Drawing.Point(515, 287);
            this.btn_newgame.Name = "btn_newgame";
            this.btn_newgame.Size = new System.Drawing.Size(179, 60);
            this.btn_newgame.TabIndex = 1;
            this.btn_newgame.TabStop = false;
            this.btn_newgame.Click += new System.EventHandler(this.btn_newgame_Click);
            // 
            // btn_continue
            // 
            this.btn_continue.BackgroundImage = global::FINKI_Adventures.Properties.Resources.btn_continue;
            this.btn_continue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_continue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_continue.Location = new System.Drawing.Point(515, 188);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(179, 60);
            this.btn_continue.TabIndex = 0;
            this.btn_continue.TabStop = false;
            this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
            // 
            // GameView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.sceneControl);
            this.Name = "GameView";
            this.Size = new System.Drawing.Size(1280, 720);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameView_PreviewKeyDown);
            this.sceneControl.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_newgame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_continue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sceneControl;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.PictureBox btn_continue;
        private System.Windows.Forms.PictureBox btn_newgame;
    }
}
