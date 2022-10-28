namespace WebApp2.Models
{
    public class Role
    {

        public  Role(int Id, string Nama) {

            this.Id = Id;
            this.Nama = Nama;

        }

        public Role()
        {

        }

        public int Id { get; set; }

        public string Nama { get; set; }

    }
}
