using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace INNBot.Classes.Commands
{
    /// <summary>
    /// Команда вывода текстового сообщения
    /// </summary>
    class TextCommand : IBotCommand
    {
        private string name;
        public string Name => name;

        private string text;
        public string Text => text;

        public TextCommand(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        public async Task ExecuteCommand(ITelegramBotClient bot, Update update)
        {
            await bot.SendTextMessageAsync(update.Message.Chat, text, parseMode: ParseMode.Markdown);
        }
    }
}
