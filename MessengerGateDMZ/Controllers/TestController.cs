﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MessengerGateDMZ.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public string Index()
        {
            return "rwsr";
        }
    }
}