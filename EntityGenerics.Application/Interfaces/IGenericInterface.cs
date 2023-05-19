namespace EntityGenerics.Application.Interfaces
{
    public interface IGenericInterface<Entity> where Entity : class
    {
        Entity GetEntities();
        Entity GetEntityById(int id);
        void CreateEntity(Entity entity);
        void UpdateEntity(Entity entity);
        void DeleteEntity(Entity entity);
    }
}
