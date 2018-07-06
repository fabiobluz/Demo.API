using System.Collections.Generic;
using Demo.APIDistancia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Demo.APIDistancia.Repository.Config
{
    public class DemoContext : DbContext
    {

        public DbSet<UsuarioAcesso> UsuarioAcesso { get; set; }
        public DbSet<Amigo> Amigo { get; set; }
        public DbSet<CalculoHistoricoLog> CalculoHistoricoLog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DemoDistancia"));
        }

    }

}
