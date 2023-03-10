using ApiProdutos.Data.Entities;
using ApiProdutos.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Contexts
{
    /// <summary>
    /// Classe de contexto para o EntityFramework
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para configurar a conexão com o banco de dados (connectionstring)
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //mapeamento a connectionstring do banco de dados
            optionsBuilder.UseSqlServer(@"Data Source=NETO\SQLEXPRESS;Initial Catalog=BDApiProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        /// <summary>
        /// Método para adicionarmos cada classe de mapeamento criada no projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        /// <summary>
        /// Unidade de trabalho para a entidade Categoria
        /// </summary>
        public DbSet<Categoria> Categoria { get; set; }

        /// <summary>
        /// Unidade de trabalho para a entidade Produto
        /// </summary>
        public DbSet<Produto> Produto { get; set; }

    }
}



