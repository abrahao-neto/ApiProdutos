using ApiProdutos.Services.Models;
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
        public IActionResult Post(ProdutosPostModel model)
        {
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Put(ProdutosPutModel model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}



