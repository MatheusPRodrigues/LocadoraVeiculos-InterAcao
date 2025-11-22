using Locadora.View.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View
{
    public class MenuPrincipal
    {
        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=============== LOCADORA DE VEÍCULOS ===============");
            Console.WriteLine("1 -> Menu gerenciamento de clientes");
            Console.WriteLine("2 -> Menu gerenciamento de veículos");
            Console.WriteLine("3 -> Menu gerenciamento de funcionários");
            Console.WriteLine("4 -> Menu gerenciamento de locações");
            Console.WriteLine("0 -> Encerrar programa");
            Console.WriteLine("====================================================");
            Console.Write("-> ");
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
                        break;
                    case "3":
                        break;
                    case "4":
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
