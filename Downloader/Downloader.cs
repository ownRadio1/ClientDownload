using System;
using System.Windows.Forms;

namespace Downloader
{
	public partial class Downloader : Form
	{
		private DownloadEngine _engine;

		public Downloader()
		{
			InitializeComponent();

			_engine = new DownloadEngine(new ZaycevService("new"), 500, 1000*60*60);
		}
		
		private async void btnStart_Click(object sender, EventArgs e)
		{
			tbConsole.Text = @"ВРУЧНУЮ: Начало загрузки" + Environment.NewLine + tbConsole.Text;

			btnStart.Enabled = false;
			cbSource.Enabled = false;

			_engine.Amount = Convert.ToInt32(numericUpDown1.Value);

			var progress = new Progress<int>(val => progressBar1.Value = val);
			var log = new Progress<string>(message => tbConsole.Text = message + Environment.NewLine + tbConsole.Text);
			
			await _engine.Download(progress, log);

			btnStart.Enabled = true;
			cbSource.Enabled = true;
		}

		private async void timerDownload_Tick(object sender, EventArgs e)
		{
			tbConsole.Text = @"ТАЙМЕР: Начало загрузки" + Environment.NewLine + tbConsole.Text;

			btnStart.Enabled = false;
			cbSource.Enabled = false;
			timerDownload.Stop();

			_engine.Amount = Convert.ToInt32(numericUpDown1.Value);

			var progress = new Progress<int>(val => progressBar1.Value = val);
			var log = new Progress<string>(message => tbConsole.Text = message + Environment.NewLine + tbConsole.Text);

			await _engine.Download(progress, log);

			btnStart.Enabled = true;
			cbSource.Enabled = true;
			timerDownload.Start();
		}

		private void btnTimer_Click(object sender, EventArgs e)
		{
			if (!timerDownload.Enabled)
			{
				btnTimer.Text = @"Остановить таймер";
				timerDownload.Start();
			}
			else
			{
				btnTimer.Text = @"Запустить таймер";
				timerDownload.Stop();
			}
		}

		private void cbSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(cbSource.SelectedIndex == 0)
			{
				_engine = new DownloadEngine(new ZaycevService("new"), 500, 1000 * 60 * 60);
				label3.Text = @"Сервис: http://zaycev.net/new/index.html";
			}
			else if(cbSource.SelectedIndex == 1)
			{
				_engine = new DownloadEngine(new ZaycevService("top"), 500, 1000 * 60 * 60);
				label3.Text = @"Сервис: http://zaycev.net/";

			}
		}
	}
}
