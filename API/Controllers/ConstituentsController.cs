using Application.Constituents;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ConstituentsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Constituent>>> GetConstituents()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Constituent>> GetConstituent(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateConstituent(Constituent constituent)
        {
            await Mediator.Send(new Create.Command { Constituent = constituent });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditConstituent(Guid id, Constituent constituent)
        {
            constituent.Id = id;
            await Mediator.Send(new Edit.Command { Constituent = constituent });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstituent(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }
    }

}