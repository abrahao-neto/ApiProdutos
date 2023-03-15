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
    public class CategoriasController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CategoriasGetModel), 201)]
        public IActionResult Post(CategoriasPostModel model, [FromServices] IMapper mapper)
        {
            try
            {
                var categoria = mapper.Map<Categoria>(model);

                //cadastrando a categoria no banco de dados
                var categoriaRepository = new CategoriaRepository();
                categoriaRepository.Add(categoria);

                var result = mapper.Map<CategoriasGetModel>(categoria);
                return StatusCode(201, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult Put(CategoriasPutModel model, [FromServices] IMapper mapper)
        {
            try
            {
                //buscar no banco de dados a categoria através do ID
                var categoriaRepository = new CategoriaRepository();
                var categoria = categoriaRepository.GetById(model.IdCategoria.Value);

                //verificando se a categoria foi encontrada
                if (categoria != null)
                {
                    categoria.Nome = model.Nome;
                    categoria.Descricao = model.Descricao;
                    categoria.DataHoraUltimaAlteracao = DateTime.Now;

                    //atualizando no banco de dados
                    categoriaRepository.Update(categoria);

                    var result = mapper.Map<CategoriasGetModel>(categoria);
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, new { error = "Categoria não encontrada. Verifique o ID informado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult Delete(Guid? id, [FromServices] IMapper mapper)
        {
            try
            {
                //buscar no banco de dados a categoria através do ID
                var categoriaRepository = new CategoriaRepository();
                var categoria = categoriaRepository.GetById(id.Value);

                //verificando se a categoria foi encontrada
                if (categoria != null)
                {
                    //excluindo no banco de dados
                    categoriaRepository.Delete(categoria);

                    var result = mapper.Map<CategoriasGetModel>(categoria);
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, new { error = "Categoria não encontrada. Verifique o ID informado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriasGetModel>), 200)]
        public IActionResult GetAll([FromServices] IMapper mapper)
        {
            try
            {
                //consultando todas as categorias no banco de dados
                var categoriaRepository = new CategoriaRepository();
                var categorias = categoriaRepository.GetAll();

                var model = mapper.Map<List<CategoriasGetModel>>(categorias);
                return StatusCode(200, model);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult GetById(Guid? id, [FromServices] IMapper mapper)
        {
            try
            {
                //consultando 1 categoria no banco de dados através do id
                var categoriaRepository = new CategoriaRepository();
                var categoria = categoriaRepository.GetById(id.Value);

                //verificar se a categoria foi encontrada
                if (categoria != null)
                {
                    var model = mapper.Map<CategoriasGetModel>(categoria);
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



