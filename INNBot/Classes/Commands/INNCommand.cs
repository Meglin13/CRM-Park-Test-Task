using INNBot.Classes.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace INNBot.Classes.Commands
{
    class INNCommand<T, U> : IBotCommand where T : ICommandService<U>, new() where U : class
    {
        internal string name;
        public string Name => name;

        internal ICommandService<U> service;

        public INNCommand(string name)
        {
            this.name = name;
            service = new T();
        }

        public virtual async Task ExecuteCommand(ITelegramBotClient bot, Update update)
        {
            string responce = (await service.GetService(update))?.ToString();

            if (responce == null)
            {
                responce = "Ошибка при выполненнии запроса";
            }

            await bot.SendTextMessageAsync(update.Message.Chat, responce);
        }
    }
}