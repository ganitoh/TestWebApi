using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Claims;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.WebUI.Controllers
{
    [Controller]
    [Authorize]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendShipRepository _friendShipRepository;

        public UserController(
            IUserRepository userRepository,
            IFriendShipRepository friendShipRepository)
        {
            _userRepository = userRepository;
            _friendShipRepository = friendShipRepository;
        }

        [HttpGet("send-request-friend")]
        public async Task<IActionResult> SendRequestFriend([FromQuery]int userToId)
        {
            var userFromId = Convert.ToInt32(User.FindFirstValue("id")!);
            var userFrom = await _userRepository.GetAsync(userFromId);
            var userTo = await _userRepository.GetAsync(userToId);

            var friendShip = new FriendShip()
            {
                UserFrom = userFrom,
                UserTo = userTo,
                Status = FriendShipStastus.WaitResponse
            };

            await _friendShipRepository.CreateAsync(friendShip);
            return Ok();
        }

        [HttpGet("get-all-request")]
        public async Task<IActionResult> GetRequestFriends()
        {
            var userId = Convert.ToInt32(User.FindFirstValue("id"));
            var friendShipRequest = await _friendShipRepository.GetAllRequestInFriendsAsync(userId);
            return Ok(friendShipRequest.ToList());
        }

        [HttpGet("accept-request-friend")]
        public async Task<IActionResult> AcceptRequestFriend([FromQuery] int friendShipId)
        {
            await _friendShipRepository.UpdateSatatusAsync(friendShipId, FriendShipStastus.InFrined);
            return Ok();
        }

        [HttpGet("reject-request-friend")]
        public async Task<IActionResult> RejectRequestFriend([FromQuery] int friendShipId)
        {
            await _friendShipRepository.UpdateSatatusAsync(friendShipId, FriendShipStastus.Rejected);
            return Ok();
        }
    }
}
