using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Categoria
    {
        public static readonly string INSERTCATEGORIA = @"INSERT INTO tblCategorias (Nome, Descricao, Diaria) VALUES
                                                        (@Nome, @Descricao, @Diaria)";

        public static readonly string SELECTALLCATEGORIA = @"SELECT * FROM tblCategorias";

        public static readonly string SELECTCATEGORIAPORNOME = @"SELECT * FROM tblCategorias WHERE Nome = @Nome";

        public static readonly string SELECTNOMECATEGORIAPORID = @"SELECT Nome FROM tblCategorias WHERE CategoriaID = @IdCategoria";

        public static readonly string UPDATECATEGORIA = @"UPDATE tblCategorias SET
                                                            Descricao = @Descricao,
                                                            Diaria = @Diaria
                                                        WHERE CategoriaID = @IdCategoria";

        public static readonly string DELETECATEGORIA = @"DELETE FROM tblCategorias WHERE CategoriaID = @IdCategoria";

        public int CategoriaID { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; } 
        public decimal Diaria { get; private set; }

        public Categoria(string nome, decimal diaria)
        {
            Nome = nome;
            Diaria = diaria;
        }

        public Categoria(
            string nome,
            decimal diaria,
            string? descricao
        ) : this(nome, diaria)
        {
            Descricao = descricao;
        }

        public void SetCategoriaID(int categoriaId)
        {
            CategoriaID = categoriaId;
        }

        public override string? ToString()
        {
            return $"Categoria: {Nome}\n" +
                $"Descrição: {(String.IsNullOrEmpty(Descricao) ? "Não possui descrição" : Descricao)}\n" +
                $"Valor Diária: {Diaria:C}\n";
        }
    }
}
