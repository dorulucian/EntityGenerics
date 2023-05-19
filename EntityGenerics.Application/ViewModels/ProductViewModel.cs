using EntityGenerics.Domain.Models;

namespace EntityGenerics.Application.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }
    }
}
