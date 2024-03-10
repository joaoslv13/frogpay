using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Auth
{
    public class JwtSettingsOptions
    {
        public static string SessionName = "JwtSettings";
        public string Secret { get; set; } = "";
    }
}
