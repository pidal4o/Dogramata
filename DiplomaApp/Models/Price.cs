using System.ComponentModel.DataAnnotations;

namespace DiplomaApp.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public double PriceValue { get; set; }
        public string Element { get; set; }
    }
}
