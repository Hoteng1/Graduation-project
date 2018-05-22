using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class TableForGradirovanie
    {
        public string Name { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double EZ { get; set; }
        public double Alpha { get; set; }

        public override string ToString()
        {
            return "Метал : Сu - Ni" + Name + " T1: " + T1 + " T2: " + T2 + " ЭДС мВ: " + EZ + " Альфа: " + Alpha;
        }
    }
}
