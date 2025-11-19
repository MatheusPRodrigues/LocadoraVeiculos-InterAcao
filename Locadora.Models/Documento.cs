using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Documento
    {
        public int DocumentoID { get; private set; }
        public int ClienteID { get; private set; }
        public string TipoDocumento { get;  set; }
        public string Numero { get; private set; }
        public DateOnly DataEmissao { get; private set; }
        public DateOnly DataValidade { get; private set; }

        public Documento(
            int clienteID,
            string tipoDocumento,
            string numero,
            DateOnly dataEmissao,
            DateOnly dataValidade
        )
        {
            ClienteID = clienteID;
            TipoDocumento = tipoDocumento;
            Numero = numero;
            DataEmissao = dataEmissao;
            DataValidade = dataValidade;
        }

        public override string? ToString()
        {
            return $"Tipo: {TipoDocumento}\nNumero : {Numero}\nData de Emissão: {DataEmissao}\nData de Validade: {DataValidade}\n";
        }
    }
}
