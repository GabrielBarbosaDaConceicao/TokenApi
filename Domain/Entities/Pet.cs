using Api.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Genre Genre { get; set; }
        public int BreedId { get; set; }

        [JsonIgnore]
        public virtual Breed? Breed { get; set; }

       
    }
}
