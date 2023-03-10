namespace ApiProdutos.Services.Models
{
    /// <summary>
    /// Modelo de dados para a requisição de consulta de produtos
    /// </summary>

    public class ProdutosGetModel
    {
        public Guid? IdProduto { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public DateTime? DataHoraUltimaAlteracao { get; set; }
        public CategoriasGetModel? Categoria { get; set; }

    }
}
