using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {
        public readonly static string INSERTVEICULO = @"INSERT INTO tblVeiculos (CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo) 
                                                        VALUES (@CategoriaID, @Placa, @Marca, @Modelo, @Ano, @StatusVeiculo)";

        public readonly static string SELECTALLVEICULO = @"SELECT CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo FROM tblVeiculos";

        public readonly static string SELECTVEICULABYPLACA = @"SELECT 
                                                                VeiculoID, CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo
                                                             FROM tblVeiculos
                                                             WHERE Placa = @Placa";

        public readonly static string UPDATESTATUSVEICULO = @"UPDATE tblVeiculos SET
                                                                StatusVeiculo = @StatusVeiculo
                                                            WHERE VeiculoID = @IdVeiculo";

        public readonly static string DELETEVEICULO = @"DELETE FROM tblVeiculos WHERE VeiculoID = @IdVeiculo";

        public int VeiculoID { get; private set; }
        public int CategoriaID { get; private set; }
        public string? NomeCategoria { get; private set; }
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string StatusVeiculo { get; private set; }

        public Veiculo(
            int categoriaID,
            string placa, 
            string marca,
            string modelo, 
            int ano,
            string statusVeiculo
        )
        {
            CategoriaID = categoriaID;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            StatusVeiculo = statusVeiculo;
        }

        public void SetVeiculoID(int veiculoId)
        {
            VeiculoID = veiculoId;
        }

        public void SetNomeCategoria(string nomeCategoria)
        {
            NomeCategoria = nomeCategoria;  
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
                $"Status: {StatusVeiculo}\n" +
                $"Categoria: {NomeCategoria}\n";
        }
    }
}
