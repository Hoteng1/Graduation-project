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
    public class TermoRepository : IRepository<Termo>
    {
        ApplicationContext db;

        public TermoRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(Termo item)
        {
            db.Termos.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {

            Termo item = this.db.Termos.Find(id);
            if (item != null)
            {
                this.db.Termos.Remove(item);
                this.db.SaveChanges();
            }
        }

        public IEnumerable<Termo> GetALL()
        {
            return this.db.Termos.ToList();
        }

        public Termo GetById(int id)
        {
            return this.db.Termos.Find(id);
        }

        public Termo Update(Termo item)
        {
            this.db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();

            return item;
        }
    }
}
