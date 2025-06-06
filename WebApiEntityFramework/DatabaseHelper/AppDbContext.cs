using Microsoft.EntityFrameworkCore;
using WebApiEntityFramework.Model;

namespace WebApiEntityFramework.DatabaseHelper
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options) { }

		public DbSet<Resort> Resorts { get; set; }
	}
}
