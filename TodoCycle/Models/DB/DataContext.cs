using Microsoft.EntityFrameworkCore;


namespace TodoCycle.Models.DB.Contexts
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
		: base(options)
		{
		}
		public DbSet<TodoItem> TodoItems { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
