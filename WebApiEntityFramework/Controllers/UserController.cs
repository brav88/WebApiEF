using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEntityFramework.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		// GET: api/<UserController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		[Produces("application/xml")]
		public IActionResult Get(int id)
		{
			XDocument doc = XDocument.Load("users.xml");

			//var userfound = from user in doc.Descendants("User")
			//				.Where(a => a.Attribute("id")?.Value == id.ToString())
			//				select user;

			//var userfound = from user in doc.Descendants("User")
			//			      where user.Attribute("id")?.Value == id.ToString()
			//				  select user;

			var userfound = doc.Descendants("User")
						.FirstOrDefault(u => u.Attribute("id")?.Value == id.ToString());

			if (userfound == null)
				return NotFound();

			return Content(userfound.ToString(), "application/xml");
		}

		// POST api/<UserController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
			XElement users = new XElement("Users",
				new XElement("User",
					new XAttribute("id", 1),
					new XElement("name", "brav88"),
					new XElement("pwd", "admin$123"),
					new XElement("status", "active")
				),
			new XElement("User",
				new XAttribute("id", 2),
					new XElement("name", "john.doe"),
					new XElement("pwd", "admin$123"),
					new XElement("status", "inactive")
				)
			);

			users.Save("users.xml");
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
