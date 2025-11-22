using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Veiculos
{
    public class ListarVeiculos
    {
        public void ListarTodosVeiculos(VeiculoController veiculoController)
        {
            try
            {
                Console.Clear();
                var veiculos = veiculoController.ListarTodosVeiculos();
                if (veiculos.Count() > 0)
                {
                    Console.WriteLine("======= LISTA DE VEÍCULOS =======");
                    foreach (var v in veiculos)
                    {
                        Console.WriteLine(v);
                    }
                }
                else
                {
                    Console.WriteLine("Não há veículos registrados no sistema!");
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
