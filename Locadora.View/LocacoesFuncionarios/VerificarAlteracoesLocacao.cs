using Locadora.Controller;
using Locadora.View.Locacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.LocacoesFuncionarios
{
    public class VerificarAlteracoesLocacao
    {
        public void VerificarAlteracaoLocacao(LocacaoController locacaoController)
        {
            try
            {
                if (locacaoController.ListarLocacao().Count() == 0)
                {
                    Console.WriteLine("Não há locacões registradas no sistema!");
                }
                else
                {
                    new ListarLocacoes().ListarTodasLocacoes(locacaoController);
                    Console.WriteLine("Informe o ID da locação que deseja atualizar:");
                    var idLocacao = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("========= LOCAÇÃO SELECIONADA =========");
                    Console.WriteLine(locacaoController.BuscarLocacaoId(idLocacao));

                    var lfController = new LocacaoFuncionariosController();
                    var lfList = lfController.BuscarLocacaoFuncionarios(idLocacao);
                    Console.WriteLine("======== ALTERAÇOES NA LOCAÇÃO ========");
                    foreach (var lf in lfList)
                    {
                        Console.WriteLine(lf);
                        Console.WriteLine("=======================================");
                    }
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
