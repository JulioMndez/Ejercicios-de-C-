using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Diccionario
{
    public class Program
    {
        static void     Main(string[] args)
        {
            List<Tuple<string, string>> diccionario = crearDiccionario();
            traducir(diccionario);
            Console.ReadKey();

        }

        public static List<Tuple<string, string>> crearDiccionario()
        {
            List<Tuple<string, string>> diccionario = new List<Tuple<string, string>>();
            for(int i = 0; i < 5; i++)
            {
                Console.Write($"Ingrese la palabra {i + 1} en inglés: ");
                string pal1 = Console.ReadLine();
                Console.Write($"Ingrese la palabra {i + 1} en español: ");
                string pal2 = Console.ReadLine();
                diccionario.Add(new Tuple <string, string>(pal1, pal2));

            }

            return (diccionario);
        }

        public static void traducir(List<Tuple<string, string>> diccionario)
        {
            Console.Write("Ingrese la palabra a traducir: ");
            string clave = Console.ReadLine();
            bool encontrado = false;

            foreach(var duo in diccionario)
            {
                if (duo.Item1.Equals(clave, StringComparison.OrdinalIgnoreCase)) 
                {
                    Console.Write($"La traducción de la palabra {clave} es: {duo.Item2}");
                    encontrado = true;
                    break;
                }
                if (duo.Item2.Equals(clave, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write($"La traducción de la palabra {clave} es: {duo.Item2}");
                    encontrado = true;
                    break;
                }

                if (!encontrado)
                {
                    Console.Write($"La palabra {clave} no se encontró...");
                }
            }
        }
    }
}
