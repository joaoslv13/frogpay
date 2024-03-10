using FrogPay.Application.DTOs.Auth;
using FrogPay.Application.Interfaces;
using FrogPay.Application.Shared;
using FrogPay.Application.Shared.Notifications;
using FrogPay.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FrogPay.Auth
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettingsOptions _jwtSettingsOptions;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly INotificationHandler _notificationHandler;

        public AuthService(JwtSettingsOptions jwtSettingsOptions, IUsuarioRepository usuarioRepository, INotificationHandler notificationHandler)
        {
            _jwtSettingsOptions = jwtSettingsOptions;
            _usuarioRepository = usuarioRepository;
            _notificationHandler = notificationHandler;
        }

        public async Task<string?> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByLoginAsync(request.Login, cancellationToken);

            if (usuario == null || usuario.Senha != CryptoHelper.ConvertToMD5(request.Senha))
            {
                _notificationHandler.AddNotification(new Notification("Usuario/senha invalidos", NotificationLevel.Error));
                return null;
            }

            return GenerateToken(usuario.Id);

        }

        private string GenerateToken(Guid userId)
        {
            var secretTeste = _jwtSettingsOptions.Secret;

            var byteSecret = Encoding.UTF8.GetBytes(secretTeste!);

            var secretKey = new SigningCredentials(
                new SymmetricSecurityKey(byteSecret),
                SecurityAlgorithms.HmacSha256);

            var userIdClaim =
                new Claim(ClaimTypes.NameIdentifier,
                    userId.ToString().ToUpperInvariant());

            var expiration = TimeSpan.FromMinutes(5);

            var securityToken = new JwtSecurityToken(
                signingCredentials: secretKey,
                claims: [userIdClaim],
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.Add(expiration));

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
