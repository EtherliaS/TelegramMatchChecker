using System.Text.Json;

namespace TelegramMatchChecker.src
{
    public class Config
    {
        public string? SteamAPIKey { get; set; }
        public string? TelegreamAPIKey { get; set; }
        public bool? update_data { get; set; } = false; //not working
        public bool? send_matches { get; set; } = false; //also not working

        public void Read()
        {
            FileInfo fileInfo = new FileInfo("config.json");
            if (!fileInfo.Exists)
            {
                Console.WriteLine("Config file created\nEnter Steam API key: ");
                SteamAPIKey = Console.ReadLine();
                Console.WriteLine("Enter Telegram API key:");
                TelegreamAPIKey = Console.ReadLine();
                File.WriteAllText("config.json", JsonSerializer.Serialize(this));
            }
            else
            {
                try
                {
                    var w = JsonSerializer.Deserialize<Config>(File.ReadAllText("config.json"));
                    SteamAPIKey = w.SteamAPIKey;
                    TelegreamAPIKey = w.TelegreamAPIKey;
                    send_matches = w.send_matches;
                    update_data = w.update_data;
                }
                catch (Exception)
                {
                    Console.WriteLine("Config reading error...");
                    Environment.Exit(-1);
                }
            }
            Console.WriteLine("Config file connected");

        }


    }
}
