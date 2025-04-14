using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace services.Response
{
    public class Error
    {
        public HttpStatusCode StatusCode {  get; set; }
        public string Message { get; set; }

        public Error(HttpStatusCode statusCode, string message)
        { StatusCode = statusCode; Message = message; }
    }
}
