using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.DAL.Entities
{
    [PrimaryKey(nameof(Id))]
    public class BaseEntity
    {
        public int Id { get; set; }
    }
}
