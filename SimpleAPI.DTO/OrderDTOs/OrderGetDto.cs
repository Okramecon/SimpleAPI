namespace SimpleAPI.DTO.OrderDTOs
{
    public class OrderGetDto
    {

        public int Id { get; set; }

        public string ProductSku { get; set; }

        public int ProductQty { get; set; }

        public DateTime OrderedOn { get; set; }

        public int CustomerId { get; set; }
    }
}
