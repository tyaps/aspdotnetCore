using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebRest.Model;

namespace WebRest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

       
        private readonly ILogger _logger;
        private readonly ITest _t;
        

        public ValuesController(ILoggerFactory logger, ITest t)
        {
          
            _logger = logger.CreateLogger("TodoApiLogger");
            _t = t;

        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogWarning(11, "Listing all items");
            _t.v1 = "aaa";
            var a = _t.v1;
            return new string[] { "value1", "value2", a };
        }

        // GET api/values/5
        //[HttpGet("{id1}")]
        //public string Get(int id1)
        //{
        //    return "value " + id1;
        //}

        // GET api/values/some1/some2
        [HttpGet("{v1}/{v2}")]
        public string Get(string v1, string v2)
        {
            var remoteIpAddress = this.HttpContext.Connection.RemoteIpAddress;

            return $"{v1} {v2} ip={remoteIpAddress}";
            //return v1 + " " + v2 + remoteIpAddress;
        }

        // POST api/values/some1/some2
        //[HttpPost("{v1}/{v2}")]
        //public string Post2(string v1, string v2)
        //{
        //    var remoteIpAddress = this.HttpContext.Connection.RemoteIpAddress;

        //    var sr = new StreamReader(this.HttpContext.Request.Body);
        //    var bodyText =  sr.ReadToEnd();



        //    return $"{v1} {v2} {bodyText} ip={remoteIpAddress}";
        //    //return v1 + " " + v2 + remoteIpAddress;
        //}

        [HttpPost("{v1}/{v2}")]
        public string SendMessageToTelegram(string v1, string v2)
        {
            var remoteIpAddress = this.HttpContext.Connection.RemoteIpAddress;

            var sr = new StreamReader(this.HttpContext.Request.Body);
            var bodyText = sr.ReadToEnd();

            var chat_id = "-283790948"; //чтоб узнать chat_id нужно послать в группу, где бот уже добавлен /my_id @ARND_Bot и сделать getUpdates
            var message = "hello from Monitoribg bot";

            var httpClient = new HttpClient();
            
            var json = $"{{\"chat_id\": \"{chat_id}\", \"text\": \"{message}\"}}";
            var botToken = "587320199:AAH2BiKD5t591o4W1z-r5QjSSlbzaZEDzGQ";

            var url = $"https://api.telegram.org/bot{botToken}/sendMessage";
            var task = GetData(url, json);
            task.Wait();
            var res = task.Result;

            //curl -X POST "https://api.telegram.org/bot587320199:AAH2BiKD5t591o4W1z-r5QjSSlbzaZEDzGQ/sendMessage" -d "chat_id=-283790948&text=my sample text"

            //StringContent js = new StringContent(json);

            //httpClient.PostAsync("http://so", js);


            return $"{v1} {v2} {bodyText} ip={remoteIpAddress} result={res}";
            //return v1 + " " + v2 + remoteIpAddress;
        }

        private async Task<string> GetData(string url, string data)
        {
            HttpClient client = new HttpClient();
            StringContent queryString = new StringContent(data, Encoding.UTF8,  "application/json");

            HttpResponseMessage response = await client.PostAsync(new Uri(url), queryString);

            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return "value111";
        }

        // POST api/values
        [HttpPost]
        [Route("test")]
        public string Post([FromBody]Test value)
        {
            return "value111";
        }

        //// GET api/values/test?id=12
        //[HttpGet("{id}")]
        //[Route("test")]
        //public string Get2(int id)
        //{
        //    // return "value";
        //    var product = new Test() { v1 = "vvv", v2 = id };
        //    Debug.WriteLine("ccc::" + JsonConvert.SerializeObject(product));
        //    return JsonConvert.SerializeObject(product);
        //}

        //[Route("test3")]
        //public JsonResult Get3()
        //{
        //    var product = new Test() { v1 = "vvv", v2 = 888 };
        //    //return JsonConvert.SerializeObject(product);
        //    return Json(product);
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
