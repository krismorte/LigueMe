using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ligueme.Models.Context.mapping
{
    public class ParametrosMapping : EntityTypeConfiguration<Parametros>
    {

        public ParametrosMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("parametros");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Chave).HasColumnName("chave");
            this.Property(t => t.Valor).HasColumnName("valor");
        }

    }
}