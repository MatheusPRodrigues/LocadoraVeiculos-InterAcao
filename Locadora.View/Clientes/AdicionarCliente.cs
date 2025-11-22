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
    public class AdicionarCliente
    {
        public void FormAddCliente(ClienteController clienteController)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("======= DADOS DO CLIENTE =======");
                Console.Write("Digite o nome do cliente: ");
                var nomeCliente = Console.ReadLine();

                Console.Write("\nDigite o email do cliente: ");
                var emailCliente = Console.ReadLine();

                Console.Write("\nDigite o telefone do cliente: ");
                var telefoneCliente = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("======= DOCUMENTO DO CLIENTE =======");
                Console.WriteLine("Digite o tipo de documento do cliente:");
                var tipoDocumento = Console.ReadLine();

                Console.WriteLine("\nDigite o número de documento do cliente:");
                var numeroDocumento = Console.ReadLine();

                Console.WriteLine("\nDigite a data de emissão do documento:");
                var dataEmissao = DateOnly.Parse(Console.ReadLine());
                
                Console.WriteLine("\nDigite a data de validade do documento:");
                var dataValidade = DateOnly.Parse(Console.ReadLine());

                var cliente = new Cliente(
                    nomeCliente,
                    emailCliente,
                    telefoneCliente
                );

                var documento = new Documento(
                    tipoDocumento,
                    numeroDocumento,
                    dataEmissao,
                    dataValidade
                );

                clienteController.AdicionarCliente(cliente, documento);
                Console.WriteLine("Cliente adicionado com sucesso!");
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
