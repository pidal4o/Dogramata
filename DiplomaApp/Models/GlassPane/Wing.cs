using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DiplomaApp.Models.GlassPane
{
    public class Wing : Measurement
    {
        [Key]
        public int WingId { get; set; }
        public bool IsOpen { get; set; }
        public bool IsCombined { get; set; }
        public OpenDirection? OpenDirection { get; set; }

        public int GlassPaneId { get; set; }
        [ForeignKey("GlassPaneId")]
        public GlassPaneParent GlassPane { get; set; }
    }

    public enum OpenDirection
    { 
        Right,
        Left
    }

}
