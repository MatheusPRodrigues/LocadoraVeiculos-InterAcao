using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface ILocacaoFuncionariosController
    {
        public void AdicionarLocacaoFuncionarios(LocacaoFuncionarios locacaoFuncionarios, SqlConnection connection, SqlTransaction transaction);

        public List<LocacaoFuncionarios> BuscarLocacaoFuncionarios(string locacaoId);
    }
}
