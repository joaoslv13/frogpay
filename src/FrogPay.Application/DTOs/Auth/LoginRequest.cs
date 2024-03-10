using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.DTOs.Auth
{
    public record LoginRequest(string Login, string Senha);
}
