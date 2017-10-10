using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ligueme.Models.Context.mapping
{
    public class FilaMapping : EntityTypeConfiguration<Fila>
    {

        public FilaMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Filas");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Ramal).HasColumnName("Ramal");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }

    }
}