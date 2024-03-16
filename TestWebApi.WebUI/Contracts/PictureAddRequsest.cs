using System.ComponentModel.DataAnnotations;

namespace TestWebApi.WebUI.Contracts
{
    public record class PictureAddRequsest(
         [Required]IFormFile file,
         [MaxLength(200)]string description);
}
