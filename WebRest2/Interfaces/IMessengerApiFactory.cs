using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerGateDMZ.Interfaces
{
    public interface IMessengerApiFactory
    {
        IMessengerApi Create(string messengerName, string botName, IConfigurationSection configSection);
    }
}
