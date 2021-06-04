using System;
using System.Collections.Generic;
using System.Text;

namespace Crunchyroll.Api.Models
{
    public class LoginRequest : RequestBase
    {
        public LoginRequest(string locale, string sessionId, string email, string password) : base(locale, sessionId)
        {
            this.Account = email;
            this.Password = password;
        }

        public string Account { get; set; }

        public string Password { get; set; }
    }
}
