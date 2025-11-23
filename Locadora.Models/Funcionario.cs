using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Funcionario
    {
        public readonly static string INSERTFUNCIONARIO = @"INSERT INTO tblFuncionarios(Nome, CPF, Email, Salario)
                                                            VALUES (@Nome, @CPF, @Email, @Salario);";

        public readonly static string SELECTFUNCIONARIOPORCPF = @"SELECT FuncionarioID, Nome, CPF, Email, Salario
                                                                  FROM tblFuncionarios
                                                                  WHERE CPF = @CPF;";

        public readonly static string SELECTTODOSFUNCIONARIOS = @"SELECT Nome, CPF, Email, Salario
                                                                  FROM tblFuncionarios;";

        public readonly static string UPDATEFUNCIONARIOPORCPF = @"UPDATE tblFuncionarios
                                                                  SET Salario = @Salario
                                                                  WHERE FuncionarioID = @IdFuncionario;";

        public readonly static string DELETEFUNCIONARIOPORCPF = @"DELETE FROM tblFuncionarios
                                                                  WHERE FuncionarioID = @IdFuncionario;";

        public int FuncionarioID { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public decimal Salario { get; private set; }

        public Funcionario(string nome, string cpf, string email)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
        }

        public Funcionario(
            string nome,
            string cpf,
            string email,
            decimal salario
        ) : this(nome, cpf, email)
        {
            Salario = salario;
        }

        public void SetFuncionarioID(int funcionarioID)
        {
            FuncionarioID = funcionarioID;
        }

        public override string? ToString()
        {
            return $"Nome: {Nome}\nCPF: {CPF}\nEmail: {Email}\nSalário: {Salario:c}\n";
        }
    }
}
