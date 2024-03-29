using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestWebApi.Application.CQRS.FriendShips.Commands.CreateFirenedShip;
using TestWebApi.Application.CQRS.FriendShips.Commands.UpdateFriendShip;
using TestWebApi.Application.CQRS.FriendShips.Queries.GetRequestFriendShip;
using TestWebApi.Domain.Models;

namespace TestWebApi.WebUI.Controllers
{
    [Controller]
    [Authorize]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("send-request-friend")]
        public async Task<IActionResult> SendRequestFriend([FromQuery]int userToId)
        {
            var userFromId = Convert.ToInt32(User.FindFirstValue("id")!);
            await _mediator.Send(new CreateFriendShipCommand(userFromId, userToId));
            return Ok();
        }

        [HttpGet("get-all-request")]
        public async Task<IActionResult> GetRequestFriends()
        {
            var userId = Convert.ToInt32(User.FindFirstValue("id"));
            var friendShipRequest = await _mediator.Send(new GetRequestToFrieendShipCommand(userId));
            return Ok(friendShipRequest);
        }

        [HttpGet("accept-request-friend")]
        public async Task<IActionResult> AcceptRequestFriend([FromQuery] int friendShipId)
        {
            await _mediator.Send(new UpdateStatusFriendShipCommand(friendShipId,FriendShipStastus.InFrined));
            return Ok();
        }

        [HttpGet("reject-request-friend")]
        public async Task<IActionResult> RejectRequestFriend([FromQuery] int friendShipId)
        {
            await _mediator.Send(new UpdateStatusFriendShipCommand(friendShipId, FriendShipStastus.Rejected));
            return Ok();
        }
    }
}
