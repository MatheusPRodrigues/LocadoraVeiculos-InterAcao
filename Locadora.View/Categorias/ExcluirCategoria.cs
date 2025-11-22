using Locadora.Controller;
using Locadora.Models;
using Locadora.View.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Categorias
{
    public class ExcluirCategoria
    {
        public void ExcluirUmaCategoria(CategoriaController categoriaController)
        {
            try
            {
                Console.Clear();
                if (categoriaController.ListarTodasCategorias().Count == 0)
                {
                    Console.WriteLine("Não há categorias registrados no sistema");
                }
                else
                {
                    new ListarCategorias().ListarTodasCategorias(categoriaController);

                    Console.WriteLine("Digite o nome da categoria que deseja excluir: ");
                    var nomeCategoria = Console.ReadLine();

                    categoriaController.DeletarCategoria(nomeCategoria);
                    Console.WriteLine("Categoria deletada com sucesso!");
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
