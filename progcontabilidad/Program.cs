using System;

internal class Program
{
    private static void Main(string[] arg)
    {
        // cuentas y saldos
        string[] titulares = { "Juan Pérez", "Ana Gómez", "Carlos Rodríguez" };
        double[] saldos = { 5000, 2000, 15000 };

        while (true)
        {
            // Mostrar cuentas
            Console.WriteLine("\nCuentas disponibles:");
            for (int i = 0; i < titulares.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {titulares[i]}");
            }

            // Mostrar estado de todas las cuentas
            Console.WriteLine("0. Ver estado de todas las cuentas");

            // Seleccionar cuentas
            int cuentaSeleccionada = -1;
            while (cuentaSeleccionada < 0 || cuentaSeleccionada > 3)
            {
                Console.Write("\nElige una cuenta ");
                bool esNumeroValido = int.TryParse(Console.ReadLine(), out cuentaSeleccionada);

                if (!esNumeroValido || cuentaSeleccionada < 0 || cuentaSeleccionada > 3)
                {
                    Console.WriteLine("Opción inválida, elige un valor entre 0 y 3");
                }
            }
            
            if (cuentaSeleccionada == 0)
            {
                // Consultar estado de todas las cuentas
                Console.WriteLine("\nEstado actual de todas las cuentas:");
                for (int i = 0; i < titulares.Length; i++)
                {
                    Console.WriteLine($"{titulares[i]}: {saldos[i]} USD");
                }
                continue; // Volver a mostrar el selector de cuentas
            }

            cuentaSeleccionada--;

            // Menu de operaciones
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Retirar dinero");
                Console.WriteLine("3. Depositar dinero");
                Console.WriteLine("4. Consultar estado de todas las cuentas");
                Console.WriteLine("5. Cambiar cuenta");
                Console.WriteLine("6. Salir");

                int opcion = -1;
                while (opcion < 1 || opcion > 6)
                {
                    Console.Write("\nElige una opcion entre 1 y 6: ");
                    bool esOpcionValida = int.TryParse(Console.ReadLine(), out opcion);

                    if (!esOpcionValida || opcion < 1 || opcion > 6)
                    {
                        Console.WriteLine("Opción inválida, elige un número válido");
                    }
                }

                switch (opcion)
                {
                    case 1:
                        // Consultar saldo 
                        Console.WriteLine($"Saldo actual de {titulares[cuentaSeleccionada]}: {saldos[cuentaSeleccionada]} USD");
                        break;
                    case 2:
                        // Retirar dinero con validación
                        Console.Write("Cantidad a retirar (ingrese 0 para volver al menu de operaciones): ");
                        double retiro = 0;
                        bool esRetiroValido = double.TryParse(Console.ReadLine(), out retiro);

                        if (esRetiroValido && retiro != 0)
                        {
                            if (retiro > 0 && retiro <= saldos[cuentaSeleccionada])
                            {
                                saldos[cuentaSeleccionada] -= retiro;
                                Console.WriteLine($"Retiro exitoso. Nuevo saldo: {saldos[cuentaSeleccionada]} USD");
                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente o cantidad inválida");
                            }
                        }
                        else if (retiro == 0)
                        {
                            Console.WriteLine("Volviendo al menu de operaciones...");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida");
                        }
                        break;
                    case 3:
                        // Depositar dinero con validación
                        Console.Write("Cantidad a depositar (ingrese 0 para volver al menu de operaciones): ");
                        double deposito = 0;
                        bool esDepositoValido = double.TryParse(Console.ReadLine(), out deposito);

                        if (esDepositoValido && deposito != 0)
                        {
                            if (deposito > 0)
                            {
                                saldos[cuentaSeleccionada] += deposito;
                                Console.WriteLine($"Depósito exitoso. Nuevo saldo: {saldos[cuentaSeleccionada]} USD");
                            }
                            else
                            {
                                Console.WriteLine("Cantidad inválida");
                            }
                        }
                        else if (deposito == 0)
                        {
                            Console.WriteLine("Volviendo al menu de operaciones...");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida");
                        }
                        break;
                    case 4:
                        // Consultar estado de todas las cuentas
                        Console.WriteLine("\nEstado actual de todas las cuentas:");
                        for (int i = 0; i < titulares.Length; i++)
                        {
                            Console.WriteLine($"{titulares[i]}: {saldos[i]} USD");
                        }
                        break;
                    case 5:
                        // Volver a las opciones de selección de cuenta
                        Console.WriteLine("Volviendo a la selección de cuentas...\n");
                        break;
                    case 6:
                        // Salir
                        Console.WriteLine("Gracias por usar el sistema.");
                        return;
                }

                // Volver a la selección de cuentas si el usuario elige la opción 5
                if (opcion == 5) break;
            }
        }
    }
}