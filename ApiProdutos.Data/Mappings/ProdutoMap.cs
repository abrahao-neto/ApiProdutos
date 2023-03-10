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
    /// Classe de mapeamento para a entidade Produto
    /// </summary>
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //nome da tabela
            builder.ToTable("PRODUTO");

            //chave primária
            builder.HasKey(p => p.IdProduto);

            //mapeamento dos campos
            builder.Property(p => p.IdProduto)
                .HasColumnName("IDPRODUTO");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(p => p.IdCategoria)
                .HasColumnName("IDCATEGORIA")
                .IsRequired();

            builder.Property(p => p.DataHoraCriacao)
                .HasColumnName("DATAHORACRIACAO")
                .IsRequired();

            builder.Property(p => p.DataHoraUltimaAlteracao)
                .HasColumnName("DATAHORAULTIMAALTERACAO")
                .IsRequired();

            //Mapeamento do relacionamento
            builder.HasOne(p => p.Categoria) //Produto TEM 1 Categoria
                .WithMany(c => c.Produtos) //Categoria TEM MUITOS Produtos
                .HasForeignKey(p => p.IdCategoria); //Chave estrangeira
        }
    }
}



