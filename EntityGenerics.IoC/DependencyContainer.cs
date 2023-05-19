using EntityGenerics.Application.Interfaces;
using EntityGenerics.Application.Services;
using EntityGenerics.Application.ViewModels;
using EntityGenerics.Data.Repository;
using EntityGenerics.Domain.Interfaces;
using EntityGenerics.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EntityGenerics.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddScoped<IGenericInterface<ProductViewModel>, ProductService>();

            services.AddScoped<IGenericRepository<Shelf>, GenericRepository<Shelf>>();
            services.AddScoped<IGenericInterface<ShelfViewModel>, ShelfService>();

            services.AddScoped<IGenericRepository<Store>, GenericRepository<Store>>();
            services.AddScoped<IGenericInterface<StoreViewModel>, StoreService>();

            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<IGenericInterface<CategoryViewModel>, CategoryService>();
        }
    }
}
