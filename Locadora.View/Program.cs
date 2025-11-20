using Locadora.Controller;
using Locadora.Models;

var cliente = new Cliente("Julia", "julia@uol.com");
//var documento = new Documento(1, "RG", "123456789", new DateOnly(2020, 1, 1), new DateOnly(2030, 1, 1));

//Console.WriteLine(cliente);

var clienteController = new ClienteController();
//try
//{
//    clienteController.AdicionarCliente(cliente);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

try
{
    var listaDeClientes = clienteController.ListarTodosClientes();
    foreach (var c in listaDeClientes)
    {
        Console.WriteLine(c);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//clienteController.AtualizarTelefoneCliente("169978403821", "julia@uol.com");
//Console.WriteLine(clienteController.BuscarClientePorEmail("julia@uol.com"));

//try
//{
//    var clienteExcluido = clienteController.ExcluirCliente("roberta@uol.com");
//    Console.WriteLine("Cliente excluído com sucesso!");
//    Console.WriteLine(clienteExcluido);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}