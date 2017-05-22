using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AI.Learning.API.Interfaces;
using AI.Learning.API.Models;

namespace AI.Learning.API.Controllers
{
    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        private readonly IDictionaryService<DictionaryResult> _dict;
        
        public MessagesController(IDictionaryService<DictionaryResult> dict)
        {
            _dict = dict;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetMessage()
        {
            return Ok("Hi");
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateMessage([FromBody] Message msg)
        {
            var response = new ResponseDto();
            string dicKey = "define";
            bool hasDictTag = false;
            
            if (msg.Content.IndexOf(dicKey, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                hasDictTag = true;
                int keyIndex = msg.Content.IndexOf(dicKey, StringComparison.OrdinalIgnoreCase);
                string subString = msg.Content.ToLower().Substring(keyIndex + dicKey.Length + 1);
                
                response.DictionaryResult = await _dict.Define(subString.Split(' ').First());
            }
            if (hasDictTag && response.DictionaryResult.Results != null)
            {
                response.Message.Content += $"I've found a definition for {response.DictionaryResult.Results[0].Word}. ";
            }
            else
            {
                response.Message.Content = "I'm sorry, I didn't find any results for your request. Please be clear and remember I'm still learning.";
            }

            return Ok(response);
        }
    }
}
