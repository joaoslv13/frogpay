using FrogPay.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    }
}
