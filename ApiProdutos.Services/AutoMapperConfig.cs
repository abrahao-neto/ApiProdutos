using ApiProdutos.Data.Entities;
using ApiProdutos.Services.Models;
using AutoMapper;

namespace ApiProdutos.Services
{
    /// <summary>
    /// Classe para configurar as transferencias de dados
    /// feitas pelo AutoMapper no projeto
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        //método construtor -> ctor + 2x[tab]
        public AutoMapperConfig()
        {
            //CategoriasPostModel >> Categoria
            CreateMap<CategoriasPostModel, Categoria>()
                .AfterMap((model, entity) =>
                {
                    entity.IdCategoria = Guid.NewGuid();
                    entity.DataHoraCriacao = DateTime.Now;
                    entity.DataHoraUltimaAlteracao = DateTime.Now;
                });

            //Categoria >> CategoriasGetModel
            CreateMap<Categoria, CategoriasGetModel>();

            //ProdutosPostModel >> Produto
            CreateMap<ProdutosPostModel, Produto>()
                .AfterMap((model, entity) =>
                {
                    entity.IdProduto = Guid.NewGuid();
                    entity.DataHoraCriacao = DateTime.Now;
                    entity.DataHoraUltimaAlteracao = DateTime.Now;
                });

            //Produto >> ProdutosGetModel
            CreateMap<Produto, ProdutosGetModel>();
        }
    }
}



