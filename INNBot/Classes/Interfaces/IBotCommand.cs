using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace INNBot.Classes.Commands
{
    public interface IBotCommand
    {
        /// <summary>
        /// Код команды, пример "/start"
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Метод, выполняющий соответствующую
        /// </summary>
        /// <param name="bot">Экземпляр бота</param>
        /// <returns></returns>
        public Task ExecuteCommand(ITelegramBotClient bot, Update update);
    }
}