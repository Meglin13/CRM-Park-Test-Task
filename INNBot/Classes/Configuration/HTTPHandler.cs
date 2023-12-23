using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace INNBot.Classes.Configuration
{
    class HTTPHandler
    {
        public async Task<HttpResponseMessage> GetResposce(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responseMessage = await client.GetAsync(request);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return responseMessage;
                    }
                }
                catch (Exception e) { }

                return null;
            }
        }
    }
}