using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class Configuration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Pais");

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasIndex(p => p.Nombre)
            .IsUnique();
        }
    }
}