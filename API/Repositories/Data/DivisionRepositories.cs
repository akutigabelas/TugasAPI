using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class DivisionRepositories : GeneralRepository<Division, int>
    {
        private readonly MyContextt myContextt;

        public DivisionRepositories(MyContextt contextt) : base(contextt)
        {
            myContextt = contextt;
        }

        //public IEnumerable<Division> Get()
        //{
        //    return myContextt.Divisions.ToList();
        //}

        //public Division GetById(int id)
        //{
        //    return myContextt.Divisions.Find(id);
        //}
        //public int Create(Division division)
        //{
        //    myContextt.Divisions.Add(division);
        //    var result = myContextt.SaveChanges();
        //    return result;
        //}
        //public int Update(Division division)
        //{
        //    myContextt.Entry(division).State = EntityState.Modified;
        //    var result = myContextt.SaveChanges();
        //    return result;
        //}
        //public int Delete(int id)
        //{
        //    var data = myContextt.Divisions.Find(id);
        //    if(data != null)
        //    {
        //        myContextt.Remove(data);
        //        var result = myContextt.SaveChanges();
        //        return result;
        //    }
        //    return 0;
        //}
    }
}
