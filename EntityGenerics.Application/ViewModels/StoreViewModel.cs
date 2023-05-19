using EntityGenerics.Domain.Models;

namespace EntityGenerics.Application.ViewModels
{
    public class StoreViewModel
    {
        public IEnumerable<Store> Stores { get; set; }
        public Store Store { get; set; }
    }
}
