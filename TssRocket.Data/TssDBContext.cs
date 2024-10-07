using Microsoft.EntityFrameworkCore;

namespace TssRocket.Data
{
	public class TssDBContext
		: DbContext
	{
		public TssDBContext(DbContextOptions<TssDBContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TssDBContext).Assembly);
		}
	}
}
