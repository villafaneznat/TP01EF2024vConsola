using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01EF2024.Shared
{
    public static class ConsoleExtensions
    {
        public static string ReadString(string message)
        {
            string? stringVar = string.Empty;
            while (true)
            {
                Console.Write(message);
                stringVar = Console.ReadLine();
                if (stringVar == null)
                {
                    Console.WriteLine("Debe ingresar algo.");
                }
                else
                {
                    break;
                }
            }
            return stringVar;
        }
        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }
        public static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número decimal válido.");
                }
            }
        }
        public static void Enter()
        {
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();

        }
        public static string GetValidOptions(string message, List<string>? options)
        {
            string answer = string.Empty;
            if (options != null)
            {
                options.Insert(0, "N");
                do
                {
                    answer = ReadString(message);

                    if (!options.Any(x => x.Equals(answer)))
                    {
                        Console.WriteLine("\nIngreso no válido... Otra vez!!!");
                    }
                    else
                    {
                        /*
                         * Si la opción tipiada es alguna de la lista, salgo del ciclo
                         */
                        break;

                    }

                } while (!options.Any(x => x.Equals(answer)));// mientras no sea un caracter válido me quedo esperando

            }
            return answer; //retorno el caracter ingresado y validado.

        }
    }
}
