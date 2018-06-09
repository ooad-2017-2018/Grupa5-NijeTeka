namespace DelfinAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KorisniciPojedinci")]
    public partial class KorisniciPojedinci
    {
        public int KorisniciPojedinciID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string JMBG { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }
    }
}
