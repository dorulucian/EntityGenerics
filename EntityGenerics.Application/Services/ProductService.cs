using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using EntityGenerics.Domain.Interfaces;
using EntityGenerics.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityGenerics.Application.Services
{
    public class ProductService : IGenericInterface<ProductViewModel>
    {
        private readonly IGenericRepository<Product> _repository;
        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public void CreateEntity(ProductViewModel entity) => _repository.CreateEntity(entity.Product);

        public void DeleteEntity(ProductViewModel entity)
        {
            entity.Product.IsDeleted = true;
            _repository.DeleteEntity(entity.Product);
        }

        public ProductViewModel GetEntities() => new ProductViewModel()
        {
            //Products = _repository.GetEntitiesWithInclude(new[] { nameof(Product.Shelf), nameof(Product.Category) })
            //Products = _repository.GetEntities()
            Products = _repository.GetEntitiesWithDelegates(p => p
                .Include(p => p.Category)
                .Include(p => p.Shelf).ThenInclude(p => p.Store))
            .Where(p => !p.IsDeleted)
        };

        public ProductViewModel GetEntityById(int id) => new ProductViewModel()
        {
            Product = _repository.GetEntity(id)//GetEntityWithInclude
        };

        public void UpdateEntity(ProductViewModel entity) => _repository.UpdateEntity(entity.Product);
    }
}
