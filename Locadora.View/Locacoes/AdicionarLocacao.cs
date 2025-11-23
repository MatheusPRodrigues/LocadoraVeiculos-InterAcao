using Locadora.Controller;
using Locadora.Models;
using Locadora.View.Clientes;
using Locadora.View.Funcionarios;
using Locadora.View.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Locacoes
{
    public class AdicionarLocacao
    {
        public void FormAddLocacao(LocacaoController locacaoController,
            ClienteController clienteController,
            VeiculoController veiculoController,
            FuncionarioController funcionarioController
        )
        {
            try
            {
                Console.Clear();
                if (clienteController.ListarTodosClientes().Count() == 0)
                {
                    Console.WriteLine("Não há clientes cadastrados no sistema!");
                }
                else if (veiculoController.ListarTodosVeiculos().Count() == 0)
                {
                    Console.WriteLine("Não há veículos cadastrados no sistema!");
                }
                else if (funcionarioController.ListarTodosFuncionarios().Count() == 0)
                {
                    Console.WriteLine("Não há funcionários cadastrados no sistema!");
                }
                else
                {
                    new ListarFuncionarios().ListarTodosFuncionarios(funcionarioController);
                    Console.WriteLine("======= ADICIONE O FUNCIONÁRIO=======");
                    Console.Write("Digite o CPF do funcionário: ");
                    var cpf = Console.ReadLine();
                    var funcionarioId = funcionarioController.BuscarFuncionarioPorCPF(cpf).FuncionarioID;

                    new ListarClientes().ListarTodosClientes(clienteController);
                    Console.WriteLine("======= ADICIONE O CLIENTE=======");
                    Console.Write("Digite email do cliente: ");
                    var email = Console.ReadLine();
                    var clienteId = clienteController.BuscarClientePorEmail(email).ClienteID;

                    Console.Clear();
                    new ListarVeiculos().ListarTodosVeiculos(veiculoController);
                    Console.WriteLine("======= ADICIONE O VEÍCULO =======");
                    Console.Write("Digite a placa do veículo: ");
                    var placa = Console.ReadLine();
                    var veiculoId = veiculoController.BuscarVeiculoPlaca(placa).VeiculoID;
                    

                    Console.Clear();
                    Console.WriteLine("======= DADOS DA LOCAÇÃO =======");
                    Console.WriteLine("Digite o valor da diária da locação");
                    var valorDiaria = decimal.Parse(Console.ReadLine());
                    Console.Write("\nDigite o número de dias de locação: ");
                    var dias = int.Parse(Console.ReadLine());

                    var locacao = new Locacao(
                        clienteId,
                        veiculoId,
                        dias,
                        valorDiaria
                    );
                    locacao.SetLocacaoID(Guid.NewGuid().ToString());

                    var locacaoFuncionarios = new LocacaoFuncionarios(
                        locacao.LocacaoID,
                        funcionarioId,
                        "Registrou locação no sistema."
                    );

                    locacaoController.AdicionarLocacao(locacao, locacaoFuncionarios);
                    Console.WriteLine("Locação adicionada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                Helpers.PressionerEnterParaContinuar();
            }
        }
    }
}
