using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.DAL.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
