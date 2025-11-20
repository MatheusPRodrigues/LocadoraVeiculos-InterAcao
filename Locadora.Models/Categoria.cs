using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Categoria
    {
        public int CategoriaID { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Diaria { get; private set; }
    }
}
