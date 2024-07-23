int opcion;
int valor;
int resultado;
string mensaje = "";

do
{
    Console.WriteLine("1. Dado un valor, devolver un mensaje que diga “El valor es mayor que 100” sólo cuando se cumpla dicha condición.");
    Console.WriteLine("2. Pedir un número entero por teclado y calcular si es par o impar.");
    Console.WriteLine("3. Teniendo un valor entero, verificar si se cumple o no que ese valor es el doble de un impar. Por ejemplo, 14 cumple con esta condición.");
    Console.WriteLine("4. Dada un número del 1 al 10, devolver su “versión” en números romanos.");
    Console.WriteLine("5. Salir");

    Console.WriteLine("\nElija la opción a realizar: ");
    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Ingrese una opción válida. Presione enter para continuar.");
        Console.ReadLine();
        Console.Clear(); // Limpiar la consola para comenzar de nuevo
        continue;
    }

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese un número entero:");
            if (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("\nNo ingresó una opción válida. Presione enter para continuar.");
                Console.ReadLine();
                Console.Clear(); // Limpiar la consola para comenzar de nuevo                
            }
            else
            {
                if (valor > 100)
                {
                    Console.WriteLine("\nEl valor es mayor que 100. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear(); // Limpiar la consola para comenzar de nuevo 
                }                    
            }
            break;
        case 2:
            Console.WriteLine("\nIngrese un número entero:");
            if (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("\nNo ingresó una opción válida. Presione enter para continuar.");
                Console.ReadLine();
                Console.Clear(); // Limpiar la consola para comenzar de nuevo                
            }
            else
            {
                if (valor % 2 == 0)
                    Console.Write($"\n{valor} es par.");
                else
                    Console.Write($"\n{valor} es impar.");

                Console.WriteLine("Presione enter para continuar.");
                Console.ReadLine();
                Console.Clear();
            }
            
            break;
        case 3:
            Console.WriteLine("\nIngrese un número entero:");
            if (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("\nNo ingresó una opción válida. Presione enter para continuar.");
                Console.ReadLine();
                Console.Clear(); // Limpiar la consola para comenzar de nuevo
                continue;
            }
            else
            {
                resultado = valor / 2;
                if (resultado % 2 != 0)
                {
                    Console.WriteLine($"\n{valor} es el doble de {resultado}. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            break;
        case 4:
            Console.WriteLine("\nIngrese un número entero del 1 al 10:");
            if (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("\nNo ingresó una opción válida. Presione enter para continuar.");
                Console.ReadLine();
                Console.Clear(); // Limpiar la consola para comenzar de nuevo
                continue;
            }
            else
            {
               if(valor>=1 && valor <= 10)
                {
                    switch (valor)
                    {
                        case 1:
                            mensaje = $"{valor} en números romanos es I";
                            break;
                        case 2:
                            mensaje = $"{valor} en números romanos es II";
                            break;
                        case 3:
                            mensaje = $"{valor} en números romanos es III";
                            break;
                        case 4:
                            mensaje = $"{valor} en números romanos es IV";
                            break;
                        case 5:
                            mensaje = $"{valor} en números romanos es V";
                            break;
                        case 6:
                            mensaje = $"{valor} en números romanos es VI";
                            break;
                        case 7:
                            mensaje = $"{valor} en números romanos es VII";
                            break;
                        case 8:
                            mensaje = $"{valor} en números romanos es VIII";
                            break;
                        case 9:
                            mensaje = $"{valor} en números romanos es IX";
                            break;
                        case 10:
                            mensaje = $"{valor} en números romanos es X";
                            break;                        
                        default:
                            Console.WriteLine("No ingresó un número válido.");
                            break;
                    }
                    Console.WriteLine($"\n{mensaje}. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\nNo ingresó un número válido. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear(); // Limpiar la consola para comenzar de nuevo
                    continue;
                }
            }
            break;

        //SALIR
        case 5:
            Console.WriteLine("\nGracias por usar la aplicación.");
            break;
        default:
            Console.WriteLine("\nNo ingresó una opción válida. Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear(); // Limpiar la consola para comenzar de nuevo 
            break;
    }

} while (opcion!=5);
