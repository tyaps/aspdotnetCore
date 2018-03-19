using MessengerGateDMZ.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerGateDMZ.Model
{
    public class MessengerApiFactory : IMessengerApiFactory
    {
        public IMessengerApi Create(string messengerName, string botName, IConfigurationSection configSection) {


            switch (messengerName) {
                case "telegram": return new TelegramApi(botName, configSection);
                default: throw new Exception($"messengerName {messengerName} отсутствует в списке доступных мессенжеров");
            }
        }
    }
}
