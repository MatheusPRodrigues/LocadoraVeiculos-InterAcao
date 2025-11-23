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
        public readonly static string sp_AdicionarLocacao =
        @"EXEC sp_AdicionarLocacao @LocacaoID,
                                   @ClienteId,
                                   @VeiculoId,
                                   @DataDevolucaoPrevista,
                                   @DataDevolucaoReal,
                                   @ValorDiaria,
                                   @ValorTotal,
                                   @Multa,
                                   @Status;
        ";

        public readonly static string sp_AtualizarLocacao =
            "EXEC sp_AtualizarLocacao @idLocacao, @DataDevolucaoReal, @Status, @Multa";

        public readonly static string sp_BuscarLocacaoId =
            "EXEC sp_BuscarLocacaoId @idLocacao";

        public readonly static string sp_BuscarLocacao =
               "EXEC sp_BuscarLocacao";

        public readonly static string sp_CancelarLocacao =
            "EXEC sp_CancelarLocacao @idLocacao, @Status";

        public Guid LocacaoID { get; private set; }
        public int ClienteID { get; private set; }
        public string ClienteNome { get; private set; }
        public int VeiculoID { get; private set; }
        public string VeiculoNome { get; private set; }
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

        public Locacao(
            string clienteNome,
            string veiculoNome,
            DateTime dataLocacao,
            DateTime? dataDevolucaoPrevista,
            DateTime? dataDevolucaoReal,
            decimal valorDiaria,
            decimal valorTotal,
            decimal multa
        )
        {
            ClienteNome = clienteNome;
            VeiculoNome = veiculoNome;
            DataLocacao = dataLocacao;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
            DataDevolucaoReal = dataDevolucaoReal;
            ValorDiaria = valorDiaria;
            ValorTotal = valorTotal;
            Multa = multa;
        }

        public void SetLocacaoID(string locacaoId)
        {
            LocacaoID = Guid.Parse(locacaoId);
        }

        public void SetVeiculoNome(string nome)
            => VeiculoNome = nome;

        public void SetClienteNome(string nome)
            => ClienteNome = nome;

        public void SetMulta(decimal multa)
            => Multa = multa;

        public void SetStatus(EStatusLocacao status)
            => Status = status;

        public void SetDataLocacao(DateTime dataLocacao)
            => DataLocacao = dataLocacao;

        public void SetDataDevolucaoReal(DateTime dataDevolucaoReal)
            => DataDevolucaoReal = dataDevolucaoReal;

        //TODO: Definir os valores de clientes e veículos como nome e modelo respectivamente
        public override string? ToString()
        {
            return $"Locação ID: {LocacaoID}\n" +
                    $"Cliente: {ClienteNome}\n" +
                    $"Veículo: {VeiculoNome}\n" +
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
