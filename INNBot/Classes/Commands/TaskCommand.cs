using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace INNBot.Classes.Commands
{
    class TaskCommand : IBotCommand
    {
        private string name;
        public string Name => name;

        private IBotCommand command;

        public TaskCommand(string name, IBotCommand command)
        {
            this.name = name;
            this.command = command;
        }

        public async Task ExecuteCommand(ITelegramBotClient bot, Update update)
        {
            await command.ExecuteCommand(bot, update);
        }
    }
}