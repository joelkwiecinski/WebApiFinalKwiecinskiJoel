using Microsoft.EntityFrameworkCore;
using WebApiFinalKwiecinskiJoel.Models;

namespace WebApiFinalKwiecinskiJoel.Data
{
    public class DbHospitalAPIContext: DbContext
    {

        public DbHospitalAPIContext(DbContextOptions<DbHospitalAPIContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }

    }
}
