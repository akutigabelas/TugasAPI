using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class EmployeeRepositories : IRepository<Employee, int>
    {
        private readonly MyContextt myContextt;

        public EmployeeRepositories(MyContextt contextt)
        {
            myContextt = contextt;
        }

        public IEnumerable<Employee> Get()
        {
            return myContextt.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return myContextt.Employees.Find(id);
        }
        public int Create(Employee employee)
        {
            myContextt.Employees.Add(employee);
            var result = myContextt.SaveChanges();
            return result;
        }
        public int Update(Employee employee)
        {
            myContextt.Entry(employee).State = EntityState.Modified;
            var result = myContextt.SaveChanges();
            return result;
        }
        public int Delete(int id)
        {
            var data = myContextt.Employees.Find(id);
            if (data != null)
            {
                myContextt.Remove(data);
                var result = myContextt.SaveChanges();
                return result;
            }
            return 0;
        }
    }
}
