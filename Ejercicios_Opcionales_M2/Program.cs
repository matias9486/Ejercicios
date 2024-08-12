/*Arreglos y Listas



 */
using System.Text;
using System.Xml.Linq;
using System;
using Microsoft.Win32;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace Ejercicios_Opcionales_M2
{
    internal class Program
    {
        #region funciones
        static void LimpiarPantalla()
        {
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        static void MostrarLista(List<string> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay elementos.");
            }
            else
            {
                foreach (var item in lista)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }
        static void CrearMatrixIP(string[,] matrizIP)
        {
            for (int i = 0; i < matrizIP.GetLength(0); i++)
            {
                for (int j = 0; j < matrizIP.GetLength(1); j++)
                {
                    matrizIP[i, j] = (j % 2 == 0) ? "P" : "I";
                    Console.Write($"{matrizIP[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void GenerarTablasMultiplicar(int[,] tablas)
        {
            for (int i = 0; i < tablas.GetLength(0); i++)
            {
                for (int j = 0; j < tablas.GetLength(1); j++)
                {
                    if (i == 0)
                        tablas[i, j] = j;
                    else
                        if (j == 0)
                        tablas[i, j] = i;
                    else
                        tablas[i, j] = (i * j);
                    Console.Write($"{tablas[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        static void MostrarMatriz(char[,] matriz)
        {
            int size = matriz.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void EsconderXEnMatriz(int dimension, Random random, char[,] matriz, int cantidadMaximaX)
        {
            // Esconder las X en posiciones aleatorias
            for (int i = 0; i < cantidadMaximaX; i++)
            {
                int fila, columna;
                do
                {
                    fila = random.Next(dimension);
                    columna = random.Next(dimension);
                } while (matriz[fila, columna] == 'X');                

                matriz[fila, columna] = 'X';
            }
        }

        static void InicializarMatrixAsteriscos(int dimension, char[,] matriz)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    matriz[i, j] = '*';
                }
            }
        }

        static void AdivinarX(int dimension,int intentoMaximos, char[,] matrizJuego, char[,] matrizJugador, int cantidadX, ref int intentosFallidos, ref int aciertos)
        {
            do
            {
                MostrarMatriz(matrizJugador);
                Console.WriteLine($"\nIntento {intentosFallidos + 1} de {intentoMaximos}");
                Console.Write($"Ingrese la fila (0-{dimension - 1}):");
                int filaSugerida = int.Parse(Console.ReadLine());
                Console.Write($"Ingrese la columna (0-{dimension - 1}):");
                int columnaSugerida = int.Parse(Console.ReadLine());

                if (filaSugerida < 0 || filaSugerida >= dimension || columnaSugerida < 0 || columnaSugerida >= dimension)
                {
                    Console.WriteLine("\nEntrada no válida. Intente de nuevo.");
                    continue;
                }

                if (matrizJuego[filaSugerida, columnaSugerida] == 'X')
                {
                    Console.WriteLine("Adivinaste una X!\n");
                    aciertos++;
                    matrizJugador[filaSugerida, columnaSugerida] = 'X';
                }
                else
                {
                    Console.WriteLine("No encontraste una X! :(\n");
                    intentosFallidos++;
                }
            } while (intentosFallidos < intentoMaximos && aciertos < cantidadX);
        }
        #endregion

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("1 - Dado que se tiene almacenado en una lista, los resultados de los últimos 10 exámenes de un alumno." +
                    "\nCalcular su promedio y mostrar por pantalla las 10 notas de los exámenes y el promedio resultante.");
                Console.WriteLine("\n2 - Dada las edades de 20 personas guardadas en una lista, imprimir por pantalla cuántos son mayores de edad y cuántos no.");
                Console.WriteLine("\n3 - Dado una lista de nombres de estudiantes, imprimir el que tenga más letras, y el que tenga menos letras de todos.");
                Console.WriteLine("\n4 - Crear una variable para guardar los nombres de elementos para una “lista de supermercado”." +
                    "\nSolicitar al usuario que ingrese el nombre de un elemento que va a comprar en el super y verificar que el elemento esté en la lista." +
                    "\nSi no está, agregarlo e indicar que no estaba. Si está, quitarlo de la lista, y avisar que sí estaba." +
                    "\nAl finalizar mostrar por pantalla los elementos que no compró y los que compró, pero no estaban en la lista." +
                    "\nSi se quiere, mostrar también todos los elementos que el usuario compró." +
                    "\nPara salir el usuario debe ingresar “fin”.");

                Console.WriteLine("\n5 - Crear una matriz de 5 x 5.Almacenar una ‘I’ en lugares impares y una ‘P’ en lugares pares.Imprimir la matriz por pantalla");
                Console.WriteLine("\n6- Se tiene una matriz de 5x7, donde 5 representa la semana de un mes y 7 los días de la semana." +
                    "\nLa estructura es para registrar la temperatura diaria de una cabina de pago, estos oscilan entre los 7 y 38 grados." +                    
                    "\nDeberá llenar la matriz de forma aleatoria para el mes de mayo donde el primer día inicia en lunes y el último(31)" +
                    "\nse ubica en el miércoles(la matriz puede ser inicializada con valores aleatorios desde el principio del programa" +
                    "\nno es necesario pedir los valores al usuario para cada posición)." +
                    "\nSe nos pide hacer lo siguiente:" +
                    "\nObtener la temperatura más alta y baja de la semana y que día se produjo(lunes, martes, etc.)" +
                    "\nPromedio de temperatura de la semana." +
                    "\nTemperatura más alta del mes y su día.");
                Console.WriteLine("\n7 - Almacenar en una matriz las tablas del 1 al 9." +
                    "\nTeniendo en cuenta que en la primera fila y la primera columna se debe guardar los números(de 0 a 9), estando el cero en la primera posición(fila 0, columna 0)." +
                    "\nEl resto de los lugares debe ser calculado usando los números que se dispone usando las posiciones del array o arreglo." +
                    "\nAl finalizar el cálculo, mostrar la matriz por pantalla");

                Console.WriteLine("\n8 - Crear una matriz de 10 x 10, y “esconder” varias ‘X’ en lugares aleatorios(no más de la mitad de los lugares disponibles en la matriz)." +
                    "\nEl usuario deberá ingresar el lugar donde cree que hay una X, ingresando la fila y la columna por separado." +
                    "\nInformar si acertó o no por cada ingreso. Se debe pedir al usuario ingresar valores por tantas X que se haya guardado." +
                    "\nEl usuario tiene 3 intentos para fallar.Al finalizar(Ya sea porque se terminaron los 3 intentos, o el jugador acertó todas las X)" +
                    "\nImprimir por pantalla la matriz con sus correspondientes X, mostrando un *donde no haya nada.");
                Console.WriteLine("\n9 - Salir");

                Console.WriteLine("\nIngrese la opción a realizar.");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese una opción válida.");
                    LimpiarPantalla();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        #region ejercicio1
                        //1 - Dado que se tiene almacenado en una lista, los resultados de los últimos 10 exámenes de un alumno, calcular su promedio y mostrar por pantalla las 10 notas de los exámenes y el promedio resultante.
                        List<double> notasExamenes = new List<double>() { 10, 8, 4, 5, 10, 6, 7.50, 8, 9, 2 };
                        Console.WriteLine("\nNotas:");
                        notasExamenes.ForEach(examen => Console.Write(examen + " "));
                        Console.WriteLine($"\nPromedio de notas: {notasExamenes.Average()}"); //6.95
                        Console.WriteLine($"Nota más alta: {notasExamenes.Max()}"); //10
                        Console.WriteLine($"Nota más baja: {notasExamenes.Min()}"); //2
                        #endregion
                        LimpiarPantalla();
                        break;
                    case 2:
                        #region ejercicio2
                        //2 - Dada las edades de 20 personas guardadas en una lista, imprimir por pantalla cuántos son mayores de edad y cuántos no.
                        List<int> edades = new List<int>() { 10, 15, 20, 21, 22, 23, 24, 25, 26, 27, 14, 40, 11, 13, 13, 7, 8, 9, 10, 11 };
                        int mayoresEdad = edades.Where(edad => edad > 18).Count(); //9
                        int menoresEdad = edades.Count - mayoresEdad;

                        Console.WriteLine("\nEdades:");
                        edades.ForEach(edad => Console.Write(edad + " "));
                        Console.WriteLine($"\nMayores de edad: {mayoresEdad}. Menores de edad: {menoresEdad}");
                        #endregion
                        LimpiarPantalla();
                        break;
                    case 3:
                        #region ejercicio3
                        //3 - Dado una lista de nombres de estudiantes, imprimir el que tenga más letras, y el que tenga menos letras de todos.
                        List<string> nombresEstudiantes = new List<string>() { "Matías", "Fernando", "Laura", "Roberto", "Luján" };
                        Console.WriteLine("\nNombres:");
                        nombresEstudiantes.ForEach(e => Console.Write(e + " "));
                        //OrderBy, los ordena de forma ascendente
                        string nombreLargo = nombresEstudiantes.OrderBy(elem => elem.Length).Last();    //Fernando
                        string nombreCorto = nombresEstudiantes.OrderBy(elem => elem.Length).First();     //Laura
                        Console.WriteLine($"\nNombre más largo: {nombreLargo}. Nombre más corto: {nombreCorto}");
                        #endregion
                        LimpiarPantalla();
                        break;
                    case 4:
                        #region ejercicio4
                        /*4 - Crear una variable para guardar los nombres de elementos para una “lista de supermercado”. 
                        Solicitar al usuario que ingrese el nombre de un elemento que va a comprar en el super y verificar que el elemento esté en la lista. 
                        Si no está, agregarlo e indicar que no estaba. Si está, quitarlo de la lista, y avisar que sí estaba.
                        Al finalizar mostrar por pantalla los elementos que no compró y los que compró, pero no estaban en la lista.
                        Si se quiere, mostrar también todos los elementos que el usuario compró.Para salir el usuario debe ingresar “fin”.*/
                        
                        // Supongo Lista inicial de elementos en la lista de supermercado
                        List<string> listaSupermercado = new List<string> { "leche", "pan", "huevos", "queso", "manzanas" };                        

                        // Listas para almacenar los elementos que el usuario compró y los nuevos elementos añadidos
                        HashSet<string> elementosComprados = new HashSet<string>();
                        HashSet<string> elementosNoEnLista = new HashSet<string>();

                        Console.WriteLine("Lista inicial de supermercado:");
                        MostrarLista(listaSupermercado);

                        while (true)
                        {
                            Console.Write("\nIngrese el nombre del elemento que va a comprar (o 'fin' para salir): ");
                            string elemento = Console.ReadLine().Trim().ToLower();

                            if (elemento == "fin")
                            {
                                break;
                            }

                            if (listaSupermercado.Contains(elemento))
                            {
                                //Quito elemento que está en la lista y lo agrego a elementos comprados
                                listaSupermercado.Remove(elemento);
                                elementosComprados.Add(elemento);
                                Console.WriteLine($"El elemento '{elemento}' estaba en la lista y ha sido quitado.");
                            }
                            else
                            {
                                //Agrego elementos que no estaban en la lista                                
                                elementosNoEnLista.Add(elemento);
                                elementosComprados.Add(elemento);
                                Console.WriteLine($"El elemento '{elemento}' no estaba en la lista y ha sido añadido.");
                            }
                        }

                        // Mostrar resultados
                        Console.WriteLine("\nEstado de compras:");
                        Console.WriteLine("Elementos pendientes de compra:");
                        MostrarLista(listaSupermercado);

                        Console.WriteLine("\nTodos los elementos que el usuario compró:");
                        MostrarLista(new List<string>(elementosComprados));

                        Console.WriteLine("\nElementos que compró pero no estaban en la lista:");
                        MostrarLista(new List<string>(elementosNoEnLista));                        
                #endregion
                        LimpiarPantalla();
                        break;
                    case 5:
                        #region ejercicio5
                        //5 - Crear una matriz de 5 x 5.Almacenar una ‘I’ en lugares impares y una ‘P’ en lugares pares.Imprimir la matriz por pantalla
                        string[,] matrizIP = new string[5, 5];
                        Console.WriteLine("Matriz I P");
                        //Iteración de un arreglo multidimensional usando for
                        CrearMatrixIP(matrizIP);
                        #endregion
                        LimpiarPantalla();
                        break;
                    case 6:
                        #region ejercicio6
                        /*6- Se tiene una matriz de 5x7, donde 5 representa la semana de un mes y 7 los días de la semana.
                            La estructura es para registrar la temperatura diaria de una cabina de pago, estos oscilan entre los 7 y 38 grados.
                            Deberá llenar la matriz de forma aleatoria para el mes de mayo donde el primer día inicia en lunes y el último(31)
                            se ubica en el miércoles(la matriz puede ser inicializada con valores aleatorios desde el principio del programa,
                            no es necesario pedir los valores al usuario para cada posición). 
                            Se nos pide hacer lo siguiente:
                            Obtener la temperatura más alta y baja de la semana y que día se produjo(lunes, martes, etc.)
                            Promedio de temperatura de la semana.
                            Temperatura más alta del mes y su día.*/
                        Console.WriteLine("Ejercicio resuelto como obligatorio con los adicionales pedidos.");
                        #endregion
                        LimpiarPantalla();
                        break;
                    case 7:
                        #region Ejercicio7
                        // 7 - Almacenar en una matriz las tablas del 1 al 9, teniendo en cuenta que en la primera fila y la primera columna se debe guardar los números(de 0 a 9), estando el cero en la primera posición(fila 0, columna 0).El resto de los lugares debe ser calculado usando los números que se dispone, por ejemplo, en la fila 1, calcular 1 * 1, 1 * 2, 1 * 3, etc.usando las posiciones del array o arreglo.Al finalizar el cálculo, mostrar la matriz por pantalla
                        int[,] tablas = new int[10, 10];
                        Console.WriteLine("Tablas de multiplicar:");
                        GenerarTablasMultiplicar(tablas);
                        #endregion
                        LimpiarPantalla();
                        break;
                    case 8:
                        #region ejercicio8
                        /*8 - Crear una matriz de 10 x 10, y “esconder” varias ‘X’ en lugares aleatorios(la cantidad que el programador decida,
                        pero no más de la mitad de los lugares disponibles en la matriz).
                        El usuario deberá ingresar el lugar donde cree que hay una X, ingresando la fila y la columna por separado.
                        Informar si acertó o no por cada ingreso. Se debe pedir al usuario ingresar valores por tantas X que se haya guardado. 
                        El usuario tiene 3 intentos para fallar.Al finalizar(Ya sea porque se terminaron los 3 intentos, o el jugador acertó todas las X) 
                        imprimir por pantalla la matriz con sus correspondientes X, mostrando un *donde no haya nada.*/

                        const int intentoMaximos = 3;
                        const int dimension = 3;
                        Random random = new Random();

                        //Inicializar matriz de 10x10 con '*'
                        char[,] matrizJuego = new char[dimension, dimension];
                        char[,] matrizJugador = new char[dimension, dimension];
                        InicializarMatrixAsteriscos(dimension, matrizJuego);
                        InicializarMatrixAsteriscos(dimension, matrizJugador);
                        
                        // Determinar el número máximo de X a esconder
                        int cantidadMaximaX = (dimension * dimension) / 2;
                        int cantidadX = random.Next(1, cantidadMaximaX + 1);
                        EsconderXEnMatriz(dimension, random, matrizJuego, cantidadMaximaX);                        
                        
                        int intentosFallidos = 0;
                        int aciertos = 0;
                        Console.WriteLine($"Encuentra las {cantidadMaximaX} X en la matriz:\n");
                        AdivinarX(dimension,intentoMaximos, matrizJuego, matrizJugador ,cantidadX, ref intentosFallidos, ref aciertos);

                        // Mostrar la matriz final con las X reveladas
                        Console.WriteLine("\nJuego terminado. Las X estaban ubicadas en las siguientes posiciones:");
                        MostrarMatriz(matrizJuego);

                        Console.WriteLine($"Número total de X escondidas: {cantidadX}");
                        Console.WriteLine($"Número de aciertos: {aciertos}");                        

                        #endregion
                        LimpiarPantalla();
                        break;
                    case 9:
                        Console.WriteLine("\nGracias por probar los ejercicios!");                        
                        break;                    
                    default:
                        Console.WriteLine("\nIngrese una opción válida.");
                        LimpiarPantalla();
                        break;
                }
            } while (opcion != 9);                                                                                            
        }                        
    }
}
