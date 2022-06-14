using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.Testes
{
    public class ProdutoTeste
    {
        public void Executar()
        {
            ProdutoService srv = new ProdutoService();
            List<ProdutoPoco> listaPoco = srv.Listar();
            foreach (ProdutoPoco poco in listaPoco)
            {
                Console.Write("Codigo: {0} - ", poco.IdProduto);
                Console.Write("Categoria: {0} - ", poco.IdCategoria);
                Console.Write("Subcategoria: {0} - ", poco.IdSubcategoria);
                Console.Write("Descrição: {0} - ", poco.DescricaoProduto);
                Console.WriteLine("Situação: {0} - ", poco.Situacao);
                Console.WriteLine("-------------------------------------------------");
            }
        }
    }
}

