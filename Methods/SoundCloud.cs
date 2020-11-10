using System.Linq;

using Newtonsoft.Json;

using Schlauchboot.Hosting.SoundCloud.Manager.Models.SoundCloud;

namespace Schlauchboot.Hosting.SoundCloud.Manager.Methods
{
    public class SoundCloud
    {
        private string resolveEndpoint { get; } = "https://api-v2.soundcloud.com/resolve";

        public TrackInformation ResolveTrackUrl(string publicTrackUrl, string clientId)
        {
            var httpManager = new Http();
            var trackInformationString = httpManager.GetHttpResponseString(resolveEndpoint,
                $"?url={publicTrackUrl}&client_id={clientId}");
            return JsonConvert.DeserializeObject<TrackInformation>(trackInformationString);
        }

        public string QueryTrackMediaInformation(Transcoding[] trackTranscodings, string clientId)
        {
            return trackTranscodings
                .Where(x => x.Quality == "sq" && x.Format.MimeType.Contains("ogg") && x.Format.Protocol == "hls").FirstOrDefault()
                .Url.ToString() + $"?client_id={clientId}";
        }

        public string QueryTrackMediaUrl(string trackMediaInformationUrl)
        {
            var httpManager = new Http();
            var trackMedia = httpManager.GetHttpResponseString(trackMediaInformationUrl);
            return JsonConvert.DeserializeObject<TrackMediaInformation>(trackMedia).Url;
        }
    }
}
