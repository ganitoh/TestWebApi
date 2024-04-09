using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestWebApi.Application.CQRS.Pictures.Queries.GetAllPicturesByUser;
using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;
using TestWebApi.WebUI.Contracts;
using TestWebApi.Application.CQRS.Pictures.Commands.PictureCreate;

namespace TestWebApi.WebUI.Controllers
{
    [Controller]
    [Authorize]
    [Route("picture")]
    public class PictureController : Controller
    {

        private readonly IPictureService _pictureService;
        private readonly IMediator _mediator;

        public PictureController(
            IPictureService pictureService,
            IMediator mediator)
        {
            _pictureService = pictureService;
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPictue([FromForm]PictureAddRequsest requsest)
        {
            var fileName = requsest.file.FileName;
            var relativePath = Path.Combine("picture", fileName);
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", relativePath);

            using FileStream stream = new FileStream(fullPath, FileMode.Create);
            await requsest.file.CopyToAsync(stream);

            await _pictureService.AddPictrue(
                new PictureCreateCommand(requsest.description,relativePath, Convert.ToInt32(User.FindFirstValue("id"))));
            return Ok();
        }

        [HttpGet("get-my-all")]
        public async Task<IActionResult> GetMyAllPictures()
        {
            var userId = Convert.ToInt32(User.FindFirstValue("id"));
            var pictures = await _mediator.Send(new GetAllPicturesByUserQuerie(userId));
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
