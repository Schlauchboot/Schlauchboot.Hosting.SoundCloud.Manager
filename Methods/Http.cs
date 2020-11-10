using System.IO;
using System.Net;

namespace Schlauchboot.Hosting.SoundCloud.Manager.Methods
{
    class Http
    {
        public string GetHttpResponseString(string uri, string parameterString)
        {
            var webRequest = WebRequest.Create(uri + parameterString);
            return PrepareHttpResponseString(webRequest);
        }

        public string GetHttpResponseString(string uri)
        {
            var webRequest = WebRequest.Create(uri);
            return PrepareHttpResponseString(webRequest);
        }

        private string PrepareHttpResponseString(WebRequest webRequest)
        {
            var webResponseStream = webRequest.GetResponse().GetResponseStream();
            var webResponseStreamReader = new StreamReader(webResponseStream);
            return webResponseStreamReader.ReadToEnd();
        }
    }
}
