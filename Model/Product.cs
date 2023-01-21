using System.ComponentModel.DataAnnotations;

namespace TestingEFCoreBulkExtensions.Model
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
