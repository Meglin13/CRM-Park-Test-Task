using INNBot.Classes.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

class MessageHandler : IUpdateHandler
{
    private CommandManager commandManager;

    public MessageHandler(ITelegramBotClient bot)
    {
        commandManager = new CommandManager(bot);
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.Error.WriteLine(exception);
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            var command = update.Message.Text.Split(' ')[0][1..];

            await commandManager.GetCommand(command, update);
        }
    }
}