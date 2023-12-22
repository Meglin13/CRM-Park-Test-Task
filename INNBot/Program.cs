using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace INNBot
{
    class Program
    {
        private static ITelegramBotClient bot;

        private static string botKey;
        private static string fnsKey;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World! Set Telegram token");

            botKey = Console.ReadLine();

            Console.WriteLine("Hello World! Set FNS token");

            fnsKey = Console.ReadLine();

            try
            {
                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (e, a) => cts.Cancel();

                bot = new TelegramBotClient(botKey);

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