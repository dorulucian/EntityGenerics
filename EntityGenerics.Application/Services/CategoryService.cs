using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.ViewModels;
using EntityGenerics.Domain.Interfaces;
using EntityGenerics.Domain.Models;

namespace EntityGenerics.Application.Services
{
    public class CategoryService : IGenericInterface<CategoryViewModel>
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public void CreateEntity(CategoryViewModel entity) => _repository.CreateEntity(entity.Category);

        public void DeleteEntity(CategoryViewModel entity)
        {
            entity.Category.IsDeleted = true;
            _repository.DeleteEntity(entity.Category);
        }

        public CategoryViewModel GetEntities() => new CategoryViewModel()
        {
            Categories = _repository.GetEntities()//GetEntitiesWithInclude
        };

        public CategoryViewModel GetEntityById(int id) => new CategoryViewModel()
        {
            Category = _repository.GetEntity(id)//GetEntityWithInclude
        };

        public void UpdateEntity(CategoryViewModel entity) => _repository.UpdateEntity(entity.Category);
    }
}
