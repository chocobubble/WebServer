using System;
using Microsoft.EntityFrameworkCore;
using WebServer.Model;

namespace WebServer.Repository
{
	public class AccountDbContext : DbContext
	{
		public AccountDbContext()
		{
		}

		public DbSet<AccountDataEntity> Account { get; set; }
		public DbSet<CharacterDataEntity> CharacterData { get; set; }
        public DbSet<WeaponDataEntity> WeaponData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=127.0.0.1; port=3306; database=accounts; user=root; password=root;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}

