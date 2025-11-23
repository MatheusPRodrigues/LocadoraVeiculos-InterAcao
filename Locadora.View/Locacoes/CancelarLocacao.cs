using Locadora.Controller;
using Locadora.Models;
using Locadora.View.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Locacoes
{
    public class CancelarLocacao
    {
        public void FormCancelarLocacao(LocacaoController locacaoController, FuncionarioController funcionarioController)
        {
            try
            {
                Console.Clear();
                if (locacaoController.ListarLocacao().Count() == 0)
                {
                    Console.WriteLine("Não há locações registrados no sistema!");
                }
                else
                {
                    new ListarFuncionarios().ListarTodosFuncionarios(funcionarioController);
                    Console.WriteLine("======= ADICIONE O FUNCIONÁRIO=======");
                    Console.Write("Digite o CPF do funcionário: ");
                    var cpf = Console.ReadLine();
                    var funcionarioId = funcionarioController.BuscarFuncionarioPorCPF(cpf).FuncionarioID;

                    new ListarLocacoes().ListarTodasLocacoes(locacaoController);
                    Console.WriteLine("Informe o ID da locação para cancelar:");
                    var idLocacao = Console.ReadLine();

                    var locacaoFuncionarios = new LocacaoFuncionarios(
                        Guid.Parse(idLocacao),
                        funcionarioId,
                        "Alterou locação para Cancelada."
                    );

                    locacaoController.CancelarLocacao(idLocacao, locacaoFuncionarios);
                    Console.WriteLine("Locação cancelada com sucesso!");
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
