using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.AdminAPI.Models
{
    [Table("Roles", Schema = "User")]
    public class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; } = null!;
    }
}