using Microsoft.EntityFrameworkCore;

namespace API_Setup_Test_Task.Models;

public class CarContext : DbContext
{

    public CarContext(DbContextOptions<CarContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }


}