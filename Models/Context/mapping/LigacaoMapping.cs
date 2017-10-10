using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ligueme.Models.Context.mapping
{
    public class LigacaoMapping : EntityTypeConfiguration<Ligacao>
    {
        public LigacaoMapping()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Telefone)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ligacao");
            this.Property(t => t.ID).HasColumnName("id");
            this.Property(t => t.DataHora).HasColumnName("data_hora");
            this.Property(t => t.Telefone).HasColumnName("telefone");
            this.Property(t => t.FilaID).HasColumnName("filaid");
        }

    }
}