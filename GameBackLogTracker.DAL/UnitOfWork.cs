using GameBackLogTracker.CORE.Interfaces;
using GameBackLogTracker.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Games> GamesRepository => throw new NotImplementedException();

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
