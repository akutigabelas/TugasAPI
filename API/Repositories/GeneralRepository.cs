using API.Context;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class GeneralRepository<Entity, Key> : IRepository<Entity, int>
        where Entity : class
    {
        MyContextt _context;

        public GeneralRepository(MyContextt context)
        {
            _context = context;
        }

        public int Create(Entity entity)
        {
            _context.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = GetById(id);
            _context.Set<Entity>().Remove(data);
            var result = _context.SaveChanges();
            return result;
        }

        public IEnumerable<Entity> Get()
        {
            return _context.Set<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            return _context.Set<Entity>().Find(id);
        }

        public int Update(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }
    }
}
