using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.Testes
{
    public class SubcategoriaTeste
    {
        public void Executar()
        {
            SubcategoriaService srv = new SubcategoriaService();
            List<SubcategoriaPoco> listaPoco = srv.Listar();
            foreach (SubcategoriaPoco poco in listaPoco)
            {
                Console.WriteLine("Codigo: {0} - Cat: {1} - Descrição: {2} - Situação: {3}", poco.IdSubcategoria, poco.IdCategoria, poco.DescricaoSubcategoria, poco.Situacao);
                Console.WriteLine("-------------------------------------------------");
            }
        }
    }
}
