using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Locacoes
{
    public class ListarLocacoes
    {
        public void ListarTodasLocacoes(LocacaoController locacaoController)
        {
            try
            {
                Console.Clear();
                var locacoes = locacaoController.ListarLocacao();
                if (locacoes.Count > 0)
                {
                    foreach (var loc in locacoes)
                    {
                        Console.WriteLine(loc);
                        Console.WriteLine("--------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhuma locação registrada!");
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
