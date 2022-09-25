using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Models.Enums;

namespace Infrastructure.Map
{
    public class BreedMap : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasKey(a => a.BreedId);

            builder.Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.PetType)
                .IsRequired();

           

            builder.ToTable("Breed");

        }
    }

}
