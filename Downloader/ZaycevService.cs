using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Downloader
{
	internal class ZaycevService : ITrackService
	{
		private readonly HttpClient _client = new HttpClient();
		private readonly string _group;

		public ZaycevService(string group)
		{
			_group = group;
		}

		public async Task<List<Track>> GetTracks(int amount)
		{
			var count = amount / 50;
			if (amount % 50 != 0) count++;
			
			var tracks = new List<Track>();

			for (var page = 1; page <= count; page++)
			{
				var url = $"http://zaycev.net/{_group}/more.html?page={page}";
				//var url = $"http://zaycev.net/new/more.html?page={page}";

				var response = await _client.GetAsync(url).ConfigureAwait(false);

				var html = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				const string pattern = @"(?<link>musicset/play/(?<guid>[\w]{32}?)/[\d]*.json?)";
				var regex = new Regex(pattern);
				var matches = regex.Matches(html);

				foreach (Match match in matches)
				{
					var link = match.Groups["link"].Value;
					var guid = Guid.Parse(match.Groups["guid"].Value);

					tracks.Add(new Track { Guid = guid.ToString(), Url = $"http://zaycev.net/{link}" });
				}
			}

			return tracks;
		}

		public async Task<byte[]> GetTrack(string url)
		{
			using (var r = await _client.GetAsync(url).ConfigureAwait(false))
			{
				var responseString = await r.Content.ReadAsStringAsync().ConfigureAwait(false);
				var json = JsonConvert.DeserializeObject<dynamic>(responseString);
				string s = json.url;

				using (var r2 = await _client.GetAsync(s).ConfigureAwait(false))
				{
					return await r2.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
				}
			}
		}
	}
}
