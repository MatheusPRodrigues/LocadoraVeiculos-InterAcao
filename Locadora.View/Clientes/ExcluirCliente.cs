using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Clientes
{
    public class ExcluirCliente
    {
        public void ExcluirUmCliente(ClienteController clienteController)
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

                    Console.WriteLine("Digite o email do cliente que deseja alterar o excluir do sistema:");
                    var emailCliente = Console.ReadLine();

                    clienteController.ExcluirCliente(emailCliente);
                    Console.WriteLine("Cliente excluído com sucesso!");
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
