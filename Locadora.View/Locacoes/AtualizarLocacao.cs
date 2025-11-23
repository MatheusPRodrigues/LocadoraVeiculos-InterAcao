using Locadora.Controller;
using Locadora.Models.Enums;
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
        public void FormAtualizarLocacao(LocacaoController locacaoController)
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
                    new ListarLocacoes().ListarTodasLocacoes(locacaoController);
                    Console.WriteLine("Informe o ID da locação que deseja atualizar:");
                    var idLocacao = Console.ReadLine();

                    var status = EStatusLocacao.Finalizada;

                    locacaoController.AtualizarLocacao(idLocacao, DateTime.Now, status);
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
