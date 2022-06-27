using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Project.Common.Models
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
