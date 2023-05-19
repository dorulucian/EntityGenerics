using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using EntityGenerics.Domain.Interfaces;
using EntityGenerics.Domain.Models;

namespace EntityGenerics.Application.Services
{
    public class ShelfService : IGenericInterface<ShelfViewModel>
    {
        private readonly IGenericRepository<Shelf> _repository;
        public ShelfService(IGenericRepository<Shelf> repository)
        {
            _repository = repository;
        }

        public void CreateEntity(ShelfViewModel entity) => _repository.CreateEntity(entity.Shelf);

        public void DeleteEntity(ShelfViewModel entity)
        {
            entity.Shelf.IsDeleted = true;
            _repository.DeleteEntity(entity.Shelf);
        }

        public ShelfViewModel GetEntities() => new ShelfViewModel()
        {
            //Shelves = _repository.GetEntitiesWithInclude(new[] { "Store" })
            Shelves = _repository.GetEntities()
        };

        public ShelfViewModel GetEntityById(int id) => new ShelfViewModel()
        {
            //Shelf = _repository.GetEntityWithInclude(id, new[] { "Store" })
        };

        public void UpdateEntity(ShelfViewModel entity) => _repository.UpdateEntity(entity.Shelf);
    }
}
