using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<decimal> cuentas = new List<decimal>();
        int opcion;

        do
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ConsultarSaldo(cuentas);
                    break;
                case 2:
                    DepositarDinero(cuentas);
                    break;
                case 3:
                    RetirarDinero(cuentas);
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }

        } while (opcion != 4);
    }

    static void ConsultarSaldo(List<decimal> cuentas)
    {
        if (cuentas.Count == 0)
        {
            Console.WriteLine("No hay cuentas registradas.");
            return;
        }

        Console.WriteLine($"Su saldo es: {cuentas[0]:C}"); // Supone que solo hay una cuenta
    }

    static void DepositarDinero(List<decimal> cuentas)
    {
        Console.Write("Ingrese la cantidad a depositar: ");
        decimal cantidad = Convert.ToDecimal(Console.ReadLine());

        if (cuentas.Count == 0)
        {
            cuentas.Add(cantidad); // Si no hay cuentas, se crea una nueva
        }
        else
        {
            cuentas[0] += cantidad; // Se suma a la cuenta existente
        }

        Console.WriteLine($"Se han depositado: {cantidad:C}. Su nuevo saldo es: {cuentas[0]:C}");
    }

    static void RetirarDinero(List<decimal> cuentas)
    {
        if (cuentas.Count == 0)
        {
            Console.WriteLine("No hay cuentas registradas.");
            return;
        }

        Console.Write("Ingrese la cantidad a retirar: ");
        decimal cantidad = Convert.ToDecimal(Console.ReadLine());

        if (cantidad > cuentas[0])
        {
            Console.WriteLine("Saldo insuficiente.");
        }
        else
        {
            cuentas[0] -= cantidad;
            Console.WriteLine($"Se han retirado: {cantidad:C}. Su nuevo saldo es: {cuentas[0]:C}");
        }
    }
}
