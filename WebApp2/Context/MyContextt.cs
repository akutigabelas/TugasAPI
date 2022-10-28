using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Models;

namespace WebApp2.Context
{
    public class MyContextt : DbContext
    {
 
        public MyContextt(DbContextOptions<MyContextt> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
