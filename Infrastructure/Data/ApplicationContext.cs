using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Map;
using Api.Domain.Entities;

namespace TokenApi.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { 
        }

        public DbSet<Pet>? Pets { get; set; }
        public DbSet<Breed>? Breeds { get; set; }

        
    }
}
