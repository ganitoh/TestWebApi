namespace TestWebApi.Application.Services.Abstarction
{
    public interface IHashPassword
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashPasssword);
    }
}
