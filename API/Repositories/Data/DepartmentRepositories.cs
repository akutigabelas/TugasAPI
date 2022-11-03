using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class DepartmentRepositories : IRepository<Department, int>
    {
        private MyContextt myContexttt;

        public DepartmentRepositories(MyContextt myContextt)
        {
            myContexttt = myContextt;
        }

        public IEnumerable<Department> Get()
        {
            return myContexttt.Departments.ToList();
        }

        public Department GetById(int id)
        {

            return myContexttt.Departments.Find(id);
        }
        public int Create(Department department)
        {

            myContexttt.Departments.Add(department);
            var result = myContexttt.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = myContexttt.Departments.Find(id);
            if(data != null)
            {
                myContexttt.Remove(data);
                var result = myContexttt.SaveChanges();
                return result;
            }
            return 0;
        }
        public int Update(Department department)
        {
            myContexttt.Entry(department).State = EntityState.Modified;
            var result = myContexttt.SaveChanges();
            return result;
        }
    }
}
