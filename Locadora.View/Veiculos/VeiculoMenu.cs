using Locadora.Controller;
using Locadora.View.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.View.Veiculos
{
    public class VeiculoMenu
    {
        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=============== MENU DE VEÍCULOS ===============");
            Console.WriteLine("1 -> Adicionar Veículo");
            Console.WriteLine("2 -> Listar todos Veículos");
            Console.WriteLine("3 -> Atualizar Veículo");
            Console.WriteLine("4 -> Excluir Veículo");
            Console.WriteLine("0 -> Retornar ao menu anterior");
            Console.WriteLine("================================================");
            Console.Write("-> ");
        }

        public void MenuDeVeiculos()
        {
            var categoriaController = new CategoriaController();
            var veiculoController = new VeiculoController();
            var opcao = "";
            var repetirMenu = true;
            do
            {
                ExibirMenu();
                opcao = Console.ReadLine() ?? "-1";

                switch (opcao)
                {
                    case "1":
                        var addVeiculo = new AdicionarVeiculo();
                        addVeiculo.FormAddVeiculo(categoriaController, veiculoController);
                        break;
                    case "2":
                        var listarVeiculos = new ListarVeiculos();
                        listarVeiculos.ListarTodosVeiculos(veiculoController);
                        break;
                    case "3":
                        var attVeiculo = new AtualizarVeiculo();
                        attVeiculo.AtualizarUmVeiculo(veiculoController);
                        break;
                    case "4":
                        var excluirVeiculo = new ExcluirVeiculo();
                        excluirVeiculo.DeletarUmVeiculo(veiculoController);
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
