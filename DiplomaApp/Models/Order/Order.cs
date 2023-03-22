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
        public OrderStatusEnum OrderStatus { get; set; }
        public IEnumerable<OrderProducts> OrderProducts { get; set; }
    }

    public enum OrderStatusEnum
    { 
        none,
        await,
        approved,
        inProgress,
        delivery,
        complete,
        rejected
    }
}
