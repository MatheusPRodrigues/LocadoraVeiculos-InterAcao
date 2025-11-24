using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Helpers
    {
        public static void PressionerEnterParaContinuar()
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        public static decimal LerDecimal(string mensagem)
        {
            decimal valor;
            while (true)
            {
                Console.Write(mensagem);
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out valor) && valor >= 0)
                {
                    return valor;
                }
                Console.WriteLine("Valor inválido, tente novamente.");
            }
        }
    }
}
