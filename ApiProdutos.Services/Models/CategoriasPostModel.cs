using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.Services.Models
{
    /// <summary>
    /// Modelo de dados para a requisição de cadastro de Categoria
    /// </summary>
    public class CategoriasPostModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        public string? Nome { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Descrição da categoria é obrigatório")]
        public string? Descricao { get; set; }

    }
}
