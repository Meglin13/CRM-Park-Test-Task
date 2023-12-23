using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace INNBot.Classes.Commands
{
    class TaskCommand : IBotCommand
    {
        private string name;
        public string Name => name;

        private Task task;

        public TaskCommand(string name, Task task)
        {
            this.name = name;
            this.task = task;
        }

        public async Task ExecuteCommand(ITelegramBotClient bot, Update update)
        {
            if (task != null)
            {
                await task;
            }
        }
    }
}