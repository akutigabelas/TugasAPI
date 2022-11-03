using API.Models;
using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;


namespace API.Models
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
        [JsonIgnore]
        public int Id { get; set; }
        public string Password { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("Role")]
        [JsonIgnore]
        public int RoleId { get; set; }

        public Role? Role { get; set; }

        public Employee? Employee { get; set; }
    }
}
