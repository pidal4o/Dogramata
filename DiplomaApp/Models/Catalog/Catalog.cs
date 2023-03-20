using System.ComponentModel.DataAnnotations;

namespace DiplomaApp.Models.Catalog
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
