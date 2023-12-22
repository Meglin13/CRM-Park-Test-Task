using INNBot.Classes.Services;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace INNBot.Classes.Commands
{
    class HTTPCommand : IBotCommand
    {
        private string name;
        public string Name => name;

        private ICommandService<string> service;

        private string apiKey;

        public HTTPCommand(string name, ICommandService<string> service, string apiKey  = null)
        {
            this.name = name;
            this.service = service;
            this.apiKey = apiKey;
        }

        public async Task ExecuteCommand(ITelegramBotClient bot, Update update)
        {
            string responce = await service.GetService();

            await bot.SendTextMessageAsync(update.Message.Chat, responce, parseMode: ParseMode.Markdown);
        }
    }
}
