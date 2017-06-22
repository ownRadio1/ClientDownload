using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader
{
	public partial class Downloader : Form
	{
		private readonly OwnRadio _ownRadio = new OwnRadio(Properties.Settings.Default.DeviceId);

		public Downloader()
		{
			InitializeComponent();
		}

		private async void btnLoad_Click(object sender, EventArgs e)
		{
			var service = new ZaycevService();
			var page = Convert.ToInt32(numericUpDown1.Value);

			var tracks = await service.GetTracks(page);

			foreach (var track in tracks)
			{
				var audio = await service.GetTrack(track.Url);

				// Save tracks to local disk
				/* 
				FileStream fileStream = File.Create($"E:\\Music\\Zaycev\\{track.Guid}.mp3");
				fileStream.Write(audio, 0, audio.Length);
				*/

				_ownRadio.Upload(track, audio);
				tbConsole.Text += $"{track.Guid}.mp3 - Загружено" + Environment.NewLine;
				progressBar1.Value += 2;
			}

			progressBar1.Value = 100;
			MessageBox.Show("Треки загружены!");
		}
	}
}
