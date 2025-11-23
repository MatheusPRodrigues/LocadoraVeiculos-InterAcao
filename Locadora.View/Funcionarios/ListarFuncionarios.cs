using Locadora.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Funcionarios
{
    public class ListarFuncionarios
    {
        public void ListarTodosFuncionarios(FuncionarioController funcionarioController)
        {
            try
            {
                Console.Clear();
                var funcionarios = funcionarioController.ListarTodosFuncionarios();
                if (funcionarios.Count() > 0)
                {
                    Console.WriteLine("======= LISTA DE VEÍCULOS =======");
                    foreach (var f in funcionarios)
                    {
                        Console.WriteLine(f);
                    }
                }
                else
                {
                    Console.WriteLine("Não há funcionários registrados no sistema!");
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
