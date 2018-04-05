using Microsoft.EntityFrameworkCore;
using Weather.DAL.Models;

namespace Weather.DAL.Context
{
    public partial class AppDbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

    }
}