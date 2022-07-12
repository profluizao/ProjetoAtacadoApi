using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;

namespace Atacado.Service.Auxiliar
{
    public class RelatorioAquiculturaService
    {
        private AtacadoContext contexto;

        public RelatorioAquiculturaService(AtacadoContext contexto)
        {
            this.contexto = contexto;
        }

        public List<RelatorioAquiculturaPoco> PesquisarPorIdMunicipioAnoProducaoNaoNula(int idMunicipio, int ano)
        {
            List<RelatorioAquiculturaPoco> pesquisa =
                (from aquis in this.contexto.Aquiculturas
                 join tipos in this.contexto.TipoAquiculturas on aquis.IdTipoAquicultura equals tipos.IdTipoAquicultura
                 join muns in this.contexto.Municipios on aquis.IdMunicipio equals muns.CodigoIbge7
                 join ufs in this.contexto.UnidadesFederacaos on muns.SiglaUf equals ufs.SiglaUf
                 where (aquis.IdMunicipio == idMunicipio)
                 && (aquis.Ano == ano) 
                 && (aquis.Producao.HasValue == true)
                 select new RelatorioAquiculturaPoco()
                 {
                     IdAquicultura = aquis.IdAquicultura,
                     Ano = aquis.Ano,
                     IdMunicipio = aquis.IdMunicipio,
                     NomeMunicipio = muns.NomeMunicipio,
                     SiglaUF = ufs.SiglaUf,
                     DescricaoUF = ufs.DescricaoUf,
                     IdTipoAquicultura = aquis.IdTipoAquicultura,
                     DescricaoTipoAquicultura = tipos.DescricaoTipoAquicultura,
                     Producao = aquis.Producao,
                     ValorProducao = aquis.ValorProducao,
                     ProporcaoValorProducao = aquis.ProporcaoValorProducao,
                     Moeda = aquis.Moeda
                 }).ToList();
            return pesquisa;
        }


        public List<RelatorioAquiculturaPoco> PesquisarPorIdTipoAquiculturaAnoIdMunicipio(int idTipoAquicultura, 
            int ano, int idMunicipio)
        {
            List<RelatorioAquiculturaPoco> pesquisa =
                (from aquis in this.contexto.Aquiculturas
                 join tipos in this.contexto.TipoAquiculturas on aquis.IdTipoAquicultura equals tipos.IdTipoAquicultura
                 join muns in this.contexto.Municipios on aquis.IdMunicipio equals muns.CodigoIbge7
                 join ufs in this.contexto.UnidadesFederacaos on muns.SiglaUf equals ufs.SiglaUf
                 where
                    (aquis.IdTipoAquicultura == idTipoAquicultura) &&
                    (aquis.Ano == ano) &&
                    (aquis.IdMunicipio == idMunicipio)
                 select new RelatorioAquiculturaPoco()
                 {
                     IdAquicultura = aquis.IdAquicultura,
                     Ano = aquis.Ano,
                     IdMunicipio = aquis.IdMunicipio,
                     NomeMunicipio = muns.NomeMunicipio,
                     SiglaUF = ufs.SiglaUf,
                     DescricaoUF = ufs.DescricaoUf,
                     IdTipoAquicultura = aquis.IdTipoAquicultura,
                     DescricaoTipoAquicultura = tipos.DescricaoTipoAquicultura,
                     Producao = aquis.Producao,
                     ValorProducao = aquis.ValorProducao,
                     ProporcaoValorProducao = aquis.ProporcaoValorProducao,
                     Moeda = aquis.Moeda
                 }).ToList();
            return pesquisa;
        }
    }
}
