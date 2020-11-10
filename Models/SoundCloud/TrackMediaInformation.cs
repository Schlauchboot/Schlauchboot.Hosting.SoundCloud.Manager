using Newtonsoft.Json;

namespace Schlauchboot.Hosting.SoundCloud.Manager.Models.SoundCloud
{
    public partial class TrackMediaInformation
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
