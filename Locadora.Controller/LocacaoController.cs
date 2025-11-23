using Locadora.Controller.Interfaces;
using Locadora.Models;
using Locadora.Models.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Databases;

namespace Locadora.Controller
{
    public class LocacaoController : ILocacaoController
    {
        public void AdicionarLocacao(Locacao locacao, LocacaoFuncionarios locacaoFuncionarios)
        {
            using var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            {
                connection.Open();

                using var transaction = connection.BeginTransaction();
                {
                    try
                    {
                        var command = new SqlCommand(Locacao.sp_AdicionarLocacao, connection, transaction);

                        command.Parameters.AddWithValue("@LocacaoID", locacao.LocacaoID);
                        command.Parameters.AddWithValue("@ClienteId", locacao.ClienteID);
                        command.Parameters.AddWithValue("@VeiculoId", locacao.VeiculoID);
                        command.Parameters.AddWithValue("@DataDevolucaoPrevista", locacao.DataDevolucaoPrevista);
                        command.Parameters.AddWithValue("@DataDevolucaoReal",
                            locacao.DataDevolucaoReal ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ValorDiaria", locacao.ValorDiaria);
                        command.Parameters.AddWithValue("@ValorTotal", locacao.ValorTotal);
                        command.Parameters.AddWithValue("@Multa", locacao.Multa);
                        command.Parameters.AddWithValue("@Status", locacao.Status.ToString());

                        command.ExecuteNonQuery();

                        var locacaoFuncionariosController = new LocacaoFuncionariosController();
                        locacaoFuncionariosController.AdicionarLocacaoFuncionarios(locacaoFuncionarios, connection, transaction);

                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao adicionar cliente: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao adicionar cliente: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void AtualizarLocacao(string locacaoId, DateTime dataDevolucaoReal, EStatusLocacao status, LocacaoFuncionarios locacaoFuncionarios)
        {
            var locacao = BuscarLocacaoId(locacaoId);
            var dataDevolucao = dataDevolucaoReal.Day - locacao.DataDevolucaoPrevista.Value.Day;

            if (dataDevolucao > 0)
                locacao.SetMulta(dataDevolucao * locacao.ValorDiaria);

            locacao.SetStatus(status);

            using var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            {
                connection.Open();

                using var transaction = connection.BeginTransaction();
                {
                    try
                    {
                        var command = new SqlCommand(Locacao.sp_AtualizarLocacao, connection, transaction);
                        command.Parameters.AddWithValue("@idLocacao", locacao.LocacaoID);
                        command.Parameters.AddWithValue("@DataDevolucaoReal", dataDevolucaoReal);
                        command.Parameters.AddWithValue("@Status", locacao.Status);
                        command.Parameters.AddWithValue("@Multa", locacao.Multa);

                        command.ExecuteNonQuery();

                        var locacaoFuncionariosController = new LocacaoFuncionariosController();
                        locacaoFuncionariosController.AdicionarLocacaoFuncionarios(locacaoFuncionarios, connection, transaction);

                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao atualizar locacao: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao atualizar a locacao: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public Locacao BuscarLocacaoId(string locacaoId)
        {
            Locacao locacao = null;
            using var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            {
                connection.Open();
                try
                {
                    var command = new SqlCommand(Locacao.sp_BuscarLocacaoId, connection);
                    command.Parameters.AddWithValue("@idLocacao", locacaoId);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        locacao = new Locacao(
                           reader.GetString(1),
                           reader.GetString(2),
                           reader.GetDateTime(3),
                           reader.GetDateTime(4),
                           reader["DataDevolucaoReal"] == DBNull.Value ? null : reader.GetDateTime(5),
                           reader.GetDecimal(6),
                           reader.GetDecimal(7),
                           reader.GetDecimal(8)
                       );
                        locacao.SetLocacaoID(reader.GetString(0));
                        locacao.SetStatus(Enum.Parse<EStatusLocacao>(reader.GetString(9)));
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao localizar locacao: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao localizar locacao: " + ex.Message);
                }
            }
            return locacao ?? throw new Exception("Nao foi possivel localizar a locacao!");
        }

        public void CancelarLocacao(string locacaoId, LocacaoFuncionarios locacaoFuncionarios)
        {
            var locacao = this.BuscarLocacaoId(locacaoId) ?? throw new Exception("Locação não foi encontrada");

            if (locacao.Status == EStatusLocacao.Cancelada)
                throw new Exception("Locação já está cancelada");
            
            if (locacao.Status == EStatusLocacao.Finalizada)
                throw new Exception("Locação já foi finalizada");

            using var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            {
                connection.Open();

                using var transaction = connection.BeginTransaction();
                {
                    try
                    {
                        var command = new SqlCommand(Locacao.sp_CancelarLocacao, connection, transaction);
                        command.Parameters.AddWithValue("@idLocacao", locacaoId);
                        command.Parameters.AddWithValue("@Status", EStatusLocacao.Cancelada.ToString());

                        command.ExecuteNonQuery();

                        var locacaoFuncionariosController = new LocacaoFuncionariosController();
                        locacaoFuncionariosController.AdicionarLocacaoFuncionarios(locacaoFuncionarios, connection, transaction);

                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao Cancelar Locacao: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao Cancelar Locacao: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public List<Locacao> ListarLocacao()
        {
            var locacoes = new List<Locacao>();
            using var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(Locacao.sp_BuscarLocacao, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var locacao = new Locacao(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDateTime(3),
                            reader.GetDateTime(4),
                            reader["DataDevolucaoReal"] == DBNull.Value ? null : reader.GetDateTime(5),
                            reader.GetDecimal(6),
                            reader.GetDecimal(7),
                            reader.GetDecimal(8)
                        );
                        locacao.SetLocacaoID(reader.GetString(0));
                        locacao.SetStatus(Enum.Parse<EStatusLocacao>(reader.GetString(9)));
                        locacoes.Add(locacao);
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao listar locacoes: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao listar locacoes: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return locacoes ?? throw new Exception("Nao foi possivel localizar a locacao!");
            }
        }
    }
}
