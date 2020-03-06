using System;
using System.Collections.Generic;
using System.Text;

namespace Corvida.API.Common
{
    public class BadRequestException : Exception
    {
        public String Code { get; }
        public String Description { get; }

        internal BadRequestException(String code, String description) : base($"Code: {code}\nDescription: {description}")
        {
            this.Code = code;
            this.Description = description;
        }

    }
}
