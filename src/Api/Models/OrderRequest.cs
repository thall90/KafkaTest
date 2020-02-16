using Api.Models.Enums;

namespace Api.Models
{
    public class OrderRequest
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }
    }
}