using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Quote.Models.Api
{
    public class RefactoredResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
