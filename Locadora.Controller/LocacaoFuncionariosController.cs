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
    public class LocacaoFuncionariosController : ILocacaoFuncionariosController
    {
        public void AdicionarLocacaoFuncionarios(LocacaoFuncionarios locacaoFuncionarios, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                var command = new SqlCommand(LocacaoFuncionarios.INSERTLOCACAOFUNIONARIOS, connection, transaction);
                command.Parameters.AddWithValue("@LocacaoID", locacaoFuncionarios.LocacaoID);
                command.Parameters.AddWithValue("@FuncionarioID", locacaoFuncionarios.FuncionarioID);
                command.Parameters.AddWithValue("@Descricao", locacaoFuncionarios.Descricao);
                command.Parameters.AddWithValue("@DataAlteracao", locacaoFuncionarios.DataAlteracao);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro de BD ao relacionar funcionário a locação: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de gênerico ao relacionar funcionário a locação: " + ex.Message);
            }
        }

        public List<LocacaoFuncionarios> BuscarLocacaoFuncionarios(string locacaoId)
        {
            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                try
                {
                    var locacaoFuncionarios = new List<LocacaoFuncionarios>();
                    using (var command = new SqlCommand(LocacaoFuncionarios.SELECTLOCACAOFUNCIONARIOSPORLOCACAOID, connection))
                    {
                        command.Parameters.AddWithValue("@IdLocacao", locacaoId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var lf = new LocacaoFuncionarios(
                                    reader.GetString(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetDateTime(3)
                                );
                                locacaoFuncionarios.Add(lf);
                            }
                        }
                    }
                    return locacaoFuncionarios;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro do tipo SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro genérico: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
