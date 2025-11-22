using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Clientes
{
    public class AtualizarTelefone
    {
        public void AtualizarTelefoneCliente(ClienteController clienteController)
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

                    Console.WriteLine("\nDigite o novo telefone do cliente:");
                    var telefoneCliente = Console.ReadLine();

                    clienteController.AtualizarTelefoneCliente(telefoneCliente, emailCliente);
                    Console.WriteLine("Telefone do cliente atualizado com sucesso!");
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
