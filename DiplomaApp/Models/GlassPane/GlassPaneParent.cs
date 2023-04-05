using DiplomaApp.Models.Order;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaApp.Models.GlassPane
{
    public class GlassPaneParent : Measurement
    {
        [Key]
        public int GlassPaneId { get; set; }
        public ProfileTypeEnum ProfileType { get; set; }
        public ProfileTypeMaterialEnum ProfileTypeMaterial { get; set; }
        public WindowTypeEnum WindowType { get; set; }
        public int WingsCount { get; set; } = 1;
        public List<Wing> Wings { get; set; } = new List<Wing>();

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public double? TotalPrice { get; set; }

        public IEnumerable<OrderProducts> OrderProducts { get; set; }

    }

    public enum ProfileTypeEnum
    {
        [Display(Name = "Дву камерна")]
        Two,
        [Display(Name = "Три камерна")]
        Three,
        [Display(Name = "Четири камерна")]
        Four,
        [Display(Name = "Пет камерна")]
        Five,
        [Display(Name = "Шест камерна")]
        Six
    }

    public enum ProfileTypeMaterialEnum
    {
        [Display(Name = "PVC")]
        PVC,
        [Display(Name = "Алуминий")]
        Allu,
        [Display(Name = "Дърво")]
        Wood
    }

    public enum WindowTypeEnum
    {
        [Display(Name = "Двоен стъклопакет")]
        DoubleWin,
        [Display(Name = "Троен стклопакет")]
        TripleWin,
        [Display(Name = "Нулев")]
        None
    }

}
