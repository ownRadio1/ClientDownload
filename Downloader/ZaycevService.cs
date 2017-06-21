using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Downloader
{
	class ZaycevService
	{
		private readonly HttpClient _client = new HttpClient();
		
		public async Task<List<Track>> GetTracks(int page)
		{
			var url = $"http://zaycev.net/new/more.html?page={page}";

			var response = await _client.GetAsync(url);

			var html = await response.Content.ReadAsStringAsync();

			string pattern = @"(?<link>musicset/play/(?<guid>[\w]{32}?)/[\d]*.json?)";

			Regex regex = new Regex(pattern);
			var matches = regex.Matches(html);

			var tracks = new List<Track>();
			
			foreach (Match match in matches)
			{
				var link = match.Groups["link"].Value;
				var guid = Guid.Parse(match.Groups["guid"].Value);
				
				tracks.Add(new Track { Guid = guid.ToString(), Url = $"http://zaycev.net/{link}"});
			}
			
			return tracks;
		}

		public async Task<byte[]> GetTrack(string url)
		{
			using (var r = await _client.GetAsync(url))
			{
				string responseString = await r.Content.ReadAsStringAsync();
				var json = JsonConvert.DeserializeObject<dynamic>(responseString);
				string s = json.url;

				using (var r2 = await _client.GetAsync(s))
				{
					return await r2.Content.ReadAsByteArrayAsync();
				}
			}
		}
	}
}
