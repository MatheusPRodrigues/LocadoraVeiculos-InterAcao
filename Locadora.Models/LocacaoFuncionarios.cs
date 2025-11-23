using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class LocacaoFuncionarios
    {
        public static readonly string INSERTLOCACAOFUNIONARIOS = @"
                                                                  INSERT INTO tblLocacaoFuncionarios 
                                                                  (LocacaoID, FuncionarioID, Descricao, DataAlteracao) VALUES
                                                                  (@LocacaoID, @FuncionarioID, @Descricao, @DataAlteracao)";

        public static readonly string SELECTLOCACAOFUNCIONARIOSPORLOCACAOID = @"
                                                                                SELECT
	                                                                                f.Nome, f.CPF,
	                                                                                lf.Descricao, lf.DataAlteracao
                                                                                FROM tblLocacaoFuncionarios lf
                                                                                LEFT JOIN tblFuncionarios f
                                                                                ON lf.FuncionarioID = f.FuncionarioID
                                                                                JOIN tblLocacoes l
                                                                                ON lf.LocacaoID = l.LocacaoID
                                                                                WHERE lf.LocacaoID = @IdLocacao
                                                                              ";

        public int ID { get; private set; }
        public Guid LocacaoID { get; private set; }
        public int FuncionarioID { get; private set; }
        public string NomeFuncionario { get; private set; }
        public string CPFFuncionario { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        public LocacaoFuncionarios(
            Guid locacaoID,
            int funcionarioID,
            string descricao
        )
        {
            LocacaoID = locacaoID;
            FuncionarioID = funcionarioID;
            Descricao = descricao;
            DataAlteracao = DateTime.Now;
        }

        public LocacaoFuncionarios(
            string nomeFuncionario,
            string cpfFuncionario,
            string descricao,
            DateTime dataAlteracao
        )
        {
            NomeFuncionario = nomeFuncionario;
            CPFFuncionario = cpfFuncionario;
            Descricao = descricao;
            DataAlteracao = dataAlteracao;
        }

        public override string? ToString()
        {
            return $"Funcionário: {NomeFuncionario}\n" +
                $"CPF: {CPFFuncionario}\n" +
                $"Alteração: {Descricao}\n" +
                $"Data da alteração: {DataAlteracao}";
        }
    }
}
