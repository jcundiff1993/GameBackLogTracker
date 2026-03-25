using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.CORE.Interfaces
{
    public interface IMapper <T>
    {
        T Deserialize (string input);
        string Serialize (T entity);
    }
}
