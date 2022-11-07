using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApp2.Handlers;



namespace API.Repositories.Data
{
    public class LoginRepositories
    {
        private readonly MyContextt myContextt;

        public LoginRepositories(MyContextt contextt)
        {
            myContextt = contextt;
        }

        public ArrayList Login(string email, string password)
        {
            var data = myContextt.Users
                          .Include(x => x.Employee)
                          .Include(x => x.Role)
                          .SingleOrDefault(x => x.Employee.Email.Equals(email));
         
            if (data != null/* && Hashing.ValidatePassword(password, data.Password)*/)
            {
                // var result = myContextt.SaveChanges();
               ArrayList result = new ArrayList();
                result.Add(data.Id.ToString());
                result.Add(data.Employee.FullName);
                result.Add(data.Employee.Email);
                result.Add(data.Role.Nama);

                return result;
            }
            return null;
        }   
        
        public int Register(string fullName, string email, string birthDate, string password)
        {
            //if (myContextt.Employees.Any(x => x.Email == email)) {
            //    return 1;
            //}
            var cekemail = myContextt.Employees.SingleOrDefault(x => x.Email.Equals(email));         
            if (cekemail != null)
            {
                return 0;
            }
            else
            { 
            Employee employee = new Employee()
            {
                FullName = fullName,
                Email = email,
                BirthDate = birthDate
            };
            myContextt.Employees.Add(employee);
            var result = myContextt.SaveChanges();
                if (result > 0)
                {
                    var id = myContextt.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                    User user = new User()
                    {
                        
                        Password = Hashing.HashPassword(password),
                        RoleId = 1,
                        EmployeeId = id
                    };
                    myContextt.Users.Add(user);
                    var resultUser = myContextt.SaveChanges();
                    if(resultUser > 0)
                    {
                        return resultUser;
                    }
                }
            }
            return 0;
            
        }

        public int ChangePassword(string fullname, string passlama, string passbaru)
        {
            var data = myContextt.Users
                 .Include(x => x.Employee)
                 .SingleOrDefault(x => x.Employee.FullName.Equals(fullname));

            var validasiPass = Hashing.ValidatePassword(passlama, data.Password);
            if (data != null)
            {
                data.Password = Hashing.HashPassword(passbaru);

                myContextt.Entry(data).State = EntityState.Modified;
                var resultUser = myContextt.SaveChanges();
                if (resultUser > 0)
                {
                    return resultUser;
                }
            }

            return 0;
        }

        public int ForgotPassword(string fullname, string passlama, string passbaru)
        {
            var data = myContextt.Users
                 .Include(x => x.Employee)
                 .SingleOrDefault(x => x.Employee.FullName.Equals(fullname));
            var validasiPass = Hashing.ValidatePassword(passlama, data.Password);
            if (data != null)
            {
                data.Password = Hashing.HashPassword(passbaru);

                myContextt.Entry(data).State = EntityState.Modified;
                var resultUser = myContextt.SaveChanges();
                if (resultUser > 0)
                {
                    return resultUser;
                }
            }
            return 0;
        }

    }
}
