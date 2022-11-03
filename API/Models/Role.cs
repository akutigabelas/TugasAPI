using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        public Role(int Id, string Nama)
        {

            this.Id = Id;
            this.Nama = Nama;

        }

        public Role()
        {

        }
        [Key]
        public int Id { get; set; }

        public string Nama { get; set; }

    
    }
}
