using System.ComponentModel.DataAnnotations;

namespace DiplomaApp.Models.Catalog
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
