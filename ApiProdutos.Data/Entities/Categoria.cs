using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Entities
{
    /// <summary>
    /// Modelo de entidade
    /// </summary>
    public class Categoria
    {
        private Guid? _idCategoria;
        private string? _nome;
        private string? _descricao;
        private DateTime? _dataHoraCriacao;
        private DateTime? _dataHoraUltimaAlteracao;
        private List<Produto>? _produtos;

        public Guid? IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Descricao { get => _descricao; set => _descricao = value; }
        public DateTime? DataHoraCriacao { get => _dataHoraCriacao; set => _dataHoraCriacao = value; }
        public DateTime? DataHoraUltimaAlteracao { get => _dataHoraUltimaAlteracao; set => _dataHoraUltimaAlteracao = value; }
        public List<Produto>? Produtos { get => _produtos; set => _produtos = value; }
    }
}


