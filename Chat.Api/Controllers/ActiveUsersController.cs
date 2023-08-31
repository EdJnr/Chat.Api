using Chat.Api.Responses;
using Chat.Application.Dtos.ActiveUser;
using Chat.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActiveUsersController : ControllerBase
    {
        string ItemName = "Active User";
        private readonly IActiveUserServices _;

        public ActiveUsersController( IActiveUserServices  actives)
        {
            _ = actives;
        }


        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddActiveUser([FromBody] CreateActiveUserDto dto)
        {
            await _.CreateActiveUser(dto);

            return Accepted(ControllerResponses.Created(ItemName));
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var deleteSuccessful = await _.RemoveActiveUser(id);
            return deleteSuccessful ? Ok(ControllerResponses.Deleted(ItemName, id)) : NotFound(ControllerResponses.NotFound(ItemName, id));
        }
    }
}
