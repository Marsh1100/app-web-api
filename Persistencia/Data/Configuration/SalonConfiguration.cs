using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Salon");

            builder.Property(p => p.NombreSalon)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Capacidad)
            .HasColumnType("int")
            .IsRequired();

            builder
            .HasMany(p => p.Personas)
            .WithMany(p=>p.Salones)
            .UsingEntity<TrainerSalon>(
                j => j
                    .HasOne(pt => pt.Persona)
                    .WithMany(t => t.TrainerSalones)
                    .HasForeignKey(pt => pt.IdPersonaFK),
                j => j
                .HasOne(pt => pt.Salon)
                .WithMany(t => t.TrainerSalones)
                .HasForeignKey(pt => pt.IdSalonFK),
                    j=>
                    {
                        //Llave compuesta
                        j.HasKey(t => new {t.IdSalonFK, t.IdPersonaFK});
                    }
            );
        }
    }
}