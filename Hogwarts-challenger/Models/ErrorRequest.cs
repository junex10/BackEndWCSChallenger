using System;
using System.Collections.Generic;
using System.Net;

namespace Hogwarts_request_api
{
    public class ErrorRequestFoundUser {
        public string error {get; set;}
        public int status {get; set;}
    }

    public class ErrorRequestBadQuery {
        public string error {get; set;}
        public string title {get; set;}
        public int status {get; set;}
    }
}