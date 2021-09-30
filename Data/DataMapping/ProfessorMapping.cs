using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCS_Projeto_API.Model;

namespace TCS_Projeto_API.Data.DataMapping
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("tb_professor");

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(p => p.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("varchar")
                .HasMaxLength(90);

            builder.Property(p => p.Senha)
                .HasColumnName("SENHA")
                .HasColumnType("varchar")
                .HasMaxLength(25);

            builder.Property(p => p.FoiExcluido)
                .HasColumnName("FOI_EXCLUIDO")
                .HasColumnType("bit");
        }
    }
}
