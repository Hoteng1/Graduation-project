using LabVr.DAL.Entiteis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVr.DAL.EF
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(string ConnectionString) : base(ConnectionString) { }
        public ApplicationContext() : base() { }

        public DbSet<User> Users { get; set; }
        public DbSet<EDS> EDs { get; set; }
        public DbSet<THD> THDs { get; set; }
        public DbSet<Termo> Termos { get; set; }
    }
}
