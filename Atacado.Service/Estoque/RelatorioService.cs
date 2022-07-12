using Atacado.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Repository.Estoque;

namespace Atacado.Service.Estoque
{
    public class RelatorioService    
    {
        private AtacadoContext contexto;

        public RelatorioService(AtacadoContext contexto)
        {
            this.contexto = contexto;
        }

        public List<RelatorioPoco> CategoriaPorID(int idCategoria)
        {
            List<RelatorioPoco> pesquisa =
                (from cats in this.contexto.Categorias
                join subs in this.contexto.Subcategorias on cats.IdCategoria equals subs.IdCategoria
                join prods in this.contexto.Produtos on subs.IdCategoria equals prods.IdCategoria
                where cats.IdCategoria == idCategoria
                select new RelatorioPoco() 
                { 
                    IdCategoria = cats.IdCategoria,
                    DescricaoCategoria = cats.DescricaoCategoria,
                    IdSubcategoria = subs.IdSubcategoria,
                    DescricaoSubcategoria = subs.DescricaoSubcategoria,
                    IdProduto = prods.IdProduto,
                    DescricaoProduto = prods.DescricaoProduto
                }).ToList();
            return pesquisa;
        }
    }
}
