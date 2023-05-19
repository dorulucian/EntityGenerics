using Microsoft.EntityFrameworkCore.Query;

namespace EntityGenerics.Domain.Interfaces
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> GetEntities();
        IEnumerable<Entity> GetEntitiesWithInclude(string[] includes);
        IEnumerable<Entity> GetEntitiesWithDelegates(Func<IQueryable<Entity>, IIncludableQueryable<Entity, object>>? include = null);
        Entity GetEntity(int id);
        Entity GetEntityWithInclude(int id, string[] includes);
        void CreateEntity(Entity entity);
        void UpdateEntity(Entity entity);
        void DeleteEntity(Entity entity);
    }
}
