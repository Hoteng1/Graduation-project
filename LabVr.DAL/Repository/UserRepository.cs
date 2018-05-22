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
    public class UserRepository : IRepository<User>
    {
        ApplicationContext db;

        public UserRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {

            User user = this.db.Users.Find(id);
            if (user != null)
            {
                this.db.Users.Remove(user);
                this.db.SaveChanges();
            }
        }

        public IEnumerable<User> GetALL()
        {
            return this.db.Users.ToList();
        }

        public User GetById(int id)
        {
            return this.db.Users.Find(id);
        }

        public User Update(User item)
        {
            this.db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();

            return item;
        }
    }
}
