using Locadora.Models;

namespace Locadora.Controller.Interfaces
{
    public interface IFuncionarioController
    {
        public void AdicionarFuncionario(Funcionario funcionario);

        public Funcionario BuscarFuncionarioPorCPF(string cpf);

        public List<Funcionario> ListarTodosFuncionarios();

        public void AtualizarFuncionarioPorCPF(decimal salario, string cpf);

        public void DeletarFuncionarioPorCPF(string cpf);
    }
}
