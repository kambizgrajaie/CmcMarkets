using System;

namespace CmcMarkets.Backend.Core.Model
{
    public class UserLoginResponse
    {
        public string Token { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
