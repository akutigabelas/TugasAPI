using Microsoft.AspNetCore.Mvc.Rendering;
namespace WebApp2.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int DivisionId { get; set; }

        public List<SelectListItem> Divisions { get; set; }
    }
}
