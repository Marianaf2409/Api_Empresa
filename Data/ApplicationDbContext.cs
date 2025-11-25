using ApiEmpresa.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
