using System;
using Entidades.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Mapping.Usuarios
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios").HasKey(u => u.id);
            builder.Property(u => u.name).HasMaxLength(50);
            builder.Property(u => u.username).HasMaxLength(50);
        }
    }
}
