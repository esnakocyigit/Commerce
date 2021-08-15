namespace Commerce.Entity
{
    public class Product : IEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}