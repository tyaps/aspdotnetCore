using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerGateDMZ.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebRest2.Controllers
{
    [Route("api/[controller]")]
    public class MessengerController : Controller
    {

        private readonly ILogger _logger;
        private readonly IMessengerApiFactory _messengerApiFactory;
        private readonly IConfiguration _config;


        public MessengerController(ILoggerFactory logger, IMessengerApiFactory messengerApiFactory)
        {
            _logger = logger.CreateLogger("MessengerApiLogger");
            _messengerApiFactory = messengerApiFactory;

            //как это можно вынести, чтобы было доступно во всех контроллерах
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings1.json");

            _config = builder.Build();

        }

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


        //[HttpPost("{messengerName}/{botName}/{chatName}")]
        [HttpGet("{messengerName}/{botName}/{chatName}")]
        public string SendMessageToMessenger(string messengerName, string botName, string chatName)
        {

            //var supportedMessengerNames = _config.GetSection("supportedMessengers").AsEnumerable().Skip(1).Select(x=>x.Value).ToArray();
            var botConfigSection = _config.GetSection(messengerName);

            if (botConfigSection == null)
                return $"messengerName {messengerName} doesn't exist";

            try
            {
                //создать нужного бота, назначить token. Потом вызвать событие в чат
                var messengerApi = _messengerApiFactory.Create(messengerName, botName, botConfigSection);

                var res = messengerApi.SendMessage("test", chatName);

                return "ok";
            }
            catch (Exception ex){
                return $"Exception: {ex.Message} \r\n\r\n {ex.StackTrace}";

            }
            

            

        }

    }
}
