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
    public class THDRepository : IRepository<THD>
    {
        ApplicationContext db;

        public THDRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(THD item)
        {
            db.THDs.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {

            THD item = this.db.THDs.Find(id);
            if (item != null)
            {
                this.db.THDs.Remove(item);
                this.db.SaveChanges();
            }
        }

        public IEnumerable<THD> GetALL()
        {
            return this.db.THDs.ToList();
        }

        public THD GetById(int id)
        {
            return this.db.THDs.Find(id);
        }

        public THD Update(THD item)
        {
            this.db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();

            return item;
        }
    }
}
