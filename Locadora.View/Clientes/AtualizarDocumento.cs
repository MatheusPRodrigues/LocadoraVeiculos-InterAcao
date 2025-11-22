using Locadora.Controller;
using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Clientes
{
    public class AtualizarDocumento
    {
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

                    Console.WriteLine("\nDigite o novo tipo de documento do cliente:");
                    var tipoDocumento = Console.ReadLine();

                    Console.WriteLine("\nDigite o novo número de documento do cliente:");
                    var numeroDocumento = Console.ReadLine();

                    Console.WriteLine("\nDigite a data de emissão do documento:");
                    var dataEmissao = DateOnly.Parse(Console.ReadLine());

                    Console.WriteLine("\nDigite a data de validade do documento:");
                    var dataValidade = DateOnly.Parse(Console.ReadLine());

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
