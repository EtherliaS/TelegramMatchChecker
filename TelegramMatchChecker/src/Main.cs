using System.Text.Json;
using TelegramMatchChecker.src;

namespace TelegramMatchChecker
{
    partial class Program
    {
        private static async Task Main(string[] args)
        {
            Config config = new();
            config.Read();
        }
    }
}