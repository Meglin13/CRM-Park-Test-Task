using INNBot.Classes.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace INNBot
{
    class Program
    {
        private static ITelegramBotClient bot;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Set Telegram token");
            ApiKeyManager.SetApiKey("TELEGRAM_BOT_KEY", Console.ReadLine());

            Console.WriteLine("Set FNS token");
            ApiKeyManager.SetApiKey("FNS_API_KEY", Console.ReadLine());

            try
            {
                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (e, a) => cts.Cancel();

                bot = new TelegramBotClient(ApiKeyManager.GetApiKey("TELEGRAM_BOT_KEY"));

                if (bot != null)
                {
                    bot.StartReceiving(
                                new MessageHandler(bot),
                                new ReceiverOptions(), cancellationToken: cts.Token);

                    Console.WriteLine("Bot started. Press ^C to stop");

                    await Task.Delay(-1, cancellationToken: cts.Token);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}