namespace VP_Project
{
	partial class cheatMenu
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
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numCurrentScore = new System.Windows.Forms.NumericUpDown();
			this.numScoreMult = new System.Windows.Forms.NumericUpDown();
			this.numDamageMult = new System.Windows.Forms.NumericUpDown();
			this.numBallMult = new System.Windows.Forms.NumericUpDown();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numCurrentScore)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numScoreMult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDamageMult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBallMult)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current Score:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Score Multiplier:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(125, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Damage Multiplier:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(44, 153);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(95, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "Ball Multiplier:";
			// 
			// numCurrentScore
			// 
			this.numCurrentScore.Location = new System.Drawing.Point(145, 56);
			this.numCurrentScore.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numCurrentScore.Name = "numCurrentScore";
			this.numCurrentScore.Size = new System.Drawing.Size(120, 22);
			this.numCurrentScore.TabIndex = 5;
			this.numCurrentScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numCurrentScore.ValueChanged += new System.EventHandler(this.numCurrentScore_ValueChanged);
			// 
			// numScoreMult
			// 
			this.numScoreMult.Location = new System.Drawing.Point(145, 87);
			this.numScoreMult.Name = "numScoreMult";
			this.numScoreMult.Size = new System.Drawing.Size(120, 22);
			this.numScoreMult.TabIndex = 7;
			this.numScoreMult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numScoreMult.ValueChanged += new System.EventHandler(this.numScoreMult_ValueChanged);
			// 
			// numDamageMult
			// 
			this.numDamageMult.Location = new System.Drawing.Point(145, 120);
			this.numDamageMult.Name = "numDamageMult";
			this.numDamageMult.Size = new System.Drawing.Size(120, 22);
			this.numDamageMult.TabIndex = 8;
			this.numDamageMult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numDamageMult.ValueChanged += new System.EventHandler(this.numDamageMult_ValueChanged);
			// 
			// numBallMult
			// 
			this.numBallMult.Location = new System.Drawing.Point(145, 153);
			this.numBallMult.Name = "numBallMult";
			this.numBallMult.Size = new System.Drawing.Size(120, 22);
			this.numBallMult.TabIndex = 9;
			this.numBallMult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numBallMult.ValueChanged += new System.EventHandler(this.numBallMult_ValueChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(12, 194);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(259, 37);
			this.buttonOK.TabIndex = 10;
			this.buttonOK.Text = "Cheating is bad :)";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(12, 237);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(259, 37);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "Cancel (be a good boy)";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(246, 34);
			this.label2.TabIndex = 12;
			this.label2.Text = "CAUTION: powerful cheat. With great \r\npower comes great responsibility! :)";
			// 
			// cheatMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(283, 285);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.numBallMult);
			this.Controls.Add(this.numDamageMult);
			this.Controls.Add(this.numScoreMult);
			this.Controls.Add(this.numCurrentScore);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "cheatMenu";
			this.Text = "CHEAT MENU";
			this.Load += new System.EventHandler(this.cheatMenu_Load);
			((System.ComponentModel.ISupportInitialize)(this.numCurrentScore)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numScoreMult)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDamageMult)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBallMult)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numCurrentScore;
		private System.Windows.Forms.NumericUpDown numScoreMult;
		private System.Windows.Forms.NumericUpDown numDamageMult;
		private System.Windows.Forms.NumericUpDown numBallMult;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label2;
	}
}