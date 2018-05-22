using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelfinBazen.Model
{
    public class Termin
    {
        private DateTime datum;

        public Termin(DateTime datum)
        {
            Datum = datum;
        }

        public DateTime Datum { get => datum; set => datum = value; }
    }
}
