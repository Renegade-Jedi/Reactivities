using System;
using System.Threading.Tasks;
using Application.Photos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhotosController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("{id}/RealizationPhoto")]
        public async Task<IActionResult> AddRealizationPhoto([FromForm] AddRealizationPhoto.Command command, Guid id)
        {
            command.RealizationId = id;
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [AllowAnonymous]
        [HttpDelete("{id}/RealizationPhoto")]
        public async Task<IActionResult> DeleteRealizationPhoto(string id)
        {
            return HandleResult(await Mediator.Send(new DeleteRealizationPhoto.Command { Id = id }));
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMain(string id)
        {
            return HandleResult(await Mediator.Send(new SetMain.Command{Id = id}));
        }
    }
}