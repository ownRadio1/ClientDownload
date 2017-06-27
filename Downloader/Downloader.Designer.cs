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
			this.components = new System.ComponentModel.Container();
			this.tbConsole = new System.Windows.Forms.TextBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.timerDownload = new System.Windows.Forms.Timer(this.components);
			this.btnTimer = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbSource = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// tbConsole
			// 
			this.tbConsole.Location = new System.Drawing.Point(12, 99);
			this.tbConsole.Multiline = true;
			this.tbConsole.Name = "tbConsole";
			this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConsole.Size = new System.Drawing.Size(422, 350);
			this.tbConsole.TabIndex = 2;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 70);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(422, 23);
			this.progressBar1.TabIndex = 3;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDown1.Location = new System.Drawing.Point(195, 15);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(239, 20);
			this.numericUpDown1.TabIndex = 4;
			this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Количество треков для загрузки:";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 41);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(209, 23);
			this.btnStart.TabIndex = 6;
			this.btnStart.Text = "Загрузить вручную";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// timerDownload
			// 
			this.timerDownload.Interval = 3600000;
			this.timerDownload.Tick += new System.EventHandler(this.timerDownload_Tick);
			// 
			// btnTimer
			// 
			this.btnTimer.Location = new System.Drawing.Point(227, 41);
			this.btnTimer.Name = "btnTimer";
			this.btnTimer.Size = new System.Drawing.Size(207, 23);
			this.btnTimer.TabIndex = 7;
			this.btnTimer.Text = "Запустить таймер";
			this.btnTimer.UseVisualStyleBackColor = true;
			this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(367, 455);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "v2017.06.27";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 455);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(210, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Сервис: http://zaycev.net/new/index.html";
			// 
			// cbSource
			// 
			this.cbSource.FormattingEnabled = true;
			this.cbSource.Items.AddRange(new object[] {
            "New",
            "Top"});
			this.cbSource.Location = new System.Drawing.Point(227, 452);
			this.cbSource.Name = "cbSource";
			this.cbSource.Size = new System.Drawing.Size(107, 21);
			this.cbSource.TabIndex = 10;
			this.cbSource.Text = "New";
			this.cbSource.SelectedIndexChanged += new System.EventHandler(this.cbSource_SelectedIndexChanged);
			// 
			// Downloader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 477);
			this.Controls.Add(this.cbSource);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnTimer);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.tbConsole);
			this.Name = "Downloader";
			this.Text = "Downloader";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox tbConsole;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Timer timerDownload;
		private System.Windows.Forms.Button btnTimer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbSource;
	}
}

