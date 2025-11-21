using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface IVeiculoController
    {
        public void AdicionarVeiculo(Veiculo veiculo);

        public List<Veiculo> ListarTodosVeiculos();

        public Veiculo BuscarVeiculoPlaca(string placa);

        public void AtualizarStatusVeiculo(string statusVeiculo, string placa);

        public void DeletarVeiculo(int idVeiculo);        
    }
}
