using INNBot.Classes.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace INNBot.Classes.Services
{
    internal class FileService : ICommandService<string>
    {
        private string address = "https://api-fns.ru/api/vyp";
        private string request;

        // TODO: Запрос к API ФНС ЕГЮРЛ
        public async Task<string> GetService(Update update)
        {
            request = update.Message.Text.Split(' ')[1].ToString();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var apiKey = ApiKeyManager.GetApiKey("FNS_API_KEY");
                    var request = $"{address}/?q={this.request}&page=1&filter=active&key={apiKey}";

                    HttpResponseMessage responseMessage = await client.GetAsync(address);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return request;
                    }
                }
                catch (Exception e) { }

                return null;
            }
        }
    }
}