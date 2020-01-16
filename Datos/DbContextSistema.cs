using System;
using Datos.Mapping.Usuarios;
using Entidades.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class DbContextSistema: DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
