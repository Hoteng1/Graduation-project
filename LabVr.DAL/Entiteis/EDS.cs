using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LabVr.DAL.Entiteis
{
    public class EDS
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Id_user { get; set; }
        public int IsInclude { get; set; }
        public int Iteration { get; set; }
        public double EDSi { get; set; }
        public DateTime date { get; set; }
    }
}