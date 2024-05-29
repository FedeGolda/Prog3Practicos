using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Sockets;

namespace webAPI.Controllers
{
    public class AutoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAutorById(long id)
        {

        }
    }
}