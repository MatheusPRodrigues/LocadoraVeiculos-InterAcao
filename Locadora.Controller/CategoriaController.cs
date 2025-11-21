using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class CategoriaController
    {
        public void AdicionarCategoria(Categoria categoria)
        {
            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand(Categoria.INSERTCATEGORIA, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Nome", categoria.Nome);
                            command.Parameters.AddWithValue("@Descricao", String.IsNullOrEmpty(categoria.Descricao) ?
                                                                            DBNull.Value : categoria.Descricao);
                            command.Parameters.AddWithValue("@Diaria", categoria.Diaria);
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro do tipo SQL ao tentar adicionar categoria: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro do tipo genérico ao tentar adicionar categoria: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public List<Categoria> ListarTodasCategorias()
        {
            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand(Categoria.SELECTALLCATEGORIA, connection))
                    {
                        var reader = command.ExecuteReader();
                        var categorias = new List<Categoria>();
                        using (reader)
                        {
                            while (reader.Read())
                            {
                                var categoria = new Categoria(
                                    reader["Nome"].ToString(),
                                    decimal.Parse(reader["Diaria"].ToString()),
                                    reader["Descricao"] != DBNull.Value ?
                                                            reader["Descricao"].ToString() : null
                                );
                                categorias.Add(categoria);
                            }
                        }
                        return categorias;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro do tipo SQL ao tentar listar todas categorias: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro do tipo genérico ao tentar listar todas categorias: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Categoria BuscarCategoriaPorNome(string nome)
        {
            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand(Categoria.SELECTCATEGORIAPORNOME, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nome);
                        var reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                var categoria = new Categoria(
                                    reader["Nome"].ToString(),
                                    decimal.Parse(reader["Diaria"].ToString()),
                                    reader["Descricao"] != DBNull.Value ?
                                                            reader["Descricao"].ToString() : null
                                );
                                categoria.SetCategoriaID(Convert.ToInt32(reader["CategoriaID"]));
                                return categoria;
                            }
                            return null;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro do tipo SQL ao tentar buscar categoria: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro do tipo genérico ao tentar buscar categoria: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public string BuscarNomeCategoriaPorId(int id)
        {
            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand(Categoria.SELECTNOMECATEGORIAPORID, connection))
                    {
                        command.Parameters.AddWithValue("@IdCategoria", id);
                        var reader = command.ExecuteReader();
                        using (reader)
                        {
                            var nomeCategoria = String.Empty;
                            if (reader.Read())
                            {
                                nomeCategoria = reader["Nome"].ToString();
                            }
                            return nomeCategoria;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro do tipo SQL ao tentar buscar nome categoria: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro do tipo genérico ao tentar buscar nome categoria: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            var categoriaBuscada = BuscarCategoriaPorNome(categoria.Nome);
            if (categoriaBuscada == null)
            {
                throw new Exception("Categoria não foi encontrada!");
            }

            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand(Categoria.UPDATECATEGORIA, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                            command.Parameters.AddWithValue("@Diaria", categoria.Diaria);
                            command.Parameters.AddWithValue("@IdCategoria", categoriaBuscada.CategoriaID);
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro do tipo SQL ao tentar atualizar categoria: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro do tipo genérico ao tentar atualizar categoria: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void DeletarCategoria(string nome)
        {
            var categoriaBuscada = BuscarCategoriaPorNome(nome);
            if (categoriaBuscada == null)
            {
                throw new Exception("Categoria não foi encontrada!");
            }

            using (var connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand(Categoria.DELETECATEGORIA, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@IdCategoria", categoriaBuscada.CategoriaID);
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro do tipo SQL ao tentar deletar categoria: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro do tipo genérico ao tentar deletar categoria: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}

