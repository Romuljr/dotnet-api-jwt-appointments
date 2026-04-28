using API02.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API02.Infra.Mappings
{
    public class CompromissoMap : IEntityTypeConfiguration<Compromisso>
    {
        public void Configure(EntityTypeBuilder<Compromisso> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Data).HasColumnType("date").IsRequired();
            builder.Property(c => c.Hora).HasColumnType("time").IsRequired();
            builder.Property(c => c.Descricao).HasMaxLength(500).IsRequired();

            builder.HasOne(c => c.Usuario)
                .WithMany(u => u.Compromissos).HasForeignKey(c => c.UsuarioId);
        }
    }
}
