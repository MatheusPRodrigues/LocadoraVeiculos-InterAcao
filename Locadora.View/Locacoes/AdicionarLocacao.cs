using Locadora.Controller;
using Locadora.Models;
using Locadora.View.Clientes;
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
            VeiculoController veiculoController
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
                else
                {
                    Console.WriteLine("======= SELECIONE O EMAIL DO CLIENTE=======");
                    new ListarClientes().ListarTodosClientes(clienteController);
                    Console.Write("Digite email do cliente: ");
                    var email = Console.ReadLine();
                    var clienteId = clienteController.BuscarClientePorEmail(email).ClienteID;

                    Console.Clear();
                    Console.WriteLine("======= SELECIONE O EMAIL DO CLIENTE=======");
                    new ListarVeiculos().ListarTodosVeiculos(veiculoController);
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
                    locacaoController.AdicionarLocacao(locacao);
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
