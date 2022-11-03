using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
        public class UserRepositories : IRepository<User, int>
        {
            private readonly MyContextt myContextt;

            public UserRepositories(MyContextt contextt)
            {
                myContextt = contextt;
            }

            public IEnumerable<User> Get()
            {
                return myContextt.Users.ToList();
            }

            public User GetById(int id)
            {
                return myContextt.Users.Find(id);
            }
            public int Create(User user)
            {
                myContextt.Users.Add(user);
                var result = myContextt.SaveChanges();
                return result;
            }
            public int Update(User user)
            {
                myContextt.Entry(user).State = EntityState.Modified;
                var result = myContextt.SaveChanges();
                return result;
            }
            public int Delete(int id)
            {
                var data = myContextt.Users.Find(id);
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

