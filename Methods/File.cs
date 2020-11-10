using System.Net;
using System.Text;

using Newtonsoft.Json;

namespace Schlauchboot.Hosting.SoundCloud.Manager.Methods
{
    public class File
    {
        private string hosterEndpoint { get; } = "https://file.io";

        public Models.File.UploadResponse UploadFile(string filePath)
        {
            var webClient = new WebClient();
            var responseArray = webClient.UploadFile($"{hosterEndpoint}?expires=1w", filePath);
            ASCIIEncoding encoding = new ASCIIEncoding();
            return JsonConvert.DeserializeObject<Models.File.UploadResponse>(encoding.GetString(responseArray));
        }
    }
}
