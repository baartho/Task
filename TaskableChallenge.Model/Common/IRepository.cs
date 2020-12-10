using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskableChallenge.Model.Common
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
