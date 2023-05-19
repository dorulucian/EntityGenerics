using EntityGenerics.Domain.Models;

namespace EntityGenerics.Application.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}
