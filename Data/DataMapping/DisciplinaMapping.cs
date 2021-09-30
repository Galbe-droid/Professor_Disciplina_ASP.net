using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCS_Projeto_API.Model;

namespace TCS_Projeto_API.Data.DataMapping
{
    public class DisciplinaMapping : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("tb_disciplina");

            builder.Property(d => d.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(d => d.Nome)
                .HasColumnName("NOME_DISCIPLINA")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(d => d.CargaHoraria)
                .HasColumnName("CARGA_HORARIA")
                .HasColumnType("int");

            builder.Property(d => d.FoiDeletado)
                .HasColumnName("FOI_DELETADO")
                .HasColumnType("bit");
        }
    }
}
