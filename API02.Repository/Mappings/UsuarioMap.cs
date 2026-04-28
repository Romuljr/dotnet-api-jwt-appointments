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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // primary key
            builder.HasKey(u => u.Id);

            // campos da tabela
            builder.Property(u => u.Nome).HasMaxLength(150).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Senha).HasMaxLength(50).IsRequired();
            builder.Property(u => u.DateCriacao).IsRequired();
        }
    }
}
