using ApiProdutos.Data.Contexts;
using ApiProdutos.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Repositories
{
    /// <summary>
    /// Repositório para operações de banco de dados com Produto
    /// </summary>
    public class ProdutoRepository
    {
        /// <summary>
        /// Inserir produto no banco de dados
        /// </summary>
        public void Add(Produto produto)
        {
            //Abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                dataContext.Add(produto);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Atualizar produto no banco de dados
        /// </summary>
        public void Update(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(produto).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Excluir produto no banco de dados
        /// </summary>
        public void Delete(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(produto);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Consultar produtos de uma categoria específica
        /// </summary>
        public List<Produto> GetAllByCategoria(Guid idCategoria)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Produto
                    .Include(p => p.Categoria)
                    .Where(p => p.IdCategoria == idCategoria)
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }

        /// <summary>
        /// Consultar 1 produto através do ID
        /// </summary>
        public Produto? GetById(Guid? idProduto)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Produto
                    .Include(p => p.Categoria)
                    .FirstOrDefault(p => p.IdProduto == idProduto);
            }
        }
    }
}



