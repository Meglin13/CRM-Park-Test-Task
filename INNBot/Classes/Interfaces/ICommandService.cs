using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace INNBot.Classes.Services
{
    public interface ICommandService<T> where T : class
    {
        public Task<T> GetService(Update update = null);
    }
}