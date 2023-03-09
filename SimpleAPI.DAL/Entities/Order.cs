using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.DAL.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Order
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string ProductSku { get; set; }

        public int ProductQty { get; set; }

        public DateTime OrderedOn { get; set; }

        public int CustomerId { get; set; }
        public Customer CustomerCustomer { get; set; }
    }
}
