using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;
using System.Net.Http.Headers;

#region "Cliente e Documentos"
var cliente = new Cliente("Rodrigo", "rodrigo@gmail.com");
var documento = new Documento("RG", "4254515151", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

//Console.WriteLine(cliente);

//try
//{
//    clienteController.AdicionarCliente(cliente, documento);
//    Console.WriteLine("Cliente adicionado com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//documento = new Documento("RG", "3231231231", new DateOnly(2025, 10, 11), new DateOnly(2032, 05, 20));

//try
//{
//    clienteController.AtualizarDocumentoCliente(documento, "maria.souza@email.com");
//    Console.WriteLine("Documento do cliente atualizado com sucesso!");
//    Console.WriteLine(clienteController.BuscarClientePorEmail("maria.souza@email.com"));
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var listaDeClientes = clienteController.ListarTodosClientes();
//    foreach (var c in listaDeClientes)
//    {
//        Console.WriteLine(c);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//clienteController.AtualizarTelefoneCliente("169978403821", "julia@uol.com");
//Console.WriteLine(clienteController.BuscarClientePorEmail("julia@uol.com"));

//try
//{
//    clienteController.ExcluirCliente("roberta@uol.com");
//    Console.WriteLine("Cliente excluído com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region "Categoria e Veículos"

var categoriaController = new CategoriaController();

var categoria = new Categoria("Esportivo", 499.90m);

//try
//{
//    categoriaController.AdicionarCategoria(categoria);
//    Console.WriteLine("Categoria adicionada com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var categorias = categoriaController.ListarTodasCategorias();
//    foreach (var c in categorias)
//    {
//        Console.WriteLine(c);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var categoriaBuscada = categoriaController.BuscarCategoriaPorNome("Esportivo");
//    if (categoriaBuscada is not null)
//        Console.WriteLine(categoriaBuscada);
//    else
//        Console.WriteLine("Categoria não encontrada!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var categoriaParaAtualizar = new Categoria("Esportivo", "Veículos de alto desempenho", 569.90m);
//    categoriaController.AtualizarCategoria(categoriaParaAtualizar);
//    Console.WriteLine("Categoria atualizada com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    categoriaController.DeletarCategoria("Econômico");
//    Console.WriteLine("Categoria excluída com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

var veiculoController = new VeiculoController();

//try
//{
//    var veiculo = new Veiculo(1, "XYZ-9876", "Chevrolet", "S10", 2025, EStatusVeiculo.Disponivel.ToString());
//    veiculoController.AdicionarVeiculo(veiculo);
//    Console.WriteLine("Veículo adicionado com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var veiculos = veiculoController.ListarTodosVeiculos();
//    foreach (var v in veiculos)
//    {
//        Console.WriteLine(v);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var veiculo = veiculoController.BuscarVeiculoPlaca("XYZ-9876");
//    Console.WriteLine(veiculo);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex);
//}

//try
//{
//    var veiculo = veiculoController.BuscarVeiculoPlaca("XYZ-9876");
//    veiculoController.DeletarVeiculo(veiculo.VeiculoID);
//    Console.WriteLine("Veículo excluído com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex);
//}

//try
//{
//    veiculoController.AtualizarStatusVeiculo(EStatusVeiculo.Manutencao.ToString(), "MKO7890");
//    Console.WriteLine("Veículo alterado com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion

#region "Funcionarios"


#endregion