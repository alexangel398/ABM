using Microsoft.EntityFrameworkCore;
using ABMProveedores.Models;
using System.Collections.Generic;

namespace ABMProveedores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proveedor> Proveedores { get; set; }
    }
}
