namespace DelfinAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recepcionar")]
    public partial class Recepcionar
    {
        public int RecepcionarID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public double Plata { get; set; }

        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }
    }
}
