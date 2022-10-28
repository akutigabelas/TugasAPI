using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;


namespace WebApp2.Models
{
    public class User
    {
        public User(int Id, string Password, int RoleId, int employeeId)
        {
            this.Id = Id;
            this.Password = Password;
            this.RoleId = RoleId;
            this.EmployeeId = employeeId;
        }

        public User()
        {

        }

        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }
        public string Password { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public Employee Employee { get; set; }
    }
}
