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
            this.SuspendLayout();
            // 
            // FollowCheck
            // 
            this.FollowCheck.AutoSize = true;
            this.FollowCheck.Checked = true;
            this.FollowCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FollowCheck.Location = new System.Drawing.Point(12, 12);
            this.FollowCheck.Name = "FollowCheck";
            this.FollowCheck.Size = new System.Drawing.Size(56, 17);
            this.FollowCheck.TabIndex = 0;
            this.FollowCheck.Text = "Follow";
            this.FollowCheck.UseVisualStyleBackColor = true;
            // 
            // TickButton
            // 
            this.TickButton.Location = new System.Drawing.Point(100, 8);
            this.TickButton.Name = "TickButton";
            this.TickButton.Size = new System.Drawing.Size(75, 23);
            this.TickButton.TabIndex = 1;
            this.TickButton.Text = "Tick";
            this.TickButton.UseVisualStyleBackColor = true;
            this.TickButton.Click += new System.EventHandler(this.TickButton_Click);
            // 
            // PrevDataButton
            // 
            this.PrevDataButton.Location = new System.Drawing.Point(355, 8);
            this.PrevDataButton.Name = "PrevDataButton";
            this.PrevDataButton.Size = new System.Drawing.Size(75, 23);
            this.PrevDataButton.TabIndex = 2;
            this.PrevDataButton.Text = "Previous";
            this.PrevDataButton.UseVisualStyleBackColor = true;
            this.PrevDataButton.Click += new System.EventHandler(this.PrevDataButton_Click);
            // 
            // NextDataButton
            // 
            this.NextDataButton.Location = new System.Drawing.Point(517, 8);
            this.NextDataButton.Name = "NextDataButton";
            this.NextDataButton.Size = new System.Drawing.Size(75, 23);
            this.NextDataButton.TabIndex = 3;
            this.NextDataButton.Text = "Next";
            this.NextDataButton.UseVisualStyleBackColor = true;
            this.NextDataButton.Click += new System.EventHandler(this.NextDataButton_Click);
            // 
            // DataCurrentButton
            // 
            this.DataCurrentButton.Location = new System.Drawing.Point(436, 8);
            this.DataCurrentButton.Name = "DataCurrentButton";
            this.DataCurrentButton.Size = new System.Drawing.Size(75, 23);
            this.DataCurrentButton.TabIndex = 4;
            this.DataCurrentButton.Text = "Current";
            this.DataCurrentButton.UseVisualStyleBackColor = true;
            this.DataCurrentButton.Click += new System.EventHandler(this.DataCurrentButton_Click);
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
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(620, 600);
            this.Name = "TuringPlayer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox FollowCheck;
        private System.Windows.Forms.Button TickButton;
        private System.Windows.Forms.Button PrevDataButton;
        private System.Windows.Forms.Button NextDataButton;
        private System.Windows.Forms.Button DataCurrentButton;
    }
}

