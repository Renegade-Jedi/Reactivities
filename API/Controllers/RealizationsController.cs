using Application.Core;
using Application.Realizations;
using Domain.Realizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class RealizationsController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateRealization(Realization realization)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Realization = realization }));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRealization(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetRealizations()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
        [AllowAnonymous]
        [HttpGet("{id}/withPhoto")]
        public async Task<IActionResult> GetRealizationWithPhoto(Guid id)
        {
            return HandleResult(await Mediator.Send(new DetailsWithPhoto.Query { Id = id }));
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRealization(Guid id, Realization realization)
        {
            realization.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Realization = realization }));
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealization(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
