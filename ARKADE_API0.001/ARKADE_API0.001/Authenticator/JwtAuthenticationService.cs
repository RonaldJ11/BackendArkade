using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace ARKADE_API0._001.Authenticator
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {

        //llave
        private readonly string _key;

        public JwtAuthenticationService(string key)
        {
           _key = key;
        }        

        //Authentica los tokens
        public string Authenticate(string nickName, string password)
        {

            //Valida información
            if (string.IsNullOrEmpty(nickName) || string.IsNullOrEmpty(password) || nickName != "admin" || password != "admin")
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, nickName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }
    }
}
