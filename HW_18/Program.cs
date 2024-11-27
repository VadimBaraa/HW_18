using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Converter;
using static HW_18.InfoAboutVideo;
using static HW_18.DownloadVideo;


// Интерфейс команды
public interface ICommand
{
    Task ExecuteAsync();
}

// Инвокер для выполнения команд
public class CommandInvoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public async Task ExecuteCommandAsync()
    {
        if (_command != null)
        {
            await _command.ExecuteAsync();
        }
    }
}

// Главный класс программы
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Введите ссылку на YouTube-видео:");
        string videoUrl = Console.ReadLine();

        // Проверка ссылки
        if (string.IsNullOrWhiteSpace(videoUrl))
        {
            Console.WriteLine("Ссылка на видео не может быть пустой.");
            return;
        }

        var youtubeClient = new YoutubeClient();
        var invoker = new CommandInvoker();

        // Получение информации о видео
        var getInfoCommand = new GetVideoInfoCommand(youtubeClient, videoUrl);
        invoker.SetCommand(getInfoCommand);
        await invoker.ExecuteCommandAsync();

        // Запрос на скачивание видео
        Console.WriteLine("\nХотите скачать это видео? (да/нет):");
        string userResponse = Console.ReadLine()?.ToLower();

        if (userResponse == "да")
        {
            Console.WriteLine("Введите путь для сохранения видео (например, video.mp4):");
            string outputPath = Console.ReadLine();

            var downloadCommand = new DownloadVideoCommand(youtubeClient, videoUrl, outputPath);
            invoker.SetCommand(downloadCommand);
            await invoker.ExecuteCommandAsync();
        }

        Console.WriteLine("\nРабота завершена.");
    }
}
