using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader
{
	internal interface ITrackService
	{
		Task<List<Track>> GetTracks(int amount);
		Task<byte[]> GetTrack(string url);
	}
}
