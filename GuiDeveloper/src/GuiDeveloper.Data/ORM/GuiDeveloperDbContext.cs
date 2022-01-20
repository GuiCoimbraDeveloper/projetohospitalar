using GuiDeveloper.Domain.Entities;
using GuiDeveloper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GuiDeveloper.Data.ORM
{
    public class GuiDeveloperDbContext : DbContext
    {
        public GuiDeveloperDbContext(DbContextOptions<GuiDeveloperDbContext> option) : base(option)
        {

        }

        public DbSet<Mural> Mural { get; set; }

        public DbSet<Paciente> Paciente { get; set; }
    }

    //este pedaço de codigo resolve o problema do scaffolding
    //e tambem deve resolver o problema do migration que nao encontra o dbContext, pois são projetos separados
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GuiDeveloperDbContext>
    {
        public GuiDeveloperDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../GuiDeveloper.Mvc/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<GuiDeveloperDbContext>();
            var connectionString = configuration.GetConnectionString("Default");
            builder.UseSqlServer(connectionString);
            return new GuiDeveloperDbContext(builder.Options);
        }
    }
}
