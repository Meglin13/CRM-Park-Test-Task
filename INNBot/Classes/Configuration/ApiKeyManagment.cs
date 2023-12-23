using System;

namespace INNBot.Classes.Configuration
{
    static class ApiKeyManager
    {
        public static string GetApiKey(string keyName)
        {
            string apiKey = Environment.GetEnvironmentVariable(keyName);
            return apiKey;
        }

        public static void SetApiKey(string keyName, string apiKey)
        {
            Environment.SetEnvironmentVariable(keyName, apiKey);
        }
    }
}
