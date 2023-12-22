using System.Threading.Tasks;

namespace INNBot.Classes.Services
{
    public interface ICommandService<T> where T : class
    {
        public Task<T> GetService();
    }
}