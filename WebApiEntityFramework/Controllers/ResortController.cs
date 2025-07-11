using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEntityFramework.DatabaseHelper;
using WebApiEntityFramework.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEntityFramework.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResortController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ResortController(AppDbContext context)
		{
			_context = context;
		}

		// GET: api/<ResortController>
		[Authorize]
		[HttpGet]
		public IQueryable<Resort> Get()
		{
			//return await _context.Resorts.ToListAsync();

			var resultados = from x in _context.Resorts							
							 select x;

			return resultados;
		}

		// GET api/<ResortController>/5
		[Authorize]
		[HttpGet("{id}")]
		public IQueryable<Resort> Get(int id)
		{
			//return await _context.Resorts.ToListAsync();
			//return await _context.Resorts.Where(r => r.Id == id).ToListAsync();

			var resultados = from x in _context.Resorts
							 where x.Id == id
							 select x;

			return resultados;
		}

		// POST api/<ResortController>
		[Authorize]
		[HttpPost]
		public IActionResult Post([FromBody] Resort value)
		{					
			_context.Resorts.Add(value);
			_context.SaveChanges();

			return Ok();
		}

		// PUT api/<ResortController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{

		}

		// DELETE api/<ResortController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
