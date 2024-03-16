using TestWebApi.Application.Services.Abstarction;

namespace TestWebApi.Application.Services.Implementation
{
    public class HashPassrod : IHashPassword
    {
        public string HashPassword(string password) 
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool VerifyPassword(string password, string hashPasssword)
             => BCrypt.Net.BCrypt.EnhancedVerify(password, hashPasssword);
    }
}
