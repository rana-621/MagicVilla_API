﻿using System.Net;

namespace MagicVilla_VillaAPI.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            MessageErrors = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> MessageErrors { get; set; }
        public object Result { get; set; }
    }
}
