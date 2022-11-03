using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class HomeRepositories : IRepository<Role, int>
    {
        private readonly MyContextt myContextt;

        public HomeRepositories(MyContextt contextt)
        {
            myContextt = contextt;
        }

        public IEnumerable<Role> Get()
        {
            return myContextt.Roles.ToList();
        }

        public Role GetById(int id)
        {
            return myContextt.Roles.Find(id);
        }
        public int Create(Role role)
        {
            myContextt.Roles.Add(role);
            var result = myContextt.SaveChanges();
            return result;
        }
        public int Update(Role role)
        {
            myContextt.Entry(role).State = EntityState.Modified;
            var result = myContextt.SaveChanges();
            return result;
        }
        public int Delete(int id)
        {
            var data = myContextt.Roles.Find(id);
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

