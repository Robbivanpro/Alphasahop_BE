using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlphaShop_BE.Controllers{
    [ApiController]
    [Route("api/saluti")]
    public class SalutiController : ControllerBase
    {
        [HttpGet]
        public string getSaluto()
        {
            return "\"Ciao sono il tuo nuovo controller in c#\"";
        }

        [HttpGet("{Nome}")]
        public string getSaluti(string Nome)
        {
            return string.Format("\"Saluti {0} dalla tua api in c#\"", Nome);
        }
    }
}