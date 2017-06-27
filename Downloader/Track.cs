using System.ComponentModel.DataAnnotations;

namespace Downloader
{
	internal class Track
	{
		[Key]
		public string Guid { get; set; }
		public string Url { get; set; }
	}
}
