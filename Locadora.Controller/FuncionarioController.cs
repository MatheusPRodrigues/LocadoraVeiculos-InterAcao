using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Databases;

namespace Locadora.Controller
{
    public class FuncionarioController : IFuncionarioController
    {
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand(Funcionario.INSERTFUNCIONARIO, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                            command.Parameters.AddWithValue("@CPF", funcionario.CPF);
                            command.Parameters.AddWithValue("@Email", funcionario.Email);
                            command.Parameters.AddWithValue("@Salario", funcionario.Salario == 0 ? DBNull.Value : funcionario.Salario);

                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao inserir funcionário no banco de dados: " + ex.Message);
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao inserir funcionário: " + e.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }


        public void AtualizarFuncionarioPorCPF(decimal salario, string cpf)
        {
            var funcionario = BuscarFuncionarioPorCPF(cpf) ?? throw new Exception("Funcionário não encontrado!");

            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand(Funcionario.UPDATEFUNCIONARIOPORCPF, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Salario", salario == 0 ? DBNull.Value : salario);
                            command.Parameters.AddWithValue("@idFuncionario", funcionario.FuncionarioID);

                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao atualziar funcionário: " + ex.Message);
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao atualziar funcionário: " + e.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public Funcionario BuscarFuncionarioPorCPF(string cpf)
        {
            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand(Funcionario.SELECTFUNCIONARIOPORCPF, connection))
                    {
                        command.Parameters.AddWithValue("@CPF", cpf);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var funcionario = new Funcionario(
                                                                    reader["Nome"].ToString(),
                                                                    reader["CPF"].ToString(),
                                                                    reader["Email"].ToString(),
                                                                    reader["Salario"] != DBNull.Value ?
                                                                    decimal.Parse(reader["Salario"].ToString()) : 0
                                );
                                funcionario.SetFuncionarioID((int)reader["FuncionarioID"]);
                                return funcionario;
                            }
                            return null;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao buscar funcionário: " + ex.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro inesperado ao buscar funcionário: " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeletarFuncionarioPorCPF(string cpf)
        {
            var funcionario = BuscarFuncionarioPorCPF(cpf) ?? throw new Exception("Funcionário não encontrado.");

            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand(Funcionario.DELETEFUNCIONARIOPORCPF, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@IdFuncionario", funcionario.FuncionarioID);

                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao deletar funcionário: " + ex.Message);
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao deletar funcionário: " + e.Message);
                    }
                    finally
                    {
                        connection.Close(); 
                    }
                }
            }
        }

        public List<Funcionario> ListarTodosFuncionarios()
        {
            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand(Funcionario.SELECTTODOSFUNCIONARIOS, connection))
                    {
                        List<Funcionario> funcionarios = new List<Funcionario>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                funcionarios.Add(new Funcionario(reader["Nome"].ToString(),
                                                                 reader["CPF"].ToString(),
                                                                 reader["Email"].ToString(),
                                                                 reader["Salario"] != DBNull.Value ?
                                                                 decimal.Parse(reader["Salario"].ToString()) : 0)
                                );
                            }
                            return funcionarios;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao listar funcionários: " + ex.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro inesperado ao listar funcionários: " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
