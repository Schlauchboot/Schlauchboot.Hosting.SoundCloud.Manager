using System;
using System.Threading.Tasks;

using FFMpegCore;
using FFMpegCore.Enums;

namespace Schlauchboot.Hosting.SoundCloud.Manager.Methods
{
    public class Ffmpeg
    {
        public async Task DownloadTrack(string trackMediaUrl, string trackFilePath)
        {
            var trackMediaUri = new Uri(trackMediaUrl);
            await FFMpegArguments.FromUrlInput(trackMediaUri)
                .OutputToFile(trackFilePath, true, options => options
                    .WithAudioCodec(AudioCodec.LibMp3Lame)
                    .UsingMultithreading(true)
                    .WithAudioBitrate(AudioQuality.VeryHigh))
                .ProcessAsynchronously();
        }
    }
}
