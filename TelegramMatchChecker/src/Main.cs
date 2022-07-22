using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramMatchChecker.src
{
    class Program
    {
        static TelegramBotClient Bot = new TelegramBotClient("5413339585:AAFfNR92HX_Ng_IQLDXY8FMK-8ERqEF6v9c");
        static Config glcfg = new();


        static string Getkey(Config cfg)
        {
            return cfg.TelegramAPIKey;
        }

        static void Main(string[] args)
        {
            glcfg.Read();
            glcfg.TelegramAPIKey = "насрал";
            Bot.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync);

            Console.ReadLine();
        }
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;
            Console.WriteLine("Я спиздил апи кей! -> " + Getkey(glcfg));
            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            // Echo received message text
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken);
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}





