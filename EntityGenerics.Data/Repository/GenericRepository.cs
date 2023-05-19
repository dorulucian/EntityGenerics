using EntityGenerics.Data.Context;
using EntityGenerics.Domain.Interfaces;
using EntityGenerics.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityGenerics.Data.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly EntityGenericsContext _context;

        public GenericRepository(EntityGenericsContext context)
        {
            _context = context;
        }

        public void CreateEntity(Entity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteEntity(Entity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Entity> GetEntities() => _context.Set<Entity>().AsNoTracking();

        public IEnumerable<Entity> GetEntitiesWithInclude(string[] includes)
        {
            IQueryable<Entity> entities = _context.Set<Entity>();
            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }
            return entities;
        }

        public IEnumerable<Entity> GetEntitiesWithDelegates(Func<IQueryable<Entity>, IIncludableQueryable<Entity, object>>? include = null)
        {
            var entities = _context.Set<Entity>().AsQueryable();

            if (include is not null)
                entities = include(entities);

            return entities;
        }

        public Entity GetEntity(int id) => _context.Set<Entity>().Find(id);

        public Entity GetEntityWithInclude(int id, string[] includes)
        {
            IQueryable<Entity> entities = _context.Set<Entity>();
            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }
            return entities.SingleOrDefault(p => (p as ModelBase).Id == id);
        }

        public void UpdateEntity(Entity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
