using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.Model
{
    public static class FrotaFakeDB
    {
        private static Frota frota;

        public static Frota FakeDB
        {
            get
            {
                if (frota == null)
                { 
                    frota = new Frota();
                    InicializarMotoristas();
                    InicializarVeiculos();
                }
                return frota;
            }
        }

        private static void InicializarMotoristas()
        {
            frota.Motoristas = new List<Motorista>();
            frota.Motoristas.Add(new Motorista() { Codigo = 1, Nome = "Teste1", CPF = "1231", IDFrota = 1 });
            frota.Motoristas.Add(new Motorista() { Codigo = 2, Nome = "Teste2", CPF = "1232", IDFrota = 1 });
            frota.Motoristas.Add(new Motorista() { Codigo = 3, Nome = "Teste3", CPF = "1233", IDFrota = 1 });
            frota.Motoristas.Add(new Motorista() { Codigo = 4, Nome = "Teste4", CPF = "1234", IDFrota = 2 });
            frota.Motoristas.Add(new Motorista() { Codigo = 5, Nome = "Teste5", CPF = "1235", IDFrota = 2 });
            frota.Motoristas.Add(new Motorista() { Codigo = 6, Nome = "Teste6", CPF = "1236", IDFrota = 2 });
            frota.Motoristas.Add(new Motorista() { Codigo = 7, Nome = "Teste7", CPF = "1237", IDFrota = 3 });
            frota.Motoristas.Add(new Motorista() { Codigo = 8, Nome = "Teste8", CPF = "1238", IDFrota = 3 });
            frota.Motoristas.Add(new Motorista() { Codigo = 9, Nome = "Teste9", CPF = "1239", IDFrota = 4 });
        }

        private static void InicializarVeiculos()
        {
            frota.Veiculos = new List<Veiculo>();
            frota.Veiculos.Add(new Veiculo() { Codigo = 1, Registro = "A1", Marca = "X", IDFrota = 1 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 2, Registro = "A2", Marca = "X", IDFrota = 1 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 3, Registro = "A3", Marca = "X", IDFrota = 1 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 4, Registro = "A4", Marca = "A", IDFrota = 1 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 5, Registro = "A5", Marca = "A", IDFrota = 1 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 6, Registro = "A6", Marca = "A", IDFrota = 2 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 7, Registro = "A7", Marca = "D", IDFrota = 2 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 8, Registro = "A8", Marca = "D", IDFrota = 3 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 9, Registro = "A9", Marca = "F", IDFrota = 3 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 10, Registro = "A10", Marca = "F", IDFrota = 1 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 11, Registro = "A11", Marca = "G", IDFrota = 1 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 12, Registro = "A12", Marca = "G", IDFrota = 2 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 13, Registro = "A13", Marca = "X", IDFrota = 3 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 14, Registro = "A14", Marca = "H", IDFrota = 3 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 15, Registro = "A15", Marca = "H", IDFrota = 3 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 16, Registro = "A16", Marca = "A", IDFrota = 4 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 17, Registro = "A17", Marca = "A", IDFrota = 4 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 18, Registro = "A18", Marca = "D", IDFrota = 3 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 19, Registro = "A19", Marca = "F", IDFrota = 2 });
            frota.Veiculos.Add(new Veiculo() { Codigo = 20, Registro = "A20", Marca = "G", IDFrota = 1 });
        }
    }
}
