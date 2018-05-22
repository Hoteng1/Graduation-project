using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVr.DAL.Entiteis
{
    public class Termo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Id_user { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double EZ { get; set; }
        public double Alpha { get; set; }
        public DateTime date { get; set; }
    }
}
