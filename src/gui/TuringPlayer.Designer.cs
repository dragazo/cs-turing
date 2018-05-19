namespace turing
{
    partial class TuringPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FollowCheck = new System.Windows.Forms.CheckBox();
            this.TickButton = new System.Windows.Forms.Button();
            this.PrevDataButton = new System.Windows.Forms.Button();
            this.NextDataButton = new System.Windows.Forms.Button();
            this.DataCurrentButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FollowCheck
            // 
            this.FollowCheck.AutoSize = true;
            this.FollowCheck.Checked = true;
            this.FollowCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FollowCheck.Location = new System.Drawing.Point(93, 31);
            this.FollowCheck.Name = "FollowCheck";
            this.FollowCheck.Size = new System.Drawing.Size(56, 17);
            this.FollowCheck.TabIndex = 0;
            this.FollowCheck.Text = "Follow";
            this.FollowCheck.UseVisualStyleBackColor = true;
            this.FollowCheck.CheckedChanged += new System.EventHandler(this.FollowCheck_CheckedChanged);
            // 
            // TickButton
            // 
            this.TickButton.Location = new System.Drawing.Point(12, 27);
            this.TickButton.Name = "TickButton";
            this.TickButton.Size = new System.Drawing.Size(75, 23);
            this.TickButton.TabIndex = 1;
            this.TickButton.Text = "Tick";
            this.TickButton.UseVisualStyleBackColor = true;
            this.TickButton.Click += new System.EventHandler(this.TickButton_Click);
            // 
            // PrevDataButton
            // 
            this.PrevDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrevDataButton.Location = new System.Drawing.Point(355, 27);
            this.PrevDataButton.Name = "PrevDataButton";
            this.PrevDataButton.Size = new System.Drawing.Size(75, 23);
            this.PrevDataButton.TabIndex = 2;
            this.PrevDataButton.Text = "Previous";
            this.PrevDataButton.UseVisualStyleBackColor = true;
            this.PrevDataButton.Click += new System.EventHandler(this.PrevDataButton_Click);
            // 
            // NextDataButton
            // 
            this.NextDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NextDataButton.Location = new System.Drawing.Point(517, 27);
            this.NextDataButton.Name = "NextDataButton";
            this.NextDataButton.Size = new System.Drawing.Size(75, 23);
            this.NextDataButton.TabIndex = 3;
            this.NextDataButton.Text = "Next";
            this.NextDataButton.UseVisualStyleBackColor = true;
            this.NextDataButton.Click += new System.EventHandler(this.NextDataButton_Click);
            // 
            // DataCurrentButton
            // 
            this.DataCurrentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataCurrentButton.Location = new System.Drawing.Point(436, 27);
            this.DataCurrentButton.Name = "DataCurrentButton";
            this.DataCurrentButton.Size = new System.Drawing.Size(75, 23);
            this.DataCurrentButton.TabIndex = 4;
            this.DataCurrentButton.Text = "Current";
            this.DataCurrentButton.UseVisualStyleBackColor = true;
            this.DataCurrentButton.Click += new System.EventHandler(this.DataCurrentButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataToolStripMenuItem.Text = "Data";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // TuringPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 561);
            this.Controls.Add(this.DataCurrentButton);
            this.Controls.Add(this.NextDataButton);
            this.Controls.Add(this.PrevDataButton);
            this.Controls.Add(this.TickButton);
            this.Controls.Add(this.FollowCheck);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(620, 600);
            this.Name = "TuringPlayer";
            this.Text = "Turing PLayer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox FollowCheck;
        private System.Windows.Forms.Button TickButton;
        private System.Windows.Forms.Button PrevDataButton;
        private System.Windows.Forms.Button NextDataButton;
        private System.Windows.Forms.Button DataCurrentButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
    }
}

