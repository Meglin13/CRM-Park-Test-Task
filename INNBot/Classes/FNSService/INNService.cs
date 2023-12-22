using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace INNBot.Classes.Services
{
    class INNService : ICommandService<string>
    {
        private string address = "https://api-fns.ru/api/search";
        private string request;

        private bool isFull;

        // TODO: Запрос к API ФНС
        public INNService(string request, bool isFull = false)
        {
            this.request = request;
            this.isFull = isFull;
        }

        private Dictionary<string, string> keys = new Dictionary<string, string>()
        {
            { "Адрес", "Адрес: "},
            { "Адрес", "Адрес: "}
        };

        public async Task<string> GetService()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //TODO: Получение ключа ФНС
                    var apiKey = "222";
                    var request = $"{address}/?q={this.request}&page=1&filter=active&key={apiKey}";

                    HttpResponseMessage responseMessage = await client.GetAsync(request);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = await responseMessage.Content.ReadAsStringAsync();
                        string response = "";

                        JsonDocument jsonDoc = JsonDocument.Parse(responseData);

                        JsonElement root = jsonDoc.RootElement;

                        var length = isFull ? 10 : 2;

                        for (int i = 0; i < length; i++)
                        {
                            //TODO: обработка результата запроса
                            //if (root.TryGetProperty(keys, out JsonElement propertyValue))
                            //{
                            //    response += $"\n{propertyValue.GetString()}";

                            //}
                        }

                        return response;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: {responseMessage.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка при выполнении запроса: " + e.Message);

                }

                return null;
            }
        }
    }
}