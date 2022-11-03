using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class LoginRepositories
    {

        private MyContextt myContextt;

        public LoginRepositories(MyContextt myContextt)
        {
            this.myContextt = myContextt;
        }

    }
}
