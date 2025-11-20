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
    public class DocumentoController
    {
        public void AdicionarDocumento(Documento documento, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                var command = new SqlCommand(Documento.INSERTDOCUMENTO, connection, transaction);
                command.Parameters.AddWithValue("@ClienteID", documento.ClienteID);
                command.Parameters.AddWithValue("@TipoDocumento", documento.TipoDocumento);
                command.Parameters.AddWithValue("@Numero", documento.Numero);
                command.Parameters.AddWithValue("@DataEmissao", documento.DataEmissao);
                command.Parameters.AddWithValue("@DataValidade", documento.DataValidade);

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro de SQL Server ao adicionar cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de genérico ao adicionar cliente: " + ex.Message);
            }
        }
    }
}
