using Locadora.Controller;
using Locadora.View.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.View.Funcionarios
{
    public class FuncionarioMenu
    {
        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=============== MENU DE FUNCIONÁRIOS ===============");
            Console.WriteLine("1 -> Adicionar Funcionário");
            Console.WriteLine("2 -> Listar todos Funcionários");
            Console.WriteLine("3 -> Atualizar Funcionário");
            Console.WriteLine("4 -> Excluir Funcionário");
            Console.WriteLine("0 -> Retornar ao menu anterior");
            Console.WriteLine("================================================");
            Console.Write("-> ");
        }

        public void MenuDeFuncionarios()
        {
            var funcionarioController = new FuncionarioController();
            var opcao = "";
            var repetirMenu = true;
            do
            {
                ExibirMenu();
                opcao = Console.ReadLine() ?? "-1";

                switch (opcao)
                {
                    case "1":
                        var addFuncionario = new AdicionarFuncionario();
                        addFuncionario.AdicionarUmFuncionario(funcionarioController);
                        break;
                    case "2":
                        var listarFuncionarios = new ListarFuncionarios();
                        listarFuncionarios.ListarTodosFuncionarios(funcionarioController);
                        break;
                    case "3":
                        var attFuncionario = new AtualizarFuncionario();
                        attFuncionario.AtualizarSalarioFuncionario(funcionarioController);
                        break;
                    case "4":
                        var excluirFuncionario = new ExcluirFuncionario();
                        excluirFuncionario.ExcluirUmFuncionario(funcionarioController);
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
