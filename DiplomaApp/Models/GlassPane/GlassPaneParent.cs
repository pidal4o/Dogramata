using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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

    }

    public enum ProfileTypeEnum
    {
        Two,
        Three,
        Four,
        Five,
        Six
    }

    public enum ProfileTypeMaterialEnum
    {
        PVC,
        Allu,
        Wood
    }

    public enum WindowTypeEnum
    { 
        DoubleWin,
        TripleWin,
        None
    }

}
