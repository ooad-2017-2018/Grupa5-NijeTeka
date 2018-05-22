using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelfinBazen.Model
{
    public class Paket
    {
        private string vrstaPaketa;
        private int cijena;

        public Paket(string vrstaPaketa, int cijena)
        {
            VrstaPaketa = vrstaPaketa;
            Cijena = cijena;
        }

        public string VrstaPaketa { get => vrstaPaketa; set => vrstaPaketa = value; }
        public int Cijena { get => cijena; set => cijena = value; }
    }
}
