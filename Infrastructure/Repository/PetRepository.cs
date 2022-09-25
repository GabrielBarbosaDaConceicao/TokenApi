using Api.Domain.Entities;
using Api.Domain.Interfaces;
using TokenApi.Data;

namespace Infrastructure.Repository
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        public PetRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
