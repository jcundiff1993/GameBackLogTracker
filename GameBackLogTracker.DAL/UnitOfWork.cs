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
        public IRepository<Games> GamesRepository { get; private set; }

        public UnitOfWork(IRepository<Games> gamesRepo)
        {
            GamesRepository = gamesRepo;
        }

        public void Commit()
        {
            GamesRepository.Commit();
        }

        public void Rollback()
        {
            GamesRepository.Rollback();
        }
    }
}
