using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Veiculos
{
    public class ExcluirVeiculo
    {
        public void DeletarUmVeiculo(VeiculoController veiculoController)
        {
            Console.Clear();
            try
            {
                if (veiculoController.ListarTodosVeiculos().Count() == 0)
                {
                    Console.WriteLine("Não há veículos registrados no sistema!");
                }
                else
                {
                    Console.WriteLine("====== SELECIONE A PLACA DO VEÍCULO QUE DESEJA EXCLUIR ======");
                    new ListarVeiculos().ListarTodosVeiculos(veiculoController);

                    Console.WriteLine("Insira a placa do veículo que deseja excluir:");
                    var placa = Console.ReadLine();

                    var idVeiculo = veiculoController.BuscarVeiculoPlaca(placa).VeiculoID;
                    veiculoController.DeletarVeiculo(idVeiculo);
                    Console.WriteLine("\nVeículo deletado com sucesso!");
                }
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
