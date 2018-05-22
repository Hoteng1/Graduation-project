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
    public class UnitOfWork:IUnitOfWork
    {
        ApplicationContext db;

        public UnitOfWork()
        {
            db = new ApplicationContext("DefaultConnection");
        }

        private UserRepository userRepository;
        private EDSRepository eDSRepository;
        private TermoRepository termoRepository;
        private THDRepository tHDRepository;

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<THD> THDs
        {
            get
            {
                if (tHDRepository == null)
                    tHDRepository = new THDRepository(db);
                return tHDRepository;
            }
        }

        public IRepository<EDS> EDSs
        {
            get
            {
                if (eDSRepository == null)
                    eDSRepository = new EDSRepository(db);
                return eDSRepository;
            }
        }

        public IRepository<Termo> Termoss
        {
            get
            {
                if (termoRepository == null)
                    termoRepository = new TermoRepository(db);
                return termoRepository;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;


        public void Save()
        {
            db.SaveChanges();
        }
    }
}
