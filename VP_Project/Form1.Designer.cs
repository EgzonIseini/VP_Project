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
			this.timerDraw = new System.Windows.Forms.Timer(this.components);
			this.ballAdder = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.scoreLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.scoreMultiplierLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.damageMultiplierLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.button_FastForward});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(466, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
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
			this.button_FastForward.Size = new System.Drawing.Size(74, 22);
			this.button_FastForward.Text = "Fast Forward";
			this.button_FastForward.Click += new System.EventHandler(this.button_FastForward_Click);
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
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scoreLabel,
            this.toolStripStatusLabel1,
            this.scoreMultiplierLabel,
            this.toolStripStatusLabel2,
            this.damageMultiplierLabel,
            this.toolStripStatusLabel3,
            this.ballMultiplierLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 625);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(466, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// scoreLabel
			// 
			this.scoreLabel.Name = "scoreLabel";
			this.scoreLabel.Size = new System.Drawing.Size(66, 17);
			this.scoreLabel.Text = "Score: 2018";
			// 
			// scoreMultiplierLabel
			// 
			this.scoreMultiplierLabel.Name = "scoreMultiplierLabel";
			this.scoreMultiplierLabel.Size = new System.Drawing.Size(76, 17);
			this.scoreMultiplierLabel.Text = "Score Mult: 1";
			// 
			// damageMultiplierLabel
			// 
			this.damageMultiplierLabel.Name = "damageMultiplierLabel";
			this.damageMultiplierLabel.Size = new System.Drawing.Size(91, 17);
			this.damageMultiplierLabel.Text = "Damage Mult: 1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel1.Text = "|";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel2.Text = "|";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel3.Text = "|";
			// 
			// ballMultiplierLabel
			// 
			this.ballMultiplierLabel.Name = "ballMultiplierLabel";
			this.ballMultiplierLabel.Size = new System.Drawing.Size(66, 17);
			this.ballMultiplierLabel.Text = "Ball Mult: 1";
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466, 647);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Game";
			this.Text = "BBTan";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
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
	}
}

