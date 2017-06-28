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
			tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: ВРУЧНУЮ: Начало загрузки" + Environment.NewLine + tbConsole.Text;

			btnStart.Enabled = false;
			btnTimer.Enabled = false;
			cbSource.Enabled = false;

			_engine.Amount = Convert.ToInt32(numericUpDown1.Value);

			try
			{
				var progress = new Progress<int>(val => progressBar1.Value = val);
				var log = new Progress<string>(message => tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: " + message + Environment.NewLine + tbConsole.Text);
			
				await _engine.Download(progress, log);
			}
			catch
			{
				tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: Ошибка загрузки" + Environment.NewLine + tbConsole.Text;
				progressBar1.Value = 0;
			}
			
			tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: ВРУЧНУЮ: Конец загрузки" + Environment.NewLine + tbConsole.Text;

			btnStart.Enabled = true;
			btnTimer.Enabled = true;
			cbSource.Enabled = true;
		}

		private async void timerDownload_Tick(object sender, EventArgs e)
		{
			tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: ТАЙМЕР: Начало загрузки" + Environment.NewLine + tbConsole.Text;

			btnStart.Enabled = false;
			cbSource.Enabled = false;
			timerDownload.Stop();

			_engine.Amount = Convert.ToInt32(numericUpDown1.Value);

			try
			{
				var progress = new Progress<int>(val => progressBar1.Value = val);
				var log = new Progress<string>(message => tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: " + message + Environment.NewLine + tbConsole.Text);

				await _engine.Download(progress, log);
			}
			catch
			{
				tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: ТАЙМЕР: Ошибка загрузки. Следующая попытка через 1 час" + Environment.NewLine + tbConsole.Text;
				progressBar1.Value = 0;
			}
			
			btnStart.Enabled = true;
			cbSource.Enabled = true;
			
			tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: ТАЙМЕР: Конец загрузки" + Environment.NewLine + tbConsole.Text;

			timerDownload.Start();
		}

		private void btnTimer_Click(object sender, EventArgs e)
		{
			if (!timerDownload.Enabled)
			{
				btnTimer.Text = @"Остановить таймер";
				tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: ТАЙМЕР: До начала загрузки 1 час" + Environment.NewLine + tbConsole.Text;
				btnStart.Enabled = false;
				timerDownload.Start();
			}
			else
			{
				btnTimer.Text = @"Запустить таймер";
				tbConsole.Text = $"[{DateTime.Now.ToShortTimeString()}]: ТАЙМЕР: Остановлен" + Environment.NewLine + tbConsole.Text;
				btnStart.Enabled = true;
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
