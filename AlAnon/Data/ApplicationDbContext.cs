using AlAnon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlAnon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<ApplicationUser> Miembros { get; set; }
        public DbSet<Informacion> Informacion { get; set; }

    }
}