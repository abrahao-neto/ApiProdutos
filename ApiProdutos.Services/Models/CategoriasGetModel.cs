namespace ApiProdutos.Services.Models
{
    /// <summary>
    /// Modelo de dados para a requisição de consulta de categorias
    /// </summary>

    public class CategoriasGetModel
    {
        public Guid? IdCategoria { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public DateTime? DataHoraUltimaAlteracao { get; set; }

    }
}
