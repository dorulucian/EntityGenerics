using EntityGenerics.Domain.Models;

namespace EntityGenerics.Application.ViewModels
{
    public class ShelfViewModel
    {
        public IEnumerable<Shelf> Shelves { get; set; }
        public Shelf Shelf { get; set; }
    }
}
