using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dikjstra
{
    internal class Riga
    {
        string da, a;
        int costo;
        public Riga(string da, string a, int costo)
        {
            this.da = da;
            this.a = a;
            this.costo = costo;
        }

        public string Da { get => da; }
        public string A { get => a; }
        public int Costo { get => costo; set => costo = value; }
    }

}
