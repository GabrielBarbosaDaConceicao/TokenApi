using Api.Domain.Entities;
using Api.Domain.Interfaces;
using TokenApi.Data;

namespace Infrastructure.Repository
{
    public class BreedRepository : Repository<Breed>, IBreedRepository
    {
        public BreedRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
