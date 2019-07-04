namespace VP_Project
{
    partial class Game
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.button_FastForward = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.hintLabel = new System.Windows.Forms.ToolStripLabel();
			this.timerDraw = new System.Windows.Forms.Timer(this.components);
			this.ballAdder = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.scoreLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.scoreMultiplierLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.damageMultiplierLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ballMultiplierLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.button_FastForward,
            this.toolStripSeparator2,
            this.hintLabel});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(622, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(82, 22);
			this.toolStripLabel1.Text = "New Game";
			this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// button_FastForward
			// 
			this.button_FastForward.Name = "button_FastForward";
			this.button_FastForward.Size = new System.Drawing.Size(92, 22);
			this.button_FastForward.Text = "Fast Forward";
			this.button_FastForward.Click += new System.EventHandler(this.button_FastForward_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// hintLabel
			// 
			this.hintLabel.Name = "hintLabel";
			this.hintLabel.Size = new System.Drawing.Size(37, 22);
			this.hintLabel.Text = "Hint";
			this.hintLabel.Click += new System.EventHandler(this.hintLabel_Click);
			// 
			// timerDraw
			// 
			this.timerDraw.Enabled = true;
			// 
			// ballAdder
			// 
			this.ballAdder.Enabled = true;
			this.ballAdder.Interval = 200;
			this.ballAdder.Tick += new System.EventHandler(this.ballAdder_Tick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scoreLabel,
            this.toolStripStatusLabel1,
            this.scoreMultiplierLabel,
            this.toolStripStatusLabel2,
            this.damageMultiplierLabel,
            this.toolStripStatusLabel3,
            this.ballMultiplierLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 778);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip1.Size = new System.Drawing.Size(622, 25);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// scoreLabel
			// 
			this.scoreLabel.Name = "scoreLabel";
			this.scoreLabel.Size = new System.Drawing.Size(61, 20);
			this.scoreLabel.Text = "Score: 0";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 20);
			this.toolStripStatusLabel1.Text = "|";
			// 
			// scoreMultiplierLabel
			// 
			this.scoreMultiplierLabel.Name = "scoreMultiplierLabel";
			this.scoreMultiplierLabel.Size = new System.Drawing.Size(99, 20);
			this.scoreMultiplierLabel.Text = "Score Mult x0";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
			this.toolStripStatusLabel2.Text = "|";
			// 
			// damageMultiplierLabel
			// 
			this.damageMultiplierLabel.Name = "damageMultiplierLabel";
			this.damageMultiplierLabel.Size = new System.Drawing.Size(85, 20);
			this.damageMultiplierLabel.Text = "Damage x0";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 20);
			this.toolStripStatusLabel3.Text = "|";
			// 
			// ballMultiplierLabel
			// 
			this.ballMultiplierLabel.Name = "ballMultiplierLabel";
			this.ballMultiplierLabel.Size = new System.Drawing.Size(87, 20);
			this.ballMultiplierLabel.Text = "Ball Mult x0";
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 803);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.Name = "Game";
			this.Text = "BBTan";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_MouseClick);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_MouseMove);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Timer timerDraw;
		private System.Windows.Forms.ToolStripLabel button_FastForward;
		private System.Windows.Forms.Timer ballAdder;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel scoreLabel;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel scoreMultiplierLabel;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel damageMultiplierLabel;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel ballMultiplierLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel hintLabel;
	}
}

