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
    /// Repositório para operações de banco de dados com Categoria
    /// </summary>
    public class CategoriaRepository
    {
        /// <summary>
        /// Inserir categoria no banco de dados
        /// </summary>
        public void Add(Categoria categoria)
        {
            //Abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                dataContext.Add(categoria);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Atualizar categoria no banco de dados
        /// </summary>
        public void Update(Categoria categoria)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(categoria).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Excluir categoria no banco de dados
        /// </summary>
        public void Delete(Categoria categoria)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(categoria);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Consultar todas as categorias do banco de dados
        /// </summary>
        public List<Categoria> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Categoria
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        /// <summary>
        /// Consultar 1 categoria no banco de dados
        /// </summary>
        public Categoria? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Categoria
                    .FirstOrDefault(c => c.IdCategoria == id);
            }
        }
    }
}



