using ApiProdutos.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Categoria
    /// </summary>
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //nome da tabela
            builder.ToTable("CATEGORIA");

            //chave primária
            builder.HasKey(c => c.IdCategoria);

            //mapeamento dos campos
            builder.Property(c => c.IdCategoria)
                .HasColumnName("IDCATEGORIA");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.DataHoraCriacao)
                .HasColumnName("DATAHORACRIACAO")
                .IsRequired();

            builder.Property(c => c.DataHoraUltimaAlteracao)
                .HasColumnName("DATAHORAULTIMAALTERACAO")
                .IsRequired();
        }
    }
}



