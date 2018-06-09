namespace DelfinAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KorisniciTimovi")]
    public partial class KorisniciTimovi
    {
        public int KorisniciTimoviID { get; set; }

        public string ImeTima { get; set; }

        public string ImeTrenera { get; set; }

        public int BrojClanova { get; set; }

        public DateTime DatumOsnivanja { get; set; }

        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }
    }
}
