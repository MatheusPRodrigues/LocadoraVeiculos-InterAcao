using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;
using Utils;

namespace Locadora.View.Clientes
{
    public class AtualizarDocumento
    {
        private string SelecionarDocumento()
        {
            var option = "";
            do
            {
                Console.Clear();
                Console.WriteLine("==== SELECIONE O TIPO DE DOCUMENTO ====");
                Console.WriteLine("1 -> CPF");
                Console.WriteLine("2 -> RG");
                Console.WriteLine("3 -> CNH");
                Console.WriteLine("=======================================");
                Console.Write("-> ");
                option = Console.ReadLine() ?? "-1";

                switch (option)
                {
                    case "1":
                        return ETiposDocumentos.CPF.ToString();
                    case "2":
                        return ETiposDocumentos.RG.ToString();
                    case "3":
                        return ETiposDocumentos.CNH.ToString();
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente!");
                        Helpers.PressionerEnterParaContinuar();
                        break;
                }
            }
            while (true);
        }

        public void AtualizarDocumentoCliente(ClienteController clienteController)
        {
            try
            {
                Console.Clear();
                if (clienteController.ListarTodosClientes().Count == 0)
                {
                    Console.WriteLine("Não há clientes registrados no sistema");
                }
                else
                {
                    new ListarClientes().ListarTodosClientes(clienteController);

                    Console.WriteLine("Digite o email do cliente que deseja alterar o telefone:");
                    var emailCliente = Console.ReadLine();

                    var tipoDocumento = SelecionarDocumento();

                    var numeroDocumento = Helpers.SolicitarNumeroDocumento("CPF");

                    Console.Clear();
                    var dataEmissao = Helpers.LerData("Data de Emissão (dd/mm/aaaa): ");

                    Console.Clear();
                    var dataValidade = Helpers.LerData("Data de Validade (dd/mm/aaaa): ");

                    var documento = new Documento(
                        tipoDocumento,
                        numeroDocumento,
                        dataEmissao,
                        dataValidade
                    );

                    clienteController.AtualizarDocumentoCliente(documento, emailCliente);
                    Console.WriteLine("Documento do cliente atualizado com sucesso!");
                    Console.WriteLine(clienteController.BuscarClientePorEmail(emailCliente));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Helpers.PressionerEnterParaContinuar();
            }
        }
    }
}
