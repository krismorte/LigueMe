using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Ligueme.Models.Context.mapping;

namespace Ligueme.Models.Context
{
    public partial class LigueMeContext : DbContext
    {
        public DbSet<Fila> Filas { get; set; }
        public DbSet<Ligacao> Ligacoes { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        
        public LigueMeContext()
            : base("name=LigueMeContextConnection")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LigacaoMapping());
            modelBuilder.Configurations.Add(new FilaMapping());
            modelBuilder.Configurations.Add(new ParametrosMapping());    
            
        }


    }
}