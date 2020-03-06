using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Common
{
    public class BadRequestResult
    {
        public String Code { get; set; }
        public String Description { get; set; }

        internal BadRequestResult() { }
    }
}
