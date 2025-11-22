using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.View.Clientes
{
    public class ClienteMenu
    {
        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=============== MENU DE CLIENTES ===============");
            Console.WriteLine("1 -> Adicionar Cliente");
            Console.WriteLine("2 -> Listar todos Clientes");
            Console.WriteLine("3 -> Atualizar telefone do Cliente");
            Console.WriteLine("4 -> Atualizar Documento do Cliente");
            Console.WriteLine("5 -> Excluir Cliente");
            Console.WriteLine("0 -> Retornar ao menu anterior");
            Console.WriteLine("================================================");
            Console.Write("-> ");
        }

        public void MenuDoCliente()
        {
            var clienteController = new ClienteController();
            var opcao = "";
            var repetirMenu = true;
            do
            {
                ExibirMenu();
                opcao = Console.ReadLine() ?? "-1";

                switch (opcao)
                {
                    case "1":
                        var addCliente = new AdicionarCliente();
                        addCliente.FormAddCliente(clienteController);
                        break;
                    case "2":
                        var listarClientes = new ListarClientes();
                        listarClientes.ListarTodosClientes(clienteController);
                        break;
                    case "3":
                        var attTelefone = new AtualizarTelefone();
                        attTelefone.AtualizarTelefoneCliente(clienteController);
                        break;
                    case "4":
                        var attDocumento = new AtualizarDocumento();
                        attDocumento.AtualizarDocumentoCliente(clienteController);
                        break;
                    case "5":
                        var excluirCliente = new ExcluirCliente();
                        excluirCliente.ExcluirUmCliente(clienteController);
                        break;
                    case "0":
                        repetirMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Selecione uma das opções do menu!");
                        break;
                }
            }
            while (repetirMenu);
        }
    }
}
