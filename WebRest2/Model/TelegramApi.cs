using MessengerGateDMZ.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MessengerGateDMZ.Model
{
    public class TelegramApi : IMessengerApi
    {
        private string botToken;
        private string chatId;

        private readonly string sendMessageUrl;

        private HttpClient httpClient;

        private IConfigurationSection _configSection;

        public TelegramApi(string botName, IConfigurationSection configSection)
        {
            _configSection = configSection;
            botToken = _configSection.GetSection("botTokens")[botName];

            if (string.IsNullOrEmpty(botToken))
                throw new Exception($"Не найден бот {botName}");

            httpClient = new HttpClient();

            sendMessageUrl = $"https://api.telegram.org/bot{botToken}/sendMessage";


        }
        public string SendMessage(string messengeText, string chatName) {
            var chatId = _configSection.GetSection("chats")[chatName];

            if (string.IsNullOrEmpty(chatId))
                throw new Exception($"Не найден чат {chatName}");

           
            //формируем запрос
            var json = $"{{\"chat_id\": \"{chatId}\", \"text\": \"{messengeText}\"}}";


            var res = makeJsonRequest(sendMessageUrl, json); ;


            return res;

        }

        private string makeJsonRequest(string url, string json)
        {
            
            StringContent postContent = new StringContent(json, Encoding.UTF8, "application/json");

            var res = httpClient.PostAsync(new Uri(url), postContent).Result;
            res.EnsureSuccessStatusCode();

            string responseBody =  res.Content.ReadAsStringAsync().Result;

            return responseBody;
        }
    }
}
