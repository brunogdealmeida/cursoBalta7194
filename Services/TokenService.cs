using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Shop.Models;
using Microsoft.IdentityModel.Tokens;

namespace Shop.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            //objeto responsavel por gerar o token
            var tokenHandler = new JwtSecurityTokenHandler();
            //Chave secreta utilizada para geração dos tokens
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            //Descrição do que há dentro do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //Manda o tokenhandler gerar o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //gera a string do Token
            return tokenHandler.WriteToken(token);
        }
    }
}