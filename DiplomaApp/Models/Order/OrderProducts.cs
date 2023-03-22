using DiplomaApp.Models.GlassPane;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaApp.Models.Order
{
    public class OrderProducts
    {
        public int GlassPaneId { get; set; }
        [ForeignKey("GlassPaneId")]
        public GlassPaneParent GlassPaneParent { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
