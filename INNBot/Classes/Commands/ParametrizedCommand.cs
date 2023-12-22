using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace INNBot.Classes.Commands
{
    /// <summary>
    /// Команда для повторяющих действий
    /// </summary>
    class ParametrizedCommand : IBotCommand
    {
        private string name;
        public string Name => name;

        private List<string> Parameters;

        private Task task;

        public ParametrizedCommand(Task task)
        {
            this.task = task;
        }

        public async Task ExecuteCommand(ITelegramBotClient bot, Update update)
        {
            foreach (var item in Parameters)
            {

            }
        }
    }
}
