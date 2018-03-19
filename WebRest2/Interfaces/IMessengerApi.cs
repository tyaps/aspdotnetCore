using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerGateDMZ.Interfaces
{
    public interface IMessengerApi
    {
        string SendMessage(string messageText, string chatName);
    }
}
