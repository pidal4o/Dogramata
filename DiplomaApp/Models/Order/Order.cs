using System.ComponentModel.DataAnnotations;

namespace DiplomaApp.Models.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? OrderDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public List<OrderProducts> OrderProducts { get; set; } = new List<OrderProducts>();
    }

    public enum OrderStatusEnum
    { 
        none,
        awaiting,
        approved,
        inProgress,
        delivery,
        complete,
        rejected
    }
}
