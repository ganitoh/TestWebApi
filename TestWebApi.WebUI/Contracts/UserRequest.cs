using System.ComponentModel.DataAnnotations;

namespace TestWebApi.WebUI.Contracts
{
    public record class UserRequest(
        [Required] string login, 
        [Required] string password);
}
