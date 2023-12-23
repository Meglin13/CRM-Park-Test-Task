using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace INNBot.Classes.Services
{
    class ShortINNService : INNServiceBase
    {
        public override async Task<string> GetService(Update update)
        {
            var parties = await GetParties(update);

            string result = "Ничего не найдено";

            if (parties.Count > 0)
            {
                result = "Результат:";

                foreach (var item in parties)
                {
                    result += $"\n{item.name.full_with_opf}\n{item.address.value}\n";
                }
            }

            return result;
        }
    }
}