using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVr.DAL.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetALL();
        T GetById(int id);
        void Create(T item);
        T Update(T item);
        void Delete(int id);
    }
}
