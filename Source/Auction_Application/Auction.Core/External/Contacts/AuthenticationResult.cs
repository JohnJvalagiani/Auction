using System;
using System.Collections.Generic;
using System.Text;

namespace Core.External.Contacts
{
    public class AuthenticationResult
    {
        public bool Saccess { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}
