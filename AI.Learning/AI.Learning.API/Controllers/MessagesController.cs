using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AI.Learning.API.Models;

namespace AI.Learning.API.Controllers
{
    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetMessage()
        {
            return Ok("Hi");
        }

        [HttpPost]
        [Route("")]
        public Task<IHttpActionResult> CreateMessage([FromBody] Message model)
        {
            throw new NotImplementedException();
        }
    }
}
