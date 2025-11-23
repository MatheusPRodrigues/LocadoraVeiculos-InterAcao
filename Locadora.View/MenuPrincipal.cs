using Locadora.View.Clientes;
using Locadora.View.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Locadora.View.Veiculos;
using Locadora.View.Funcionarios;
using Locadora.View.Locacoes;

namespace Locadora.View
{
    public class MenuPrincipal
    {
        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=============== LOCADORA DE VEÍCULOS ===============");
            Console.WriteLine("1 -> Menu gerenciamento de Clientes");
            Console.WriteLine("2 -> Menu gerenciamento de Veículos e Categorias");
            Console.WriteLine("3 -> Menu gerenciamento de Funcionários");
            Console.WriteLine("4 -> Menu gerenciamento de Locações");
            Console.WriteLine("0 -> Encerrar programa");
            Console.WriteLine("====================================================");
            Console.Write("-> ");
        }

        private void AcessarMenuDeVeiculosCategorias()
        {
            var opcao = "";
            var repete = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Qual dos menus deseja acessar?");
                Console.WriteLine("1 - Veiculos");
                Console.WriteLine("2 - Categorias");
                Console.WriteLine("0 - Retornar");
                opcao = Console.ReadLine() ?? "-1";

                switch (opcao)
                {
                    case "1":
                        var veiculoMenu = new VeiculoMenu();
                        veiculoMenu.MenuDeVeiculos();
                        repete = false;
                        break;
                    case "2":
                        var categoriaMenu = new CategoriasMenu();
                        categoriaMenu.MenuDeCategorias();
                        repete = false;
                        break;
                    case "0":
                        repete = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente uma das opções do menu!");
                        Helpers.PressionerEnterParaContinuar();
                        break;
                }
            }
            while (repete);
        }

        public void Menu()
        {
            var option = "";
            var repetirMenu = true;
            do
            {
                ExibirMenu();
                option = Console.ReadLine() ?? "-1";
                
                switch (option)
                {
                    case "1":
                        var menuCliente = new ClienteMenu();
                        menuCliente.MenuDoCliente();
                        break;
                    case "2":
                        AcessarMenuDeVeiculosCategorias();
                        break;
                    case "3":
                        var menuFuncionario = new FuncionarioMenu();
                        menuFuncionario.MenuDeFuncionarios();
                        break;
                    case "4":
                        var menuLocacao = new LocacaoMenu();
                        menuLocacao.MenuLocacoes();
                        break;
                    case "0":
                        repetirMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Selecione uma das opções do menu!");
                        Helpers.PressionerEnterParaContinuar();
                        break;
                }
            }
            while (repetirMenu);

            Console.WriteLine("Sistema encerrado com sucesso!");
        }
    }
}
