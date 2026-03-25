using GameBackLogTracker.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.CORE.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Games> GamesRepository { get; }
        public void Commit();
        public void Rollback();
    }
}
