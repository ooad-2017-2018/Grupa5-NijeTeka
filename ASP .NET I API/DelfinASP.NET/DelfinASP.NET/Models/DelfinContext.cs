using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class DelfinContext: DbContext
    {
        public DelfinContext() : base("AzureConnection") { }
        //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka
        public DbSet<KorisniciPojedinci> KorisniciPojednici { get; set; }
        public DbSet<KorisniciTimovi> KorisniciTimovi { get; set; }
        public DbSet<Recepcionar> Recepcionari { get; set; }
        public DbSet<RadnikSpa> Radnicispa { get; set; }
        public DbSet<Zastitar> Zastitari { get; set; }
        public DbSet<Upravitelj> Upravitelj { get; set; }
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}