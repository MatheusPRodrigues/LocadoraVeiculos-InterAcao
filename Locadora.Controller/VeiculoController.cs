using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class VeiculoController : IVeiculoController
    {
        public void AdicionarVeiculo(Veiculo veiculo)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                using (var command = new SqlCommand(Veiculo.INSERTVEICULO, connection, transaction))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@CategoriaID", veiculo.CategoriaID);
                        command.Parameters.AddWithValue("@Placa", veiculo.Placa);
                        command.Parameters.AddWithValue("@Marca", veiculo.Marca);
                        command.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                        command.Parameters.AddWithValue("@Ano", veiculo.Ano);
                        command.Parameters.AddWithValue("@StatusVeiculo", veiculo.StatusVeiculo);

                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao adicionar veículo no banco de dados: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao adicionar veículo: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void AtualizarStatusVeiculo(string statusVeiculo, string placa)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            var veiculo = BuscarVeiculoPlaca(placa);

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    using (var command = new SqlCommand(Veiculo.UPDATESTATUSVEICULO, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@StatusVeiculo", statusVeiculo);
                        command.Parameters.AddWithValue("@IdVeiculo", veiculo.VeiculoID);
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close(); 
                }
            }


        }

        public Veiculo BuscarVeiculoPlaca(string placa)
        {
            var categoriaController = new CategoriaController();

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            Veiculo veiculo = null;

            try
            {
                using (var command = new SqlCommand(Veiculo.SELECTVEICULABYPLACA, connection))
                {
                    command.Parameters.AddWithValue("@Placa", placa);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            veiculo = new Veiculo(
                                reader.GetInt32(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetInt32(5),
                                reader.GetString(6)
                            );
                            veiculo.SetVeiculoID(reader.GetInt32(0));
                            veiculo.SetNomeCategoria(
                                categoriaController.BuscarNomeCategoriaPorId(veiculo.CategoriaID)
                            );
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao encontrar veículo do banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar veículo: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
                    
            return veiculo ?? throw new Exception("Veículo não encontrado!");
        }

        public void DeletarVeiculo(int idVeiculo)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    using (var command = new SqlCommand(Veiculo.DELETEVEICULO, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@IdVeiculo", idVeiculo);
                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback(); 
                    Console.WriteLine("Erro ao excluir veículo no banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 
                    Console.WriteLine("Erro ao excluir veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Veiculo> ListarTodosVeiculos()
        {
            var categoriaController = new CategoriaController();
            var veiculos = new List<Veiculo>();

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            try
            {
                using (var command = new SqlCommand(Veiculo.SELECTALLVEICULO, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var veiculo = new Veiculo(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetInt32(4),
                                reader.GetString(5)
                            );

                            veiculo.SetNomeCategoria(
                                categoriaController.BuscarNomeCategoriaPorId(veiculo.CategoriaID)
                            );

                            veiculos.Add(veiculo);
                        }
                    }
                    return veiculos;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar veículos do banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar veículos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
