using LabVr.DAL.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVr.DAL.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<THD> THDs { get; }
        IRepository<EDS> EDSs { get; }
        IRepository<Termo> Termos { get; }
        void Save();
    }
}
