using Locadora.Controller;
using Locadora.View.Clientes;
using Locadora.View.Categorias;

namespace Locadora.View.Categorias
{
    public class CategoriasMenu
    {
        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("=============== MENU DE CATEGORIAS ===============");
            Console.WriteLine("1 -> Adicionar Categoria");
            Console.WriteLine("2 -> Listar todas Categorias");
            Console.WriteLine("3 -> Atualizar Categoria");
            Console.WriteLine("4 -> Excluir Categoria");
            Console.WriteLine("0 -> Retornar ao menu anterior");
            Console.WriteLine("================================================");
            Console.Write("-> ");
        }

        public void MenuDeCategorias()
        {
            var categoriaController = new CategoriaController();
            var opcao = "";
            var repetirMenu = true;
            do
            {
                ExibirMenu();
                opcao = Console.ReadLine() ?? "-1";

                switch (opcao)
                {
                    case "1":
                        var addCategoria = new AdicionarCategoria();
                        addCategoria.FormAddCategoria(categoriaController);
                        break;
                    case "2":
                        var listarCategorias = new ListarCategorias();
                        listarCategorias.ListarTodasCategorias(categoriaController);
                        break;
                    case "3":
                        var attCategoria = new AtualizarCategoria();
                        attCategoria.AtualizarUmaCategoria(categoriaController);
                        break;
                    case "4":
                        var excluirCategoria = new ExcluirCategoria();
                        excluirCategoria.ExcluirUmaCategoria(categoriaController);
                        break;
                    case "0":
                        repetirMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Selecione uma das opções do menu!");
                        break;
                }
            }
            while (repetirMenu);
        }
    }
}
