using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;
using System.Security.Claims;
using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;
using TestWebApi.WebUI.Contracts;

namespace TestWebApi.WebUI.Controllers
{
    [Controller]
    [Authorize]
    [Route("picture")]
    public class PictureController : Controller
    {

        private readonly IPictureRepository _pictureRepository;
        private readonly IPictureService _pictureService;

        public PictureController(
            IPictureRepository pictureRepository,
            IPictureService pictureService)
        {
            _pictureRepository = pictureRepository;
            _pictureService = pictureService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPictue([FromForm]PictureAddRequsest requsest)
        {
            var fileName = requsest.file.FileName;
            var relativePath = Path.Combine("picture", fileName);
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", relativePath);

            using FileStream stream = new FileStream(fullPath, FileMode.Create);
            await requsest.file.CopyToAsync(stream);

            var picture = new Picture() { RelativePath = relativePath , Description = requsest.description};

            var userId = Convert.ToInt32(User.FindFirstValue("id"));
            await _pictureService.AddPictrue(picture, userId);
            return Ok();
        }

        [HttpGet("get-my-all")]
        public async Task<IActionResult> GetMyAllPictures()
        {
            var pictures = await _pictureRepository.GetAllAsync();
            return Ok(pictures);
        }

        [HttpGet("friends-picture")]
        public async Task<IActionResult> GetPicturesUser(int friendId)
        {
            var myId = Convert.ToInt32(User.FindFirstValue("id"));
            var pictures = await _pictureService.GetPictureFriendAsync(myId, friendId);
            return Ok(pictures);
        }
    }
}
