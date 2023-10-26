using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Core.Entities;

namespace Back.Infraestructure.Data
{
    public class AdminContext : IdentityDbContext<CompanyUser>
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
            
        }

        public DbSet<Organizacion> Organizacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Usuario");
            modelBuilder.Entity<IdentityRole>().ToTable("Rol");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioClaim");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuarioRol");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioLogin");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolClaim");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuarioToken");

        }
    }
}
