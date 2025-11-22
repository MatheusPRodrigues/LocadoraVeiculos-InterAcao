using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Categorias
{
    public class ListarCategorias
    {
        public void ListarTodasCategorias(CategoriaController categoriaController)
        {
            try
            {
                Console.Clear();
                var categorias = categoriaController.ListarTodasCategorias();
                if (categorias.Count() > 0)
                {
                    Console.WriteLine("======= LISTA DE CATEGORIAS =======");
                    foreach (var c in categorias)
                    {
                        Console.WriteLine(c);
                    }
                }
                else
                {
                    Console.WriteLine("Não há categorias registradas no sistema!");
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
