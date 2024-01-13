using System;
using Microsoft.EntityFrameworkCore;

namespace WebServer.Model
{
	public class AccountDbContext : DbContext
	{
		public AccountDbContext()
		{
		}

		public DbSet<AccountData> Account { get; set; }
		public DbSet<Character> CharacterData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=127.0.0.1; port=3306; database=accounts; user=root; password=root;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}

