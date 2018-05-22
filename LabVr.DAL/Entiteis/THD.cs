using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVr.DAL.Entiteis
{
    public class THD
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Id_user { get; set; }
        public double TermoC { get; set; }
        public double CountTermo { get; set; }
        public double YV { get; set; }
        public double YT { get; set; }
        public int DeltaT { get; set; }
        public double Ro { get; set; }
        public DateTime date { get; set; }

    }
}
