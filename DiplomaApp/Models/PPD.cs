using System.ComponentModel.DataAnnotations;

namespace DiplomaApp.Models
{
    public class PPD
    {
        [Key]
        public int PPDId { get; set; }
        public string PPDType { get; set; }
        public double PPDWidth { get; set; }
        public double PPDPrice { get; set; }
    }
}
