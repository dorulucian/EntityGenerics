namespace EntityGenerics.Domain.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TestProperty { get; set; }
        public int ShelfId { get; set; }
        public int CategoryId { get; set; }

        public Shelf Shelf { get; set; }
        public Category Category { get; set; }
    }
}
