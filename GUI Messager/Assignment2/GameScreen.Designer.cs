namespace Assignment2
{
    partial class GameScreen
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
            this.GameBox = new System.Windows.Forms.PictureBox();
            this.UserMessageBox = new System.Windows.Forms.TextBox();
            this.UserTextSubmitButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GameExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworkMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworkConnectButton = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworkDisconnectButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GameMessageBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameBox
            // 
            this.GameBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GameBox.Location = new System.Drawing.Point(12, 25);
            this.GameBox.Name = "GameBox";
            this.GameBox.Size = new System.Drawing.Size(530, 224);
            this.GameBox.TabIndex = 0;
            this.GameBox.TabStop = false;
            // 
            // UserMessageBox
            // 
            this.UserMessageBox.Location = new System.Drawing.Point(13, 269);
            this.UserMessageBox.Name = "UserMessageBox";
            this.UserMessageBox.Size = new System.Drawing.Size(429, 20);
            this.UserMessageBox.TabIndex = 1;
            // 
            // UserTextSubmitButton
            // 
            this.UserTextSubmitButton.Location = new System.Drawing.Point(448, 269);
            this.UserTextSubmitButton.Name = "UserTextSubmitButton";
            this.UserTextSubmitButton.Size = new System.Drawing.Size(75, 20);
            this.UserTextSubmitButton.TabIndex = 2;
            this.UserTextSubmitButton.Text = "Send";
            this.UserTextSubmitButton.UseVisualStyleBackColor = true;
            this.UserTextSubmitButton.Click += new System.EventHandler(this.UserTextSubmitButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenu,
            this.NetworkMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GameMenu
            // 
            this.GameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameExitButton});
            this.GameMenu.Name = "GameMenu";
            this.GameMenu.Size = new System.Drawing.Size(50, 20);
            this.GameMenu.Text = "Game";
            // 
            // GameExitButton
            // 
            this.GameExitButton.Name = "GameExitButton";
            this.GameExitButton.Size = new System.Drawing.Size(93, 22);
            this.GameExitButton.Text = "Exit";
            this.GameExitButton.Click += new System.EventHandler(this.GameExitButton_Click);
            // 
            // NetworkMenu
            // 
            this.NetworkMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NetworkConnectButton,
            this.NetworkDisconnectButton});
            this.NetworkMenu.Name = "NetworkMenu";
            this.NetworkMenu.Size = new System.Drawing.Size(64, 20);
            this.NetworkMenu.Text = "Network";
            // 
            // NetworkConnectButton
            // 
            this.NetworkConnectButton.Name = "NetworkConnectButton";
            this.NetworkConnectButton.Size = new System.Drawing.Size(133, 22);
            this.NetworkConnectButton.Text = "Connect";
            this.NetworkConnectButton.Click += new System.EventHandler(this.NetworkConnectButton_Click);
            // 
            // NetworkDisconnectButton
            // 
            this.NetworkDisconnectButton.Name = "NetworkDisconnectButton";
            this.NetworkDisconnectButton.Size = new System.Drawing.Size(133, 22);
            this.NetworkDisconnectButton.Text = "Disconnect";
            this.NetworkDisconnectButton.Click += new System.EventHandler(this.NetworkDisconnectButton_Click);
            // 
            // GameMessageBox
            // 
            this.GameMessageBox.Location = new System.Drawing.Point(13, 316);
            this.GameMessageBox.Multiline = true;
            this.GameMessageBox.Name = "GameMessageBox";
            this.GameMessageBox.ReadOnly = true;
            this.GameMessageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GameMessageBox.Size = new System.Drawing.Size(510, 185);
            this.GameMessageBox.TabIndex = 4;
            // 
            // GameScreen
            // 
            this.ClientSize = new System.Drawing.Size(554, 513);
            this.Controls.Add(this.GameMessageBox);
            this.Controls.Add(this.UserTextSubmitButton);
            this.Controls.Add(this.UserMessageBox);
            this.Controls.Add(this.GameBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox GameBox;
        private System.Windows.Forms.TextBox UserMessageBox;
        private System.Windows.Forms.Button UserTextSubmitButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GameMenu;
        private System.Windows.Forms.ToolStripMenuItem NetworkMenu;
        private System.Windows.Forms.ToolStripMenuItem NetworkConnectButton;
        private System.Windows.Forms.ToolStripMenuItem NetworkDisconnectButton;
        private System.Windows.Forms.ToolStripMenuItem GameExitButton;
        private System.Windows.Forms.TextBox GameMessageBox;
    }
}

