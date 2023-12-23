using INNBot.Classes.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace INNBot.Classes.Commands
{
    class FileHTTPCommand : INNCommand<FileService, string>
    {
        public FileHTTPCommand(string name) : base(name)
        {

        }

        public override async Task ExecuteCommand(ITelegramBotClient bot, Update update)
        {
            string fileStream = await service.GetService(update);

            if (fileStream != null)
            {
                await bot.SendDocumentAsync(update.Message.Chat, new InputFileUrl(fileStream));
            }
            else
            {
                await bot.SendTextMessageAsync(update.Message.Chat, "Не удалось загрузить файл");
            }
        }
    }
}
