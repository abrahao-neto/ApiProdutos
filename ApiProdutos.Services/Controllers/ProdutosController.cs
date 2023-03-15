using ApiProdutos.Data.Entities;
using ApiProdutos.Data.Repositories;
using ApiProdutos.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ProdutosGetModel), 201)]
        public IActionResult Post(ProdutosPostModel model, [FromServices] IMapper mapper)
        {
            try
            {
                var produto = mapper.Map<Produto>(model);

                //cadastrando no banco de dados
                var produtoRepository = new ProdutoRepository();
                produtoRepository.Add(produto);

                var result = mapper.Map<ProdutosGetModel>(produto);
                return StatusCode(201, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Put(ProdutosPutModel model, [FromServices] IMapper mapper)
        {
            try
            {
                //buscar o produto no banco de dados através do ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(model.IdProduto);

                //verificando se o produto foi encontrado
                if (produto != null)
                {
                    produto.Nome = model.Nome;
                    produto.Descricao = model.Descricao;
                    produto.Preco = model.Preco;
                    produto.Quantidade = model.Quantidade;
                    produto.IdCategoria = model.IdCategoria;
                    produto.DataHoraUltimaAlteracao = DateTime.Now;

                    //atualizando o produto no banco de dados
                    produtoRepository.Update(produto);

                    var result = mapper.Map<ProdutosGetModel>(produto);
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, new { error = "Produto não encontrado. Verifique o ID informado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Delete(Guid? id, [FromServices] IMapper mapper)
        {
            try
            {
                //buscar o produto no banco de dados através do ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(id.Value);

                //verificando se o produto foi encontrado
                if (produto != null)
                {
                    //excluindo o produto no banco de dados
                    produtoRepository.Delete(produto);

                    var result = mapper.Map<ProdutosGetModel>(produto);
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, new { error = "Produto não encontrado. Verifique o ID informado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [Route("Categoria/{idCategoria}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll(Guid? idCategoria, [FromServices] IMapper mapper)
        {
            try
            {
                //consultando os produtos de uma determinada categoria
                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.GetAllByCategoria(idCategoria.Value);

                var model = mapper.Map<List<ProdutosGetModel>>(produtos);
                return StatusCode(200, model);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid? id, [FromServices] IMapper mapper)
        {
            try
            {
                //consultando 1 produto no banco de dados através do id
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(id.Value);

                //verificar se o produto foi encontrado
                if (produto != null)
                {
                    var model = mapper.Map<ProdutosGetModel>(produto);
                    return StatusCode(200, model);
                }
                else
                {
                    return StatusCode(204); //204 -> NO CONTENT (vazio)
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }
    }
}



