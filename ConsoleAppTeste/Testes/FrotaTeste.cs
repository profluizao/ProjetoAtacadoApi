using ConsoleAppTeste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.Testes
{
    public class FrotaTeste
    {
        public void Executar()
        {
            Frota frota = FrotaFakeDB.FakeDB;

            //todos os motoristas da frota 1.

            var consultaLambda =
                from mot in frota.Motoristas
                where mot.IDFrota == 1
                select mot;

            var consultaLinq = frota.Motoristas.Where(m => m.IDFrota == 1);

            //todos os motoristas da frota 2, cujo veiculo seja da frota 2 e da marca A.

            var pesquisaLambda =
                from mot in frota.Motoristas
                join vei in frota.Veiculos on mot.IDFrota equals vei.IDFrota
                where (mot.IDFrota == 2) && (vei.Marca == "A")
                select new
                { 
                    IDFrota = mot.IDFrota,
                    IDMotorista = mot.Codigo,
                    CPFMotorista = mot.CPF,
                    NomeMotorista = mot.Nome,
                    IDVeiculo = vei.Codigo,
                    RegistroVeiculo = vei.Registro,
                    MarcaVeiculo = vei.Marca
                };

        }

    }
}
