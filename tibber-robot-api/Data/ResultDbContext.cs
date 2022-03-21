using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace tibber_robot_api.Data
{
    /// <summary>
    /// Database context for the Postgres
    /// </summary>
    public class ResultDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Executions> executions { get; set; }

        public ResultDbContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Executions>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))
            .UseSnakeCaseNamingConvention();
    }


}
