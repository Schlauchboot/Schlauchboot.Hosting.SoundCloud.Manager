using System;
using System.Net;
using System.Text;

using Serilog;
using Newtonsoft.Json;

namespace Schlauchboot.Hosting.SoundCloud.Manager.Methods
{
    public class File
    {
        private readonly ILogger _logger;
        private readonly IPAddress _requestIp;
        private readonly string _hosterEndpoint = "https://file.io";

        public File(ILogger logger, IPAddress requestIp)
        {
            _logger = logger;
            _requestIp = requestIp;
        }

        private class CustomWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest webRequest = base.GetWebRequest(uri);
                webRequest.Timeout = 300000;
                return webRequest;
            }
        }

        public Models.File.UploadResponse UploadFile(string filePath)
        {
            var uploadTimer = new System.Timers.Timer(30000);
            uploadTimer.AutoReset = true;
            uploadTimer.Elapsed += UploadTimerElapsed;
            uploadTimer.Enabled = true;
            var webClient = new CustomWebClient();
            var responseArray = webClient.UploadFile(new Uri($"{_hosterEndpoint}?expires=1w"), filePath);
            uploadTimer.Enabled = false;
            ASCIIEncoding encoding = new ASCIIEncoding();
            return JsonConvert.DeserializeObject<Models.File.UploadResponse>(encoding.GetString(responseArray));
        }

        private void UploadTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _logger.Information(string.Join(" ", _requestIp, "The File-Upload is still going!"));
        }
    }
}
