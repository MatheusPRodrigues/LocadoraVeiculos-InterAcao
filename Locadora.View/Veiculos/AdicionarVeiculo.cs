using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;
using Locadora.View.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Veiculos
{
    public class AdicionarVeiculo
    {
        public void FormAddVeiculo(CategoriaController categoriaController, VeiculoController veiculoController)
        {
            try
            {
                Console.Clear();
                if (categoriaController.ListarTodasCategorias().Count() == 0)
                {
                    Console.WriteLine("Não há categorias para adicionar um veículo");
                }
                else
                {
                    new ListarCategorias().ListarTodasCategorias(categoriaController);

                    Console.Clear();
                    Console.WriteLine("======= SELECIONE UMA CATEGORIA =======");
                    Console.WriteLine("Digite a o nome da categoria que deseja cadastrar o veículo:");
                    var nomeCategoria = Console.ReadLine();
                    var categoria = categoriaController.BuscarCategoriaPorNome(nomeCategoria);

                    Console.Clear();
                    Console.WriteLine("======= DADOS DO VEÍCULO =======");
                    Console.Write("Digite a placa do veículo: ");
                    var placa = Console.ReadLine();

                    Console.Write("\nDigite a marca do veículo: ");
                    var marca = Console.ReadLine();
                    
                    Console.Write("\nDigite o modelo do veículo: ");
                    var modelo = Console.ReadLine();

                    Console.WriteLine("\nDigite o ano do veículo: ");
                    var ano = Convert.ToInt32(Console.ReadLine());

                    var status = EStatusVeiculo.Disponivel.ToString();

                    var veiculo = new Veiculo(
                        categoria.CategoriaID,
                        placa,
                        marca,
                        modelo,
                        ano,
                        status
                    );

                    veiculoController.AdicionarVeiculo(veiculo);
                    Console.WriteLine("\nVeículo adicionado com sucesso!");
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
