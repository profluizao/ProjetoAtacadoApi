using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRebanho"></param>
        /// <returns></returns>
        [HttpGet("fichacadastral/{idRebanho:int}")]
        public ActionResult<object> Get(int idRebanho)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from rebs in contexto.Rebanhos
                    where rebs.IdRebanho == idRebanho
                    join muns in contexto.Municipios on rebs.IdMunicipio equals muns.CodigoIbge7
                    join ufs in contexto.UnidadesFederacaos on muns.SiglaUf equals ufs.SiglaUf
                    select new
                    {
                        IdRebanho = rebs.IdRebanho,
                        AnoReferencia = rebs.AnoRef,
                        IdMunicipio = rebs.IdMunicipio,
                        NomeMunicipio = muns.NomeMunicipio,
                        SiglaUF = ufs.SiglaUf,
                        NomeEstado = ufs.DescricaoUf,
                        IdTipoRebanho = rebs.IdTipoRebanho,
                        NomeRebanho = rebs.TipoRebanho,
                        Quantidade = rebs.Quantidade,
                        Situacao = rebs.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anoRef"></param>
        /// <param name="codigoIbge7"></param>
        /// <returns></returns>
        [HttpGet("pesquisaPorAnoRefIbge7/{anoRef:int}/{codigoIbge7:int}")]
        public ActionResult<List<RebanhoPoco>> Get(int anoRef, int codigoIbge7)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from rebs in contexto.Rebanhos
                    where (rebs.AnoRef == anoRef) && (rebs.IdMunicipio == codigoIbge7)
                    join muns in contexto.Municipios on rebs.IdMunicipio equals muns.CodigoIbge7
                    join ufs in contexto.UnidadesFederacaos on muns.SiglaUf equals ufs.SiglaUf
                    select new
                    {
                        IdRebanho = rebs.IdRebanho,
                        AnoReferencia = rebs.AnoRef,
                        IdMunicipio = rebs.IdMunicipio,
                        NomeMunicipio = muns.NomeMunicipio,
                        SiglaUF = ufs.SiglaUf,
                        NomeEstado = ufs.DescricaoUf,
                        IdTipoRebanho = rebs.IdTipoRebanho,
                        NomeRebanho = rebs.TipoRebanho,
                        Quantidade = rebs.Quantidade,
                        Situacao = rebs.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza busca do relatorio por Codigo(IdCat).
        /// </summary>
        /// <param name="IdCat">Codigo de registro</param>
        /// <returns></returns>
        [HttpGet("Categoria/PorID/{IdCat:int}")]
        public ActionResult<List<object>> GetPorCategoria(int IdCat)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from cats in contexto.Categorias
                    where cats.IdCategoria == IdCat
                    join subs in contexto.Subcategorias on cats.IdCategoria equals subs.IdCategoria
                    join prots in contexto.Produtos on subs.IdSubcategoria equals prots.IdSubcategoria
                    select new
                    {
                        IdCategoria = cats.IdCategoria,
                        NomeCategoria = cats.DescricaoCategoria,
                        IdSubcategoria = subs.IdSubcategoria,
                        NomeSubcategoria = subs.DescricaoSubcategoria,
                        IdProduto = prots.IdProduto,
                        NomeProduto = prots.DescricaoProduto,
                        Situacao = prots.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// Realiza busca do relatorio por Codigo(IdSub).
        /// </summary>
        /// <param name="IdSub">Codigo de registro</param>
        /// <returns></returns>
        [HttpGet("Subcategoria/PorID/{IdSub:int}")]
        public ActionResult<List<object>> GetPorSubcategoria(int IdSub)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from subs in contexto.Subcategorias
                    where subs.IdSubcategoria == IdSub
                    join cats in contexto.Categorias on subs.IdCategoria equals cats.IdCategoria
                    join prots in contexto.Produtos on subs.IdSubcategoria equals prots.IdSubcategoria

                    select new
                    {
                        IdCategoria = cats.IdCategoria,
                        NomeCategoria = cats.DescricaoCategoria,
                        IdSubcategoria = subs.IdSubcategoria,
                        NomeSubcategoria = subs.DescricaoSubcategoria,
                        IdProduto = prots.IdProduto,
                        NomeProduto = prots.DescricaoProduto,
                        Situacao = prots.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdProt"></param>
        /// <returns></returns>
        [HttpGet("Produto/PorID/{IdProt:int}")]
        public ActionResult<List<object>> GetPorProduto(int IdProt)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from prots in contexto.Produtos
                    where prots.IdProduto == IdProt
                    join subs in contexto.Subcategorias on prots.IdSubcategoria equals subs.IdSubcategoria
                    join cats in contexto.Categorias on subs.IdCategoria equals cats.IdCategoria


                    select new
                    {
                        IdCategoria = cats.IdCategoria,
                        NomeCategoria = cats.DescricaoCategoria,
                        IdSubcategoria = subs.IdSubcategoria,
                        NomeSubcategoria = subs.DescricaoSubcategoria,
                        IdProduto = prots.IdProduto,
                        NomeProduto = prots.DescricaoProduto,
                        Situacao = prots.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
