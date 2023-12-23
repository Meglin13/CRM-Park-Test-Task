using INNBot.Classes.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace INNBot.Classes.Commands
{
    class CommandManager
    {
        private ITelegramBotClient bot;

        private static IBotCommand lastCommand;

        public CommandManager(ITelegramBotClient bot) => this.bot = bot;

        /* 
         Команды
            1 /start – начать общение с ботом.
            2 /help – вывести справку о доступных командах.
            3 /hello – вывести ваше имя и фамилию, ваш email и ссылку на github.
            4 /inn – получить наименования и адреса компаний по ИНН. Предусмотреть возможность
              указания нескольких ИНН за одно обращение к боту.
            5 /last – повторить последнее действие бота.
            6 /full – по ИНН выводить подробную информацию об одной
            компании, включая основной и дополнительные виды деятельности компании.
            7 /egrul, которая по ИНН компании выдаёт pdf-файл с выпиской из ЕГРЮЛ.
        */
        private List<IBotCommand> botCommands = new List<IBotCommand>()
        {
            new TextCommand("start", "Добро пожаловать в бот! Введите /help, чтобы узнать имеющиеся команды"),

            new TextCommand("hello", "*Фомина Дарья Дмитриевна*" +
                "\ndasha1385157@gmail.com" +
                "\n[GitHub](https://github.com/Meglin13/CRM-Park-Test-Task.git)"),

            new TextCommand("help",
                "\n/start – начать общение с ботом." +
                "\n/help – вывести справку о доступных командах." +
                "\n/hello – вывести ваше имя и фамилию, ваш email и ссылку на github." +
                "\n/inn – получить наименования и адреса компаний по ИНН. Предусмотреть возможность указания нескольких ИНН за одно обращение к боту." +
                //"\n/egrul – получить выписку из ЕГРЮЛ." +
                "\n/full - полная информации о компании по ИНН" +
                "\n/last – повторить последнее действие бота."),

            new INNCommand<ShortINNService, string>("inn"),

            new INNCommand<FullINNService, string>("full"),

            //new DadataCommand<FileService, string>("egrul"),

            new TextCommand("last", "Последняя команда отсутствует")
        };

        public async Task GetCommand(string commandName, Update update)
        {
            var command = botCommands.FirstOrDefault(x => x.Name == commandName);

            if (command != null)
            {
                if (command.Name == "last" && lastCommand != null)
                {
                    await lastCommand.ExecuteCommand(bot, update);
                }
                else
                {
                    await command.ExecuteCommand(bot, update);
                    lastCommand = command;
                }
            }
            else
            {
                await bot.SendTextMessageAsync(update.Message.Chat, "Неизвестная команда, используйте /help, чтобы увидеть список команд");
            }
        }
    }
}