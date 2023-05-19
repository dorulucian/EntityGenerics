using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using EntityGenerics.Domain.Interfaces;
using EntityGenerics.Domain.Models;

namespace EntityGenerics.Application.Services
{
    public class StoreService : IGenericInterface<StoreViewModel>
    {
        private readonly IGenericRepository<Store> _repository;
        public StoreService(IGenericRepository<Store> repository)
        {
            _repository = repository;
        }

        public void CreateEntity(StoreViewModel entity) => _repository.CreateEntity(entity.Store);

        public void DeleteEntity(StoreViewModel entity)
        {
            entity.Store.IsDeleted = true;
            _repository.DeleteEntity(entity.Store);
        }

        public StoreViewModel GetEntities() => new StoreViewModel()
        {
            Stores = _repository.GetEntities()//GetEntitiesWithInclude
        };

        public StoreViewModel GetEntityById(int id) => new StoreViewModel()
        {
            Store = _repository.GetEntity(id)//GetEntityWithInclude
        };

        public void UpdateEntity(StoreViewModel entity) => _repository.UpdateEntity(entity.Store);
    }
}
