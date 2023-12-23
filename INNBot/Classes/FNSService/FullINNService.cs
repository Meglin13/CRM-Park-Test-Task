using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace INNBot.Classes.Services
{
    class FullINNService : INNServiceBase
    {
        public override async Task<string> GetService(Update update)
        {
            var parties = await GetParties(update);

            string result = "Ничего не найдено";

            if (parties.Count > 0)
            {
                result = "Результат:";

                result += $"\n{parties[0].name.full_with_opf}" +
                    $"\n{parties[0].address.value}" +
                    $"\nКод ОКВЭД: {parties[0].okved}" +
                    $"\nРуководитель: {parties[0].management.name}" +
                    $"\n\nПРИМЕЧАНИЕ: Виды деятельности и учредители доступны только для платных тарифов";
            }

            return result;
        }
    }
}