namespace Downloader
{
	partial class Downloader
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
			this.btnLoad = new System.Windows.Forms.Button();
			this.tbConsole = new System.Windows.Forms.TextBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(226, 12);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(239, 23);
			this.btnLoad.TabIndex = 1;
			this.btnLoad.Text = "Загрузить";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// tbConsole
			// 
			this.tbConsole.Location = new System.Drawing.Point(12, 70);
			this.tbConsole.Multiline = true;
			this.tbConsole.Name = "tbConsole";
			this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConsole.Size = new System.Drawing.Size(453, 356);
			this.tbConsole.TabIndex = 2;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 41);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(453, 23);
			this.progressBar1.TabIndex = 3;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(76, 15);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(144, 20);
			this.numericUpDown1.TabIndex = 4;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Страница:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(477, 441);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.tbConsole);
			this.Controls.Add(this.btnLoad);
			this.Name = "Form1";
			this.Text = "Downloader";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.TextBox tbConsole;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
	}
}

