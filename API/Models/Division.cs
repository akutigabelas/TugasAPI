using System.ComponentModel.DataAnnotations;
namespace API.Models
{
    public class Division
    {
        [Key]
        public int id { get; set; }

        public string nama { get; set; }
    }
}
