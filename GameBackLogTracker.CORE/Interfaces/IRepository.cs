using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.CORE.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public T Create(T Entity);
        public T ReadById(int Id);
        public List<T> ReadAll();
        public void Update(int id, T Entity);
        public void Delete(int Id);
        public void Commit();
        public void Rollback();
    }
}
