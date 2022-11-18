
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DEVVagas.ApiAuth;
using DEVVagas.Models;
using Microsoft.IdentityModel.Tokens;

public static class TokenServiceRecruiter{
    public static string GenerateToken(Recruiter user){
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
    }
}