using MessengerGateDMZ.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerGateDMZ.Model
{
    public class TelegramApi : IMessengerApi
    {
        private string botToken;
        private string chatId;

        public TelegramApi(string botName, IConfigurationSection configSection)
        {

        }
        public string SendMessage(string messengeText, string chatId) {
            return "";
        }
    }
}
