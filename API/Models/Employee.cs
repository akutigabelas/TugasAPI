using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Employee
    {
        public Employee(int Id, string FullName, string Email, string BirthDate)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Email = Email;
            this.BirthDate = BirthDate;
        }

        public Employee()
        {

        }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string FullName { get; set; }
    }
}
