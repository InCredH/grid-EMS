using Application.Constituents;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ConstituentsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetConstituents()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConstituent(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateConstituent(Constituent constituent)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Constituent = constituent }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditConstituent(Guid id, Constituent constituent)
        {
            constituent.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Constituent = constituent }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstituent(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }

}