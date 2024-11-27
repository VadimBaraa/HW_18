using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Converter;

namespace HW_18
{
    internal class InfoAboutVideo
    {
        public class GetVideoInfoCommand : ICommand
        {
            private readonly YoutubeClient _youtubeClient;
            private readonly string _videoUrl;

            public GetVideoInfoCommand(YoutubeClient youtubeClient, string videoUrl)
            {
                _youtubeClient = youtubeClient;
                _videoUrl = videoUrl;
            }

            public async Task ExecuteAsync()
            {
                var video = await _youtubeClient.Videos.GetAsync(_videoUrl);
                Console.WriteLine("Название видео: " + video.Title);
                Console.WriteLine("Описание: " + video.Description);
            }
        }
    }
}
