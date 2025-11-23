using Locadora.Controller;
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
        public void FormCancelarLocacao(LocacaoController locacaoController)
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
                    new ListarLocacoes().ListarTodasLocacoes(locacaoController);
                    Console.WriteLine("Informe o ID da locação para cancelar:");
                    var idLocacao = Console.ReadLine();

                    locacaoController.CancelarLocacao(idLocacao);
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
