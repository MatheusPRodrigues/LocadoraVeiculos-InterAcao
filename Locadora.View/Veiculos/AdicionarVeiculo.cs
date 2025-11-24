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
                    var placa = SolicitarPlaca();

                    Console.Write("\nDigite a marca do veículo: ");
                    var marca = Console.ReadLine();
                    
                    Console.Write("\nDigite o modelo do veículo: ");
                    var modelo = Console.ReadLine();

                    var ano = Helpers.LerInteiro("Digite o ano do veículo: ");

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

        private string SolicitarPlaca()
        {
            string placa;
            string regexAntigo = @"^[A-Z]{3}[0-9]{4}$";
            string regexMercosul = @"^[A-Z]{3}[0-9][A-Z][0-9]{2}$";

            do
            {
                Console.Write("Digite a placa do veículo (ex: ABC1234 ou ABC1D23): ");
                placa = Console.ReadLine()?.ToUpper().Replace("-", "").Trim();

                if (System.Text.RegularExpressions.Regex.IsMatch(placa, regexAntigo) ||
                    System.Text.RegularExpressions.Regex.IsMatch(placa, regexMercosul))
                {
                    return placa;
                }
                Console.WriteLine("Placa inválida! Tente novamente.");
            } while (true);
        }
    }
}
