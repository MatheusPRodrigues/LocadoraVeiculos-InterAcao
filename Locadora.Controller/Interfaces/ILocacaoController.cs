using Locadora.Models;
using Locadora.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface ILocacaoController
    {
        public void AdicionarLocacao(Locacao locacao, LocacaoFuncionarios locacaoFuncionarios);

        public void AtualizarLocacao(string locacaoId, DateTime dataDevolucaoReal, EStatusLocacao status, LocacaoFuncionarios locacaoFuncionarios);

        public Locacao BuscarLocacaoId(string locacaoId);

        public List<Locacao> ListarLocacao();

        public void CancelarLocacao(string locacaoId, LocacaoFuncionarios locacaoFuncionarios);
    }
}
