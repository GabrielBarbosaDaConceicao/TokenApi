using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Models.Enums;

namespace Infrastructure.Map
{

    public class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(pet => pet.Id);

            builder.Property(pet => pet.Name).HasMaxLength(150).IsRequired();

            builder.Property(pet => pet.Genre).IsRequired();

            builder.Property(a => a.BreedId);
            builder.HasOne(pet => pet.Breed);

           
            builder.ToTable("Pet");
        }
    }
}

