using System;
using System.Numerics;

int opcion;
int valor;
int resultado;
string mensaje = "";
// Crear una instancia de Random para generar números aleatorios
Random random = new Random();
string password, passwordConfirmed;
bool endAskPassword = false;

do
{
    Console.WriteLine("1. Dado un valor, devolver un mensaje que diga “El valor es mayor que 100” sólo cuando se cumpla dicha condición.");
    Console.WriteLine("2. Pedir un número entero por teclado y calcular si es par o impar.");
    Console.WriteLine("3. Teniendo un valor entero, verificar si se cumple o no que ese valor es el doble de un impar. Por ejemplo, 14 cumple con esta condición.");
    Console.WriteLine("4. Dada un número del 1 al 10, devolver su “versión” en números romanos.");
    Console.WriteLine("5. Leer el nombre y las edades de dos personas y devolver el nombre del menor.\n" +
        "En caso de que tengan la misma edad también debe indicarse. Devolver también la diferencia de edad en caso de corresponder.");
    Console.WriteLine("6. Escribir un programa que calcule el tipo de un triángulo conociendo la longitud de sus 3 lados.\n" +
        "También que calcule su perímetro y su área.");
    Console.WriteLine("7. Desarrolle un programa que calcule el desglose de una cantidad dada, en billetes y monedas tal que se minimice la cantidad de monedas y billetes." +
        "\nConsidere las denominaciones $1000, $500, $100, $50, $20, $10, $5, $2, $1, donde los últimos tres son monedas. " +
        "\n(Por ejemplo, para $1,723 se debe imprimir: “1 billete de $1000, 1 billete de $500, 1 billete de $200, 1 billete de $20, 1 moneda de $2, 1 moneda de $1). " +
        "\nObviar los signos de billete ($) y tratar todos los valores como números, para los cálculos.");
    Console.WriteLine("8. Pide un número N, y muestra todos los números del 1 al N.");
    Console.WriteLine("9. Pedir 15 números y escribir la suma total");
    Console.WriteLine("10. Pide 5 números e indica si alguno es múltiplo de 3.");
    Console.WriteLine("11. Escriba un programa que solicite una contraseña (el texto de la contraseña no es importante) y la vuelva a solicitar hasta que las dos contraseñas coincidan.");
    Console.WriteLine("12. Mismo que el anterior pero con un límite de tres peticiones. Luego de las tres peticiones no debe solicitar más la contraseña y terminar el programa.");
    Console.WriteLine("13. Proponer al usuario que adivine un número a base de intentarlo.");
    Console.WriteLine("14. Modificar el programa anterior para que vaya dando pistas del tipo «mayor» o «menor».");
    Console.WriteLine("15. Crea un programa que permita sumar N números. El usuario decide cuándo termina de introducir números al indicar la palabra ‘fin’.");
    Console.WriteLine("16. Crea un programa que solicite al usuario una cadena de texto y que verifique si es o no un palíndromo.");
    Console.WriteLine("17. Pide al usuario un número x y calcula su factorial.");
    Console.WriteLine("18. Crea un programa que convierta una temperatura en grados Celsius a Fahrenheit o viceversa según la elección del usuario.");
    Console.WriteLine("19. Solicita al usuario un número entero positivo y muestra los primeros 50 números de la secuencia de Fibonacci.");
    Console.WriteLine("20. Desarrolla un juego en el que el programa elija una palabra y el usuario tenga que adivinarla letra por letra, con un límite de intentos.");
    Console.WriteLine("21 (EXTRA). Adaptar el programa anterior para que a medida que el usuario falle, la aplicación autocomplete  la palabra letra a letra a modo de pistas para el usuario. El numero de intentos estará dado por la cantidad de letras restantes que el usuario tenga que adivinar. Ejemplo: La palabra ADIVINAR tendrá 8 intentos. Si la forma de la palabra es AD_V_NA_ son 3 intentos.");
    Console.WriteLine("22. Salir");


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
        case 5:
            int edadA = 30;
            string nombreA = "Matias";
            int edadB = 20;
            string nombreB = "Fernando";

            Console.WriteLine($"\n{nombreA} tiene {edadA} años.\n{nombreB} tiene {edadB} años.");

            if (edadA == edadB)
                Console.WriteLine($"\n{nombreA} y {nombreB} tienen {edadB} años");
            else
            {
                if (edadA < edadB)
                    Console.WriteLine($"\n{nombreA} es el menor.");
                else
                    Console.WriteLine($"\n{nombreB} es el menor.");

                Console.WriteLine("La diferencia de edad es: " + Math.Abs(edadB - edadA));
                Console.WriteLine("Presione enter para continuar.");
                Console.ReadLine();
                Console.Clear(); // Limpiar la consola para comenzar de nuevo
            }                            
            break;
        case 6:
            double ladoA = 3, ladoB = 4, ladoC = 5, area, perimetro;
            string tipoTriangulo;

            if (ladoA == ladoB && ladoB == ladoC)
            {
                tipoTriangulo = "Equilátero";
            }
            else
            {
                if (ladoA != ladoB && ladoB != ladoC)
                {
                    tipoTriangulo = "Escaleno";
                }
                else
                {
                    tipoTriangulo = "Isósceles";                    
                }
            }

            perimetro = ladoA + ladoB + ladoC;
            // Calcular el área usando la fórmula de Herón
            double semiperimetro = perimetro / 2;
            area = Math.Sqrt(semiperimetro * (semiperimetro - ladoA) * (semiperimetro - ladoB) * (semiperimetro - ladoC));

            Console.WriteLine($"Las medidas de los lados del triángulo son: {ladoA}, {ladoB} y {ladoC}");
            Console.WriteLine($"El triángulo es {tipoTriangulo}");
            Console.WriteLine($"Perímetro: {perimetro}");
            Console.WriteLine($"Área: {area}");

            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear(); // Limpiar la consola para comenzar de nuevo
            break;
        case 7:
            int monto = 1723, montoOriginal = 1723, billetesMil = 0, billetesQuinientos = 0, billetesDoscientos =0, billetesCien = 0, billetesCincuenta = 0;
            int billetesVeinte = 0, billetesDiez = 0, billetesCinco = 0, monedaDos = 0, monedaUno = 0;            

            if (monto >= 1000)
            {
                billetesMil = monto / 1000;
                monto = monto - billetesMil * 1000;
                mensaje += $"{billetesMil} billetes de $1000. ";
            }

            if (monto >= 500)
            {
                billetesQuinientos = monto / 500;
                monto = monto - billetesQuinientos * 500;
                mensaje += $"{billetesQuinientos} billetes de $500. ";
            }

            if (monto >= 200)
            {
                billetesDoscientos = monto / 200;
                monto = monto - billetesDoscientos * 200;
                mensaje += $"{billetesDoscientos} billetes de $200. ";
            }

            if (monto >= 100)
            {
                billetesCien = monto / 100;
                monto = monto - billetesCien * 100;
                mensaje += $"{billetesCien} billetes de $100. ";
            }

            if (monto >= 50)
            {
                billetesCincuenta = monto / 50;
                monto = monto - billetesCincuenta * 50;
                mensaje += $"{billetesCincuenta} billetes de $50. ";
            }
                
            if (monto >= 20)
            {
                billetesVeinte = monto / 20;
                monto = monto - billetesVeinte * 20;
                mensaje += $"{billetesVeinte} billetes de $20. ";
            }
                
            if (monto >= 10)
            {
                billetesDiez = monto / 10;
                monto = monto - billetesDiez * 10;
                mensaje += $"{billetesDiez} billetes de $10. ";
            }
                
            if (monto >= 5)
            {
                billetesCinco = monto / 5;
                monto = monto - billetesCinco * 5;
                mensaje += $"{billetesCinco} billetes de $5. ";
            }
                
            if (monto >= 2)
            {
                monedaDos = monto / 2;
                monto = monto - monedaDos * 2;
                mensaje += $"{monedaDos} monedas de $2. ";
            }

            if(monto == 1)
            {
                monedaUno = monto;
                mensaje += $"{monedaUno} monedas de $1. ";
            }
             
            Console.WriteLine($"Monto ingresado: {montoOriginal}");
            Console.WriteLine(mensaje);
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear(); // Limpiar la consola para comenzar de nuevo
            break;
        case 8:
            int n = 10;
            Console.WriteLine($"Números del 1 al {n}");
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear(); // Limpiar la consola para comenzar de nuevo
            break;
        case 9:            
            int total = 0;
            
            for (int i = 1; i <= 15; i++)
            {
                //Genero número random entre 1 y 10                
                valor = (int)(1 + (random.NextDouble() * (10 - 1)));
                Console.WriteLine($"{i}º Valor: {valor}");
                total += valor;
            }

            Console.WriteLine($"Total: {total}");
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear(); // Limpiar la consola para comenzar de nuevo
            break;
        case 10:
            mensaje = "";
            for (int i = 1; i <= 5; i++)
            {
                //Genero número random entre 1 y 10                
                valor = (int)(1 + (random.NextDouble() * (10 - 1)));
                Console.WriteLine($"{i}º Valor: {valor}");
                if (valor % 3 == 0)
                    mensaje += valor + " ";
            }

            if (mensaje != "")
                Console.WriteLine($"Los valores multiplos de 3 son: {mensaje}");
            else
                Console.WriteLine("No se ingresaron valores multiplos de 3.");
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear(); // Limpiar la consola para comenzar de nuevo
            break;
        case 11:            
            endAskPassword = false;
            do
            {
                Console.WriteLine("\nIngrese su password:");
                password = Console.ReadLine();
                if (password == null || password.Trim() == "")
                {
                    Console.WriteLine("Ingrese un password válido. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("\nVuelva a ingresar su password para confirmar:");
                passwordConfirmed = Console.ReadLine();
                if (passwordConfirmed == null || passwordConfirmed.Trim() == "")
                {
                    Console.WriteLine("Ingrese un password válido. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (password.Equals(passwordConfirmed))
                    endAskPassword = true;
                else
                    Console.WriteLine("Los passwords ingresados no coinciden. Vuelva a ingresarlos.");
                    
            } while (endAskPassword != true);

            Console.WriteLine("Gracias por confirmar su password.");
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 12:
            endAskPassword = false;
            int askLimit = 0;
            do
            {
                Console.WriteLine("\nIngrese su password:");
                password = Console.ReadLine();
                if (password == null || password.Trim() == "")
                {                    
                    Console.WriteLine("\nIngrese un password válido. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("\nVuelva a ingresar su password para confirmar:");
                passwordConfirmed = Console.ReadLine();
                if (passwordConfirmed == null || passwordConfirmed.Trim() == "")
                {                    
                    Console.WriteLine("\nIngrese un password válido. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (password.Equals(passwordConfirmed))
                    endAskPassword = true;
                else
                {
                    askLimit++;
                    Console.WriteLine("\nLos passwords ingresados no coinciden.");
                    Console.WriteLine("Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (endAskPassword != true && askLimit!=3);

            if(askLimit != 3)
                Console.WriteLine("\nGracias por confirmar su password.");
            else
                Console.WriteLine("\nSe excedió el limite de ingresos permitidos.");

            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 13:
            //numero a adivinar random entre 1 y 10
            int numeroAdivinar = (int)(1 + (random.NextDouble() * (10 - 1))); ;
            bool finalizarJuego = false;
            
            do
            {
                Console.WriteLine("Adivina el número entre 1 y 10. Ingresa un número: ");
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine("\nNo ingresó un número válido. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (valor == numeroAdivinar)
                    finalizarJuego = true;
            } while (!finalizarJuego);

            Console.WriteLine("Felicidades! Adivinaste el número.");
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 14:
            //numero a adivinar random entre 1 y 10
            numeroAdivinar = (int)(1 + (random.NextDouble() * (10 - 1))); ;
            finalizarJuego = false;

            do
            {
                Console.WriteLine("Adivina el número entre 1 y 10. Ingresa un número: ");
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine("\nNo ingresó un número válido. Presione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (valor == numeroAdivinar)
                    finalizarJuego = true;
                else
                    if (valor < numeroAdivinar)
                        Console.WriteLine("El número a adivinar es mas grande :)");
                    else
                        Console.WriteLine("El número a adivinar es mas chico :)");
            } while (!finalizarJuego);

            Console.WriteLine("Felicidades! Adivinaste el número.");
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 15:
            total = 0;
            string respuesta = "";
            bool finalizar = false;
            do
            {
                Console.WriteLine("Ingrese numero entero a sumar. Ingrese FIN para terminar la carga de valores:");
                respuesta = Console.ReadLine();

                if (respuesta !=null)
                {
                    if (!respuesta.ToUpper().Trim().Equals("FIN"))
                    {
                        if (!int.TryParse(respuesta, out valor))
                        {
                            Console.WriteLine("\nNo ingresó un número válido. Presione enter para continuar.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            total += valor;
                        }
                    }
                    else
                    {
                        finalizar = true;
                    }
                }
                else
                {
                    Console.WriteLine("\nIngrese una respuesta válida.");
                }
                
            } while (finalizar != true);

            Console.WriteLine($"\nLa suma total de los elementos ingresados es: {total}");
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 16:
            string palabraOriginal = "Anita lava la tina";
            //elimino espacios y convierto a mayusculas
            string palabraMayusculaSinEspacios = palabraOriginal.Replace(" ","").ToUpper();
            //genero array a partir del string
            char[] arregloPalabraInvertida = palabraMayusculaSinEspacios.ToCharArray();
            //invierto el array
            Array.Reverse(arregloPalabraInvertida);
            //genero string con el array invertido
            string palabraInvertida = new string(arregloPalabraInvertida);

            Console.WriteLine($"Analizar si la siguiente frase \"{palabraOriginal}\" es palíndromo.");
            Console.WriteLine($"\nPalabra sin espacios: {palabraMayusculaSinEspacios} .Palabra invertida: {palabraInvertida}");
            if (palabraMayusculaSinEspacios.Equals(palabraInvertida))
                Console.WriteLine($"\n{palabraOriginal} es palíndromo.");
            else
                Console.WriteLine($"\n{palabraOriginal} no es palíndromo.");

            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 17:
            valor = 5;
            mensaje = "";
            int factorial = 1;

            if(valor <0)
                mensaje = "Ingrese un valor positivo.";
            else 
            {
                if (valor == 0)
                    mensaje = "El factorial de 0 es 1.";
                else
                {
                    for (int i = 1; i <= valor; i++)
                    {
                        factorial *= i;
                    }
                    mensaje = $"El factorial de {valor} es {factorial}";
                }
            }
                
            Console.WriteLine($"\n{mensaje}");
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 18:
            double temperatura;
            Console.WriteLine("Seleccione una opción para conversión de temperatura:");
            Console.WriteLine("1. De Celsius a Fahrenheit");
            Console.WriteLine("2. De Fahrenheit a Celsius");
            Console.Write("Ingrese el número de la opción deseada: ");
            int tipoConversion = Convert.ToInt32(Console.ReadLine());
                                    
            switch (tipoConversion)
            {
                case 1:
                    // Convertir de Celsius a Fahrenheit
                    Console.Write("Ingrese la temperatura en grados Celsius: ");
                    temperatura = Convert.ToDouble(Console.ReadLine());
                    double fahrenheit = (temperatura * 9 / 5) + 32;
                    Console.WriteLine($"\n{temperatura}°C es igual a {fahrenheit}°F");
                    break;
                case 2:
                    // Convertir de Fahrenheit a Celsius
                    Console.Write("Ingrese la temperatura en grados Fahrenheit: ");
                    temperatura = Convert.ToDouble(Console.ReadLine());
                    double celsius = (temperatura - 32) * 5 / 9;
                    Console.WriteLine($"\n{temperatura}°F es igual a {celsius}°C");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor seleccione 1 o 2.");
                    break;
            }
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 19:
            valor = 20;
            if (valor <= 0)
            {
                Console.WriteLine("El número debe ser positivo.");                
            }
            else
            {
                long a = 0;
                long b = 1;

                Console.WriteLine($"Los primeros {valor} números de la secuencia de Fibonacci son:");
                Console.Write(a + " ");

                for (int i = 1; i < valor; i++)
                {
                    Console.Write(b + " ");
                    long temp = a + b;
                    a = b;
                    b = temp;
                }
            }
            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 20:
            Console.Clear();
            string linea;
            string palabraAdivinar = "programacion";
            //genero un string de _ con la longitud de la palabra a adivinar
            string palabraOculta = new string('_', palabraAdivinar.Length);
            int intentosRestantes = 3;
            //como hashset solo admite elementos diferentes, no agregara repetidos
            HashSet<char> letrasIngresadas = new HashSet<char>();

            Console.WriteLine($"Intentos restantes para adivinar la palabra: {intentosRestantes}");
            while (intentosRestantes > 0)
            {
                // para mostrar el estado actual de la palabra oculta
                Console.WriteLine($"Palabra a adivinar: {palabraOculta}");
                //para mostrar letras ingresadas hasta el momento
                if(letrasIngresadas.Count>0)
                    Console.WriteLine($"Letras ingresadas: {string.Join(", ", letrasIngresadas)}");

                Console.Write("\nIngresa una letra(sin acento): ");
                linea = Console.ReadLine();

                if (linea.Length < 0 || linea.Replace(" ", "") == "")
                {
                    Console.WriteLine("\nIngrese una letra válida.");
                    Console.WriteLine("\nPresione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                linea = linea.Replace(" ", "");
                Console.WriteLine(linea);
                char letra = linea[0];

                // Validar que la entrada es una sola letra
                if (!char.IsLetter(letra))
                {
                    Console.WriteLine("\nIngresa una letra válida.");
                    Console.WriteLine("\nPresione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                letra = char.ToLower(letra);

                //contains, verifica si la coleccion contiene el elemento indicado
                if (letrasIngresadas.Contains(letra))
                {
                    Console.WriteLine("\nYa has adivinado esta letra. Intenta con otra.");
                    Console.WriteLine("\nPresione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                letrasIngresadas.Add(letra);

                // Verificar si la letra está en la palabra a advinar
                if (palabraAdivinar.Contains(letra))
                {
                    // Actualizar la palabra oculta
                    char[] palabraAdivinarArray = palabraOculta.ToCharArray();
                    //recorro palabra y si esta la letra, reemplaza el _ por la letra
                    for (int i = 0; i < palabraAdivinar.Length; i++)
                    {
                        if (palabraAdivinar[i] == letra)
                        {
                            palabraAdivinarArray[i] = letra;
                        }
                    }
                    //genera el string a partir del array modificado
                    palabraOculta = new string(palabraAdivinarArray);

                    // Verificar si el usuario ha adivinado la palabra completa
                    if (!palabraOculta.Contains('_'))
                    {
                        Console.WriteLine($"\n¡Felicidades! Has adivinado la palabra: {palabraAdivinar}");
                        break;
                    }
                }
                else
                {
                    intentosRestantes--;
                    Console.WriteLine($"\nLa letra no está en la palabra. Intentos restantes: {intentosRestantes}");
                }
            }

            if (intentosRestantes == 0)
            {
                Console.WriteLine($"\nSe acabaron los intentos. La palabra era: {palabraAdivinar}");
            }

            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 21:            
            //Console.Clear();
            palabraAdivinar = "programacion";
            //genero un string de _ con la longitud de la palabra a adivinar
            palabraOculta = new string('_', palabraAdivinar.Length);
            intentosRestantes = palabraAdivinar.Length;
            //como hashset solo admite elementos diferentes, no agregara repetidos
            letrasIngresadas = new HashSet<char>();
            
            while (intentosRestantes > 0)
            {
                Console.Clear();
                Console.WriteLine($"Intentos restantes para adivinar la palabra: {intentosRestantes}");
                // para mostrar el estado actual de la palabra oculta
                Console.WriteLine($"Palabra a adivinar: {palabraOculta}");
                //para mostrar letras ingresadas hasta el momento
                if (letrasIngresadas.Count > 0)
                    Console.WriteLine($"Letras ingresadas: {string.Join(", ", letrasIngresadas)}");

                Console.Write("\nIngresa una letra(sin acento): ");
                linea = Console.ReadLine();

                if (linea.Length < 0 || linea.Replace(" ", "") == "")
                {
                    Console.WriteLine("\nIngrese una letra válida.");
                    Console.WriteLine("\nPresione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                linea = linea.Replace(" ", "");
                Console.WriteLine(linea);
                char letra = linea[0];

                // Validar que la entrada es una sola letra
                if (!char.IsLetter(letra))
                {
                    Console.WriteLine("\nIngresa una letra válida.");
                    Console.WriteLine("\nPresione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                letra = char.ToLower(letra);

                //contains, verifica si la coleccion contiene el elemento indicado
                if (letrasIngresadas.Contains(letra))
                {
                    Console.WriteLine("\nYa has adivinado esta letra. Intenta con otra.");
                    Console.WriteLine("\nPresione enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                letrasIngresadas.Add(letra);

                // Verificar si la letra está en la palabra a advinar
                if (palabraAdivinar.Contains(letra))
                {
                    // Actualizar la palabra oculta
                    char[] palabraAdivinarArray = palabraOculta.ToCharArray();
                    //recorro palabra y si esta la letra, reemplaza el _ por la letra
                    for (int i = 0; i < palabraAdivinar.Length; i++)
                    {
                        if (palabraAdivinar[i] == letra)
                        {
                            palabraAdivinarArray[i] = letra;
                            intentosRestantes--;
                        }
                    }
                    //genera el string a partir del array modificado
                    palabraOculta = new string(palabraAdivinarArray);

                    // Verificar si el usuario ha adivinado la palabra completa
                    if (!palabraOculta.Contains('_'))
                    {
                        Console.WriteLine($"\n¡Felicidades! Has adivinado la palabra: {palabraAdivinar}");
                        break;
                    }
                }
                else
                {
                    intentosRestantes--;
                    Console.WriteLine($"\nLa letra no está en la palabra. Intentos restantes: {intentosRestantes}");
                    // Mostrar más pistas: Autocompletar la palabra letra a letra
                    for (int i = 0; i < palabraAdivinar.Length; i++)
                    {
                        if (palabraOculta[i] == '_')
                        {
                            palabraOculta = palabraOculta.Substring(0, i) + palabraAdivinar[i] + palabraOculta.Substring(i + 1);
                            break; // para solo revelar una letra en cada intento fallido
                        }
                    }
                }
            }

            if (intentosRestantes == 0)
            {
                Console.WriteLine($"\nSe acabaron los intentos. La palabra era: {palabraAdivinar}");
            }

            Console.WriteLine("\nPresione enter para continuar.");
            Console.ReadLine();
            Console.Clear();            
            break;
        //SALIR
        case 22:            
            Console.WriteLine("\nGracias por usar la aplicación.");
            break;
        default:
            Console.WriteLine("\nNo ingresó una opción válida. Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear(); // Limpiar la consola para comenzar de nuevo 
            break;
    }

} while (opcion!=22);
