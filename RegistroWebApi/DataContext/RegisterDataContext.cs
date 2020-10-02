using Microsoft.EntityFrameworkCore;
using RegistroWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroWebApi.DataContext
{
    public class RegisterDataContext : DbContext
    {
        public RegisterDataContext(DbContextOptions<RegisterDataContext> options) 
            : base(options) {}

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Ciudadano> Ciudadanos { get; set; }
    }
}
