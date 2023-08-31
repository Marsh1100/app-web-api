using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Matricula");

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Matriculas)
            .HasForeignKey( p => p.Id);

            builder.HasOne(p => p.Salon)
            .WithMany(p => p.Matriculas)
            .HasForeignKey(p => p.IdSalonFK);
            
        }
    }
}