using Locadora.Controller;
using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Funcionarios
{
    public class AdicionarFuncionario
    {
        public void AdicionarUmFuncionario(FuncionarioController funcionarioController)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("======= DADOS DO FUNCIONÁRIO =======");
                Console.WriteLine("Digite o nome do funcionário:");
                var nome = Console.ReadLine();

                Console.WriteLine("\nDigite o CPF do funcionário:");
                var cpf = Console.ReadLine();

                Console.WriteLine("\nDigite o Email do funcionário:");
                var email = Console.ReadLine();

                Console.Write("\nDigite o salário do funcionário:");
                var salarioEmString = Console.ReadLine();

                var salario = String.IsNullOrEmpty(salarioEmString) ?
                    0.0m : decimal.Parse(salarioEmString);

                var funcionario = new Funcionario(
                    nome,
                    cpf,
                    email,
                    salario
                );

                funcionarioController.AdicionarFuncionario(funcionario);
                Console.WriteLine("\nFuncionário adicionado com sucesso!");
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
