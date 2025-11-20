using Locadora.Controller;
using Locadora.Models;

var cliente = new Cliente("Rodrigo", "rodrigo@gmail.com");
var documento = new Documento("RG", "4254515151", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

//Console.WriteLine(cliente);

var clienteController = new ClienteController();
//try
//{
//    clienteController.AdicionarCliente(cliente, documento);
//    Console.WriteLine("Cliente adicionado com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

documento = new Documento("RG", "3231231231", new DateOnly(2025, 10, 11), new DateOnly(2032, 05, 20));

try
{
    clienteController.AtualizarDocumentoCliente(documento, "maria.souza@email.com");
    Console.WriteLine("Documento do cliente atualizado com sucesso!");
    Console.WriteLine(clienteController.BuscarClientePorEmail("maria.souza@email.com"));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

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