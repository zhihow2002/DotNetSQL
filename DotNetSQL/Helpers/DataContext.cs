namespace DotNetSQL.Helpers;

using Microsoft.EntityFrameworkCore;
using DotNetSQL.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        //options.UseInMemoryDatabase("TestDb");
        options.UseSqlServer(Configuration.GetConnectionString("DotNetSQLDatabase"));
    }

    public DbSet<User> Users { get; set; }
}