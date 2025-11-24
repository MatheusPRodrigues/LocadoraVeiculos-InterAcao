using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;
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

                
                var tipoDocumento = SelecionarDocumento();

                Console.Clear();
                Console.WriteLine("======= DOCUMENTO DO CLIENTE =======");
                Console.WriteLine($"\nDigite o número de documento do(a) {tipoDocumento} do cliente:");
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
