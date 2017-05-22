using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI.Learning.API.Models
{
    public class ResponseDto
    {
        public Message Message { get; set; } = new Message() { CreatedBy = "Tara", Content = "" };
        public DictionaryResult DictionaryResult { get; set; } = new DictionaryResult();
    }
}