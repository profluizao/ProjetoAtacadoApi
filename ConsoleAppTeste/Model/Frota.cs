using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.Model
{
    public class Frota
    {
        private List<Veiculo> veiculos;

        private List<Motorista> motoristas;

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }

        public List<Motorista> Motoristas { get => motoristas; set => motoristas = value; }
    }
}
