using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.View.Locacoes
{
    public class LocacaoMenu
    {
        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=============== MENU DE LOCAÇÕES ===============");
            Console.WriteLine("1 -> Adicionar nova locação");
            Console.WriteLine("2 -> Listar todas as locações");
            Console.WriteLine("3 -> Atualizar devolução");
            Console.WriteLine("4 -> Cancelar locação");
            Console.WriteLine("0 -> Retornar ao menu anterior");
            Console.WriteLine("================================================");
            Console.Write("-> ");
        }

        public void MenuLocacoes()
        {
            var locacaoController = new LocacaoController();
            string opcao = "";
            bool repetirMenu = true;
            do
            {
                ExibirMenu();
                opcao = Console.ReadLine() ?? "-1";
                switch (opcao)
                {
                    case "1":
                        var add = new AdicionarLocacao();
                        add.FormAddLocacao(locacaoController, new ClienteController(), new VeiculoController());
                        break;
                    case "2":
                        var listar = new ListarLocacoes();
                        listar.ListarTodasLocacoes(locacaoController);
                        break;
                    case "3":
                        var atualizar = new AtualizarLocacao();
                        atualizar.FormAtualizarLocacao(locacaoController);
                        break;
                    case "4":
                        var cancelar = new CancelarLocacao();
                        cancelar.FormCancelarLocacao(locacaoController);
                        break;
                    case "0":
                        repetirMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (repetirMenu);
        }
    }
}
