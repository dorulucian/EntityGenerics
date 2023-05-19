namespace EntityGenerics.Domain.Models
{
    public class Shelf : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StoreId { get; set; }

        public Store Store { get; set; }
    }
}
