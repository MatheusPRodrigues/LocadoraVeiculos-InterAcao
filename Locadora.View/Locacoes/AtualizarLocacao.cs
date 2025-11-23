using Locadora.Controller;
using Locadora.Controller.Interfaces;
using Locadora.Models;
using Locadora.Models.Enums;
using Locadora.View.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.Locacoes
{
    public class AtualizarLocacao
    {
        public void FormAtualizarLocacao(LocacaoController locacaoController, FuncionarioController funcionarioController)
        {
            try
            {
                Console.Clear();
                if (locacaoController.ListarLocacao().Count() == 0)
                {
                    Console.WriteLine("Não há locações registradas no sistema!");
                }
                else
                {
                    new ListarFuncionarios().ListarTodosFuncionarios(funcionarioController);
                    Console.WriteLine("======= ADICIONE O FUNCIONÁRIO=======");
                    Console.Write("Digite o CPF do funcionário: ");
                    var cpf = Console.ReadLine();
                    var funcionarioId = funcionarioController.BuscarFuncionarioPorCPF(cpf).FuncionarioID;

                    new ListarLocacoes().ListarTodasLocacoes(locacaoController);
                    Console.WriteLine("Informe o ID da locação que deseja atualizar:");
                    var idLocacao = Console.ReadLine();

                    var status = EStatusLocacao.Finalizada;

                    var locacaoFuncionarios = new LocacaoFuncionarios(
                        Guid.Parse(idLocacao),
                        funcionarioId,
                        "Alterou locação para Finalizada."
                    );

                    locacaoController.AtualizarLocacao(idLocacao, DateTime.Now, status, locacaoFuncionarios);
                    Console.Clear();
                    Console.WriteLine("Locação atualizada com sucesso!");
                    Console.WriteLine(locacaoController.BuscarLocacaoId(idLocacao));
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
