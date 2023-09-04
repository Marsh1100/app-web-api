using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Ciudad");

            builder.Property(p => p.Id)
            .HasMaxLength(3);

            builder.Property(p => p.NombreCiu)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.Departamento)
            .WithMany(p=>p.Ciudades)
            .HasForeignKey(p=>p.IdDepFK);
        }
    }
}