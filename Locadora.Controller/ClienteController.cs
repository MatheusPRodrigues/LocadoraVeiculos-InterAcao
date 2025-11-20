using Locadora.Models;
using Microsoft.Data.SqlClient;
using System.Transactions;
using Utils.Databases;

namespace Locadora.Controller
{
    public class ClienteController
    {
        public void AdicionarCliente(Cliente cliente)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            // Tipo de dado SqlTransaction
            using (var transaction = connection.BeginTransaction())
            {
                try
                {

                    // Como é uma propriedade estática é necessário pegar pela classe
                    var command = new SqlCommand(Cliente.INSERTCLIENTE, connection, transaction); //Necessário passar o objeto de transaction
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);

                    var clienteId = Convert.ToInt32(command.ExecuteScalar());
                    cliente.SetClienteID(clienteId);
                    //cliente.SetClienteID(Convert.ToInt32(command.ExecuteScalar()));

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro de SQL Server ao adicionar cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro de genérico ao adicionar cliente: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Cliente> ListarTodosClientes()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            try
            {
                connection.Open();
                var command = new SqlCommand(Cliente.SELECTALLCLIENTES, connection);
                var reader = command.ExecuteReader();

                var listaClientes = new List<Cliente>();
                while (reader.Read())
                {
                    var cliente = new Cliente(
                        reader["Nome"].ToString(),
                        reader["Email"].ToString(),
                        reader["Telefone"] != DBNull.Value ?
                                            reader["Telefone"].ToString() : null
                    );
                    cliente.SetClienteID(Convert.ToInt32(reader["ClienteID"]));
                    listaClientes.Add(cliente);
                }
                return listaClientes;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro de SQL Server ao listar clientes: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de genérico ao listar cliente: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public Cliente BuscarClientePorEmail(string email)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                var command = new SqlCommand(Cliente.SELECTCLIENTEPOREMAIL, connection);
                command.Parameters.AddWithValue("@Email", email);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var cliente = new Cliente(
                        reader["Nome"].ToString(),
                        reader["Email"].ToString(),
                        reader["Telefone"] != DBNull.Value ?
                                            reader["Telefone"].ToString() : null
                    );
                    cliente.SetClienteID(Convert.ToInt32(reader["ClienteID"]));
                    return cliente;
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro de SQL ao buscar cliente por email: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro genérico ao buscar cliente por email: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void AtualizarTelefoneCliente(string telefone, string email)
        {
            var clienteEncontrado = BuscarClientePorEmail(email);
            if (clienteEncontrado is null)
            {
                throw new Exception("Cliente não pode ser encontrado para atualização!");
            }

            clienteEncontrado.SetTelefone(telefone);

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                var command = new SqlCommand(Cliente.UPDATEFONECLIENTE, connection);
                command.Parameters.AddWithValue("@Telefone", clienteEncontrado.Telefone);
                command.Parameters.AddWithValue("@IdCliente", clienteEncontrado.ClienteID);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro de SQL ao atualizar telefone do cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro genérico ao atualizar telefone do cliente: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public Cliente ExcluirCliente(string email)
        {
            var clienteEncontrado = BuscarClientePorEmail(email);
            if (clienteEncontrado is null)
            {
                throw new Exception("Cliente não pode ser encontrado para exclusão!");
            }

            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand(Cliente.DELETECLIENTE, connection))
                    {
                        command.Parameters.AddWithValue("@IdCliente", clienteEncontrado.ClienteID);
                        command.ExecuteNonQuery();
                        return clienteEncontrado;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro de SQL ao tentar deletar cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro genérico ao tentar deletar cliente: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
