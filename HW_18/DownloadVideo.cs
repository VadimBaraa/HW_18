using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Converter;

namespace HW_18
{
    internal class DownloadVideo
    {
        public class DownloadVideoCommand : ICommand
        {
            private readonly YoutubeClient _youtubeClient;
            private readonly string _videoUrl;
            private readonly string _outputFilePath;

            public DownloadVideoCommand(YoutubeClient youtubeClient, string videoUrl, string outputFilePath)
            {
                _youtubeClient = youtubeClient;
                _videoUrl = videoUrl;
                _outputFilePath = outputFilePath;
            }

            public async Task ExecuteAsync()
            {
                Console.WriteLine("Скачивание началось...");
                await _youtubeClient.Videos.DownloadAsync(
                    _videoUrl,
                    _outputFilePath,
                    builder => builder.SetPreset(ConversionPreset.UltraFast));
                Console.WriteLine("Видео успешно скачано в файл: " + _outputFilePath);
            }
        }
    }
}
