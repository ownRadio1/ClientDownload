using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader
{
	internal class DownloadEngine
	{
		private readonly ITrackService _service;
		private readonly OwnRadio _ownRadio = new OwnRadio(Properties.Settings.Default.DeviceId);
		private readonly Timer _timer = new Timer();
		private readonly Context _db = new Context();

		public int Amount { get; set; }
		
		public DownloadEngine(ITrackService service, int amount, int interval)
		{
			_service = service;
			_timer.Interval = interval;
			Amount = amount;
		}
		
		public async Task Download(IProgress<int> progress, IProgress<string> log)
		{
			try
			{
				var tracks = await _service.GetTracks(Amount).ConfigureAwait(false);
				
				for (var i = 0; i < Amount; i++)
				{
					var percentage = (i + 1) * 100 / Amount;

					var guid = tracks[i].Guid;

					var count = _db.Tracks.Count(t => t.Guid == guid);
					if (count > 0)
					{
						log.Report($@"{tracks[i].Guid}.mp3 - Пропущено");
						progress.Report(percentage);
						continue;
					}

					try
					{
						var audio = await _service.GetTrack(tracks[i].Url).ConfigureAwait(false);
						var result = await _ownRadio.Upload(tracks[i], audio).ConfigureAwait(false);

						log.Report(result ? $@"{tracks[i].Guid}.mp3 - Загружено" : $@"{tracks[i].Guid}.mp3 - Ошибка загрузки");

						_db.Tracks.Add(tracks[i]);
						_db.SaveChanges();
						progress.Report(percentage);
					}
					catch
					{
						log.Report($@"{tracks[i].Guid}.mp3 - Ошибка загрузки");
						_db.Tracks.Add(tracks[i]);
						_db.SaveChanges();
						progress.Report(percentage);
					}
				}
			}
			catch
			{
				log.Report(@"Ошибка загрузки треков треков");
			}
		}
	}
}
