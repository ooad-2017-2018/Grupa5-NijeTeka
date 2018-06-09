namespace DelfinAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DelfinModel : DbContext
    {
        public DelfinModel()
            : base("name=DelfinModel")
        {
        }

        public virtual DbSet<KorisniciPojedinci> KorisniciPojedinci { get; set; }
        public virtual DbSet<KorisniciTimovi> KorisniciTimovi { get; set; }
        public virtual DbSet<RadnikSpa> RadnikSpa { get; set; }
        public virtual DbSet<Recepcionar> Recepcionar { get; set; }
        public virtual DbSet<Upravitelj> Upravitelj { get; set; }
        public virtual DbSet<Zastitar> Zastitar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
