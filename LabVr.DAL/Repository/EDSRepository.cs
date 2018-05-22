using LabVr.DAL.EF;
using LabVr.DAL.Entiteis;
using LabVr.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVr.DAL.Repository
{
    public class EDSRepository : IRepository<EDS>
    {
        ApplicationContext db;

        public EDSRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(EDS item)
        {
            db.EDs.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {

            EDS item = this.db.EDs.Find(id);
            if (item != null)
            {
                this.db.EDs.Remove(item);
                this.db.SaveChanges();
            }
        }

        public IEnumerable<EDS> GetALL()
        {
            return this.db.EDs.ToList();
        }

        public EDS GetById(int id)
        {
            return this.db.EDs.Find(id);
        }

        public EDS Update(EDS item)
        {
            this.db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();

            return item;
        }
    }
}
