using System.Data.Entity;
using SQLite.CodeFirst;

namespace Downloader
{
	internal class Context : DbContext
	{
		public Context()
			: base(@"trackDB")
		{
			
		}

		public DbSet<Track> Tracks { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<Context>(modelBuilder);
			Database.SetInitializer(sqliteConnectionInitializer);
		}
	}
}
