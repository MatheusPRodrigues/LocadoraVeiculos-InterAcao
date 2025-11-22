using Locadora.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Locacao
    {
        public Guid LocacaoID { get; private set; }
        public int ClienteID { get; private set; }
        public int VeiculoID { get; private set; }
        public DateTime DataLocacao { get; private set; }
        public DateTime? DataDevolucaoPrevista { get; private set; }
        public DateTime? DataDevolucaoReal { get; private set; }
        public decimal ValorDiaria { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal Multa { get; private set; }
        public EStatusLocacao Status { get; private set; }

        public Locacao(int clienteID, int veiculoID, int diasLocacao, decimal valorDiaria)
        {
            ClienteID = clienteID;
            VeiculoID = veiculoID;
            DataLocacao = DateTime.Now;
            DataDevolucaoPrevista = DateTime.Now.AddDays(diasLocacao);
            ValorDiaria = valorDiaria;
            ValorTotal = valorDiaria * diasLocacao;
            Status = EStatusLocacao.Ativa;
        }

        //TODO: Definir os valores de clientes e veículos como nome e modelo respectivamente
        public override string? ToString()
        {
            return $"Cliente: {ClienteID}\n" +
                    $"Veículo ID: {VeiculoID}\n" +
                    $"Data de Locação: {DataLocacao}\n" +
                    $"Data de Devolução Prevista: {DataDevolucaoPrevista}\n" +
                    $"Data de Devolução Real: {DataDevolucaoReal}\n" +
                    $"Valor da Diária: {ValorDiaria:C}\n" +
                    $"Valor Total: {ValorTotal:C}\n" +
                    $"Multa: {Multa:C}\n" +
                    $"Status: {Status}\n";
        }
    }
}
