using App.Domain.Core.CarModelAgg.Entities;
using App.Domain.Core.OperatorAgg.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<AppointmentRequest> AppointmentRequests { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<Operator> Operators { get; set; }
    public DbSet<RequestLog> RequestLogs { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

       
    }
}
