using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Clientes
{
    public class ListarClientes
    {
        public void ListarTodosClientes(ClienteController clienteController)
        {
            try
            {
                Console.Clear();
                var clienteLista = clienteController.ListarTodosClientes();
                if (clienteLista.Count > 0)
                {
                    Console.WriteLine("======= LISTA DE CLIENTE =======");
                    foreach (var c in clienteLista)
                    {
                        Console.WriteLine(c);
                    }
                }
                else
                {
                    Console.WriteLine("Não há clientes registrados no sistema!");
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
