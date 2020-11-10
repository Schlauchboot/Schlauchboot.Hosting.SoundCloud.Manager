namespace Schlauchboot.Hosting.SoundCloud.Manager.Models.File
{
    public class UploadResponse
    {
        public bool success { get; set; }
        public string key { get; set; }
        public string link { get; set; }
        public string expiry { get; set; }
    }
}
