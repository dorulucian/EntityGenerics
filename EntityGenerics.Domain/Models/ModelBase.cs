namespace EntityGenerics.Domain.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
