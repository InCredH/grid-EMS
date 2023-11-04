using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ConstituentsController : BaseApiController
    {
        private readonly DataContext _context;
        public ConstituentsController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Constituent>>> GetConstituents()
        {
            return await _context.Constituents.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Constituent>> GetConstituent(Guid id)
        {
            return await _context.Constituents.FindAsync(id);
        }
    }

}