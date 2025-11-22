using Locadora.Controller;
using Locadora.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Veiculos
{
    public class AtualizarVeiculo
    {
        private string SelecionarStatus()
        {
            var status = "";
            do
            {
                Console.Clear();
                Console.WriteLine("===== SELECIONE O STATUS DO VEÍCULO =====");
                Console.WriteLine("D - Disponível");
                Console.WriteLine("A - Alugado");
                Console.WriteLine("M - Manutenção");
                Console.WriteLine("R - Reservado");
                status = Console.ReadLine().ToUpper();

                switch (status)
                {
                    case "D":
                        return EStatusVeiculo.Disponivel.ToString();                        
                    case "A":
                        return EStatusVeiculo.Alugado.ToString();
                    case "M":
                        return EStatusVeiculo.Manutencao.ToString();
                    case "R":
                        return EStatusVeiculo.Reservado.ToString();
                    default:
                        Console.WriteLine("Selecione um dos status acima!");
                        break;
                }
            }
            while (true);
        }

        public void AtualizarUmVeiculo(VeiculoController veiculoController)
        {
            Console.Clear();
            try
            {
                if (veiculoController.ListarTodosVeiculos().Count() == 0)
                {
                    Console.WriteLine("Não veículos registrados no sistema!");
                }
                else
                {
                    new ListarVeiculos().ListarTodosVeiculos(veiculoController);

                    Console.WriteLine("Digite a placa do veículo que deseja atualizar:");
                    var placa = Console.ReadLine();

                    var status = SelecionarStatus();
                    veiculoController.AtualizarStatusVeiculo(status, placa);
                    Console.WriteLine("\nVeículo atualizado com sucesso!");
                    Console.WriteLine(veiculoController.BuscarVeiculoPlaca(placa));
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
