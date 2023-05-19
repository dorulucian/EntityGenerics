using EntityGenerics.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityGenerics.Data.Context
{
    public class EntityGenericsContext : DbContext
    {
        public EntityGenericsContext(DbContextOptions<EntityGenericsContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
