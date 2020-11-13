using System.IO.Compression;

namespace Schlauchboot.Hosting.SoundCloud.Manager.Methods
{
    public class Compression
    {
        public void CompressFolder(string toBeCompressedFolder, string targetDirectory)
        {
            ZipFile.CreateFromDirectory(toBeCompressedFolder, targetDirectory);
        }
    }
}
