using Dadata;
using Dadata.Model;
using INNBot.Classes.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace INNBot.Classes.Services
{
    abstract class INNServiceBase : ICommandService<string>
    {
        public abstract Task<string> GetService(Update update);

        internal async Task<List<Party>> GetParties(Update update)
        {
            var apiKey = ApiKeyManager.GetApiKey("FNS_API_KEY");
            string[] inns = update.Message.Text.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[1..];

            if (inns.Length == 0)
            {
                return null;
            }

            var responses = new List<Party>();

            foreach (var inn in inns)
            {
                var api = new SuggestClientAsync(apiKey);
                var response = await api.FindParty(inn);

                if (response.suggestions.Count > 0)
                {
                    responses.Add(response.suggestions[0].data);
                }
            }

            return responses;
        }
    }
}