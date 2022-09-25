using Api.Domain.Models.Enums;

namespace Api.Domain.Entities
{
    public class Breed
    {
        public int BreedId { get; set; }
        public string? Name { get; set; }
        public PetType PetType { get; set; }

        public IEnumerable<Pet>? Pets { get; set; }

       
    }
}
