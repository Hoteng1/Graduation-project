using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVr.DAL.Entiteis
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string User_special { get; set; }
        public int User_course { get; set; }
        public int User_group { get; set; }

        
    }
}
