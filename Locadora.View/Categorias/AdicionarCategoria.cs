using Locadora.Controller;
using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Categorias
{
    public class AdicionarCategoria
    {
        public void FormAddCategoria(CategoriaController categoriaController)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("======= DADOS DA CATEGORIA =======");
                Console.Write("Digite o nome da categoria: ");
                var nomeCategoria = Console.ReadLine();

                Console.Write("\nDigite a descrição da categoria: ");
                var descricaoCategoria = Console.ReadLine();

                Console.Write("\nDigite o valor da diária: ");
                var valorDiaria = decimal.Parse(Console.ReadLine());

                var categoria = new Categoria(
                    nomeCategoria,
                    valorDiaria,
                    descricaoCategoria
                );

                categoriaController.AdicionarCategoria(categoria);
                Console.WriteLine("Categoria adicionada com sucesso!");
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
