using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace WebApp2.Models
{
    public class Department
    {
        public Department (int Id, string Nama, int DivisionId)
        {
            this.Id = Id;
            this.Nama = Nama;
            this.DivisionId = DivisionId;
        }

        public Department()
        {

        }

        [Key]
        public int Id { get; set; }

        public string Nama { get; set; }

        [ForeignKey("Division")]
        public int DivisionId { set; get; }

        public Division Division { set; get; }


    }
}
