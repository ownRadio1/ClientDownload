using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Downloader
{
	internal class OwnRadio
	{
		private readonly HttpClient _client;
		private readonly string _deviceId;
		
		public OwnRadio(string deviceId)
		{
			_client = new HttpClient();
			_deviceId = deviceId;
		}
		
		public async Task<bool> Upload(Track track, byte[] audio)
		{
			var form = new MultipartFormDataContent {
				{ new StringContent(track.Guid), "fileGuid" },
				{ new StringContent(track.Url), "filePath" },
				{ new StringContent(_deviceId), "deviceId" },
				{ new ByteArrayContent(audio, 0, audio.Count()), "musicFile", $"{track.Guid}.mp3" }
			};

			using (var response = await _client.PostAsync($"http://api.ownradio.ru/v3/tracks", form).ConfigureAwait(false))
			{
				return response.IsSuccessStatusCode;
			}
		}
	}
}
