using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerGateDMZ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MessengerGateDMZ.Controllers
{
    [Route("api/[controller]")]
    public class MessengerController : Controller
    {

        private readonly ILogger _logger;
        private readonly IMessengerApiFactory _messengerApiFactory;
        private readonly IConfiguration _config;


        //public MessengerController(ILoggerFactory logger, IMessengerApiFactory messengerApiFactory)
        //{
        //    _logger = logger.CreateLogger("MessengerApiLogger");
        //    _messengerApiFactory = messengerApiFactory;

        //    //как это можно вынести, чтобы было доступно во всех контроллерах
        //    var builder = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings1.json");

        //    _config = builder.Build();

        //}

        //   /api/messenger
        //[HttpGet]
        //public JsonResult Info()
        //{
        //    return Json(_config);
        //}
        [HttpGet]
        public string Info()
        {
            return "info";
        }


        [HttpPost("{messengerName}/{botName}/{chatName}")]
        public string SendMessageToTelegram(string messengerName, string botName, string chatName)
        {

            var a = $"{_config["supportedMessengers"]}";
                return "aaa";

            //var messengerAPI = MessengerAPI.Create(messengerName, string botName, string chatName)
            //var remoteIpAddress = this.HttpContext.Connection.RemoteIpAddress;

            //var sr = new StreamReader(this.HttpContext.Request.Body);
            //var bodyText = sr.ReadToEnd();

            //var chat_id = "-283790948"; //чтоб узнать chat_id нужно послать в группу, где бот уже добавлен /my_id @ARND_Bot и сделать getUpdates
            //var message = "hello from Monitoribg bot";

            //var httpClient = new HttpClient();

            //var json = $"{{\"chat_id\": \"{chat_id}\", \"text\": \"{message}\"}}";
            //var botToken = "587320199:AAH2BiKD5t591o4W1z-r5QjSSlbzaZEDzGQ";

            //var url = $"https://api.telegram.org/bot{botToken}/sendMessage";
            //var task = GetData(url, json);
            //task.Wait();
            //var res = task.Result;

            ////curl -X POST "https://api.telegram.org/bot587320199:AAH2BiKD5t591o4W1z-r5QjSSlbzaZEDzGQ/sendMessage" -d "chat_id=-283790948&text=my sample text"




            //return $"{v1} {v2} {bodyText} ip={remoteIpAddress} result={res}";

        }
    }
}
