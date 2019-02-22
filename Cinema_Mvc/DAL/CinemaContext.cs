using Cinema_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.DAL
{
    public class CinemaContext: DbContext
    {
        public CinemaContext() : base("CinemaContext")
        {

        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}