using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {
        public int VeiculoID { get; private set; }
        public int CategoriaID { get; private set; }
        public string Marca { get; private set; }
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string StatusVeiculo { get; private set; }

        public Veiculo(
            int categoriaID,
            string marca,
            string placa, 
            string modelo, 
            int ano,
            string statusVeiculo
        )
        {
            CategoriaID = categoriaID;
            Marca = marca;
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
            StatusVeiculo = statusVeiculo;
        }

        public void SetVeiculoID(int veiculoId)
        {
            VeiculoID = veiculoId;
        }

        public void SetStatusVeiculo(string statusVeiculo )
        {
            StatusVeiculo = statusVeiculo;
        }

        public override string? ToString()
        {
            return $"Placa: {Placa}\n" +
                $"Marca: {Marca}\n" +
                $"Modelo: {Modelo}\n" +
                $"Ano: {Ano}\n" +
                $"Status: {StatusVeiculo}\n";
        }
    }
}
