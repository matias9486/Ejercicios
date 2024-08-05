using System;

namespace Ejercicio_Obligatorio_M2
/*  Weather Forecast Mejorado (para una Estación Meteorológica)

Una estación meteorológica necesita gestionar y procesar datos de temperatura del interior de la cabina para un mes completo (31 días). Los datos deben registrarse en una colección tipo matriz, donde las filas representan las semanas, y las columnas los días. Se requiere implementar varias funcionalidades para gestionar y procesar estos datos.

Para este ejercicio, se deben utilizar:
    -Una  5 x 7 para almacenar las temperaturas diarias del mes.
    -Una  para almacenar las temperaturas promedio de cada semana.
    -Una  para almacenar las temperaturas por encima de un cierto umbral.
Requerimientos:
    -Implementar un algoritmo principal que permita la carga inicial de todas las temperaturas del mes, 31 días (Puedes pedirle al usuario que cargue día por día, o bien simular la carga total de temperaturas). No importa si sobran lugares en la matriz al final, sólo deberemos usar 31 lugares.
    Luego mostrar al usuario un menú con las opciones (Ver siguiente). El usuario elije una opción y luego se le da la opción de elegir si quiere otra opción o salir, y así sucesivamente hasta que elija salir.
    -Opción para ver temperatura de un día específico: Aquí vamos a usar lo del escenario anterior pero cambiándole el mensaje. Basándose en la temperatura del día elegido, la aplicación debería mostrar la temperatura y un mensaje:
        Si la temperatura es inferior a 0, mostrar "Hizo mucho frío."
        Si la temperatura está entre 0 y 20, mostrar "El clima estaba fresco."
        Si la temperatura es superior a 20, mostrar "Hizo calor afuera."
    -Opción para calcular y ver temperaturas promedios de cada semana. Aquí debes usar otra colección para el almacenamiento.
    -Opción para encontrar y ver temperaturas por encima de 20° (Umbral). Aquí también debes usar otra colección para el almacenamiento.
    -Opción para ver la temperatura promedio del mes. Aquí puedes usar la matriz principal o la colección de promedios de cada semana.
    -Opción para ver la temperatura más alta. Aquí debes usar la matriz principal.
    -Opción para ver la temperatura más baja. Aquí debes usar la matriz principal.
    -Opción para ver el pronóstico de 5 días posteriores al mes. Aquí también debes implementar lo del ejercicio anterior, sólo que puedes mejorar el código colocando la funcionalidad en una opción aparte.
    -Opción para Salir.

    -Implementar una función para añadir las temperaturas diarias.
    -Implementar una función para calcular las temperaturas promedio de cada semana y almacenarlas en una colección.
    -Implementar una función para encontrar las temperaturas por encima de un umbral (20°) y almacenarlas en una colección.
    -Implementar una función para calcular la temperatura promedio del mes.
    -Implementar una función para encontrar la temperatura más alta y la más baja.
    -Utilizar una matriz 5x7 para almacenar las temperaturas diarias del mes.
    -Utilizar una colección adecuada para almacenar las temperaturas promedio de cada semana.
    -Utilizar una colección que creas más conveniente para almacenar las temperaturas por encima de un cierto umbral.
 */
{
    internal class Program
    {
        //Record para guardar el dia y la temperatura que superan el umbral indicado
        public record DiaUmbral(int dia, int temperatura);

        #region funciones
        static void LimpiarPantalla()
        {
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
                
        static void AgregarTemperaturaDiaria(int semana, int dia, int temperatura, ref int[,] temperaturasDiarias)
        {
            temperaturasDiarias[semana, dia] = temperatura;
        }

        static void SimularCargaTemperaturas(ref int[,] temperaturasDiarias)
        {            
            Random random = new Random();   //Para generar temperatura random
            int min = 0, max = 35, dia = 0; //temperaturas min y max para generar temperatura random. Y dias para interrumpir ciclo.
            int temperaturaRandom;

            for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
            {                
                for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    // Se genera un número entero aleatorio entre min (inclusive) y max (exclusive)
                    temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
                    AgregarTemperaturaDiaria(i, j, temperaturaRandom, ref temperaturasDiarias);                    
                }                
            }
        }

        static void MostrarTemperaturasDiarias(int[,] temperaturasDiarias)
        {
            int dia = 0;
            for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
            {
                Console.WriteLine($"Semana {i+1}:");
                for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;
                   
                    Console.WriteLine($"\tDía {dia}. Temperatura: {temperaturasDiarias[i, j]} ºC");
                }
                Console.WriteLine();
            }
        }      

        static List<DiaUmbral> ObtenerTemperaturasEncimaUmbral(double temperaturaUmbral, int[,] temperaturasDiarias)
        {
            List<DiaUmbral> temperaturaEncimaUmbral = new List<DiaUmbral>();
            int dia = 0, temperatura;
            for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
            {
                for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    temperatura = temperaturasDiarias[i, j];
                    if (temperatura > temperaturaUmbral)
                    {
                        DiaUmbral diaUmbral = new DiaUmbral(dia, temperatura);
                        temperaturaEncimaUmbral.Add(diaUmbral);
                    }                    
                }
            }
            return temperaturaEncimaUmbral;
        }

        static List<double> ObtenerTemperaturasPromedioSemanal(int[,] temperaturasDiarias)
        {
            double temperaturaTotalSemanal = 0, temperaturaPromedio = 0;            
            int dia = 0, temperatura;
            List<double> temperaturaPromedioSemanal = new List<double>();

            for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
            {
                temperaturaTotalSemanal = 0;
                for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    temperatura = temperaturasDiarias[i, j];
                    //acumulando temperatura total de la semana
                    temperaturaTotalSemanal += temperatura;
                }

                //si es la 4 semana, solo tiene 3 dias para calcula el promedio
                if (i == 4)
                    temperaturaPromedio = Math.Round(temperaturaTotalSemanal / 3, 2);
                else
                    temperaturaPromedio = Math.Round(temperaturaTotalSemanal / 7, 2);
                temperaturaPromedioSemanal.Add(temperaturaPromedio);
            }

            return temperaturaPromedioSemanal;
        }

        static double ObtenerTemperaturaPromedioMensual(int[,] temperaturasDiarias)
        {
            double temperaturaTotal = 0, temperaturaPromedioMensual = 0;
            int temperatura, dia = 0;            

            for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
            {                
                for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    temperatura = temperaturasDiarias[i, j];
                    //acumulando temperatura total de la semana
                    temperaturaTotal += temperatura;
                }                
            }
            temperaturaPromedioMensual = Math.Round(temperaturaTotal / 31, 2);

            return temperaturaPromedioMensual;
        }

        static string ObtenerTemperaturaMinimaMensual(int[,] temperaturasDiarias)
        {            
            int temperatura, dia = 0;
            int minima = 40;

            for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
            {
                for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    temperatura = temperaturasDiarias[i, j];                    
                    if (temperatura < minima)
                        minima = temperatura;
                }
            }            

            return $"La temperatura mínima del mes fue {minima} ºC.";
        }

        static string ObtenerTemperaturaMaximaMensual(int[,] temperaturasDiarias)
        {
            int temperatura, dia = 0;
            int maxima = -10;

            for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
            {
                for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    temperatura = temperaturasDiarias[i, j];
                    if (temperatura > maxima)
                        maxima = temperatura;                    
                }
            }

            return $"La temperatura máxima del mes fue {maxima} ºC.";
        }

        static string obtenerTemperaturaDiaEspecifico(int dia, int[,] temperaturasDiarias)
        {
            int diaActual = 0, temperatura = 0;
            string mensaje;
            for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
            {                
                for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
                {
                    diaActual++;

                    if (diaActual == dia)
                    {
                        temperatura = temperaturasDiarias[i, j];                        
                        break;
                    }

                    if (diaActual == 32)
                        break;                                            
                }                
            }

            mensaje = $"El día {dia} del mes, la temperatura fue {temperatura} ºC.";
            if (temperatura < 0)
                return $"{mensaje} Hizo mucho frío.";
            
            if(temperatura<20)
                return $"{mensaje} El clima estaba fresco.";
                
            return $"{mensaje} Hizo calor afuera.";            
        }

        static string obtenerPronosticoExtendido()
        {
            Random random = new Random();   //Para generar temperatura random
            int temperaturaRandom, min = 0, max = 35; //temperaturas min y max para generar temperatura random
            string mensaje="Pronóstico para los próximos cinco días:";

            // Se genera un número aleatorio entre min (inclusive) y max (exclusive)
            temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));            
            mensaje +=$"\n\tLunes: {temperaturaRandom} ºC";

            temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
            mensaje += $"\n\tMartes: {temperaturaRandom} ºC";

            temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
            mensaje += $"\n\tMiércoles: {temperaturaRandom} ºC";

            temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
            mensaje += $"\n\tJueves: {temperaturaRandom} ºC";

            temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
            mensaje += $"\n\tViernes: {temperaturaRandom} ºC";

            return mensaje;
        }

        #endregion
        
        static void Main(string[] args)
        {
            #region Variables
            int opcion;
            bool datosCargados = false;
            int[,] temperaturasDiarias = new int[5, 7]; //Arreglo de 5x7 para semanas y dias                        
            List<double> temperaturaPromedioSemanal = new List<double>();
            List<DiaUmbral> temperaturaEncimaUmbral = new List<DiaUmbral>();
            double temperaturaUmbral = 20;
            #endregion
                                                                        
            do
            {
                Console.WriteLine("1- Cargar temperaturas (Hardcodeadas).");
                Console.WriteLine("2- Mostrar temperaturas.");
                Console.WriteLine("3- Calcular y ver temperaturas promedios de cada semana.");
                Console.WriteLine("4- Encontrar y ver temperaturas por encima de 20° (Umbral hardcodeado)");
                Console.WriteLine("5- Ver temperatura promedio del mes.");
                Console.WriteLine("6- Ver temperatura más alta del mes.");
                Console.WriteLine("7- Ver temperatura más baja del mes.");
                Console.WriteLine("8- Ver pronóstico extendido (5 días).");
                Console.WriteLine("9- Ver temperatura de un día específico (Día random).");
                Console.WriteLine("10- Salir");

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
                        SimularCargaTemperaturas(ref temperaturasDiarias);
                        MostrarTemperaturasDiarias(temperaturasDiarias);
                        datosCargados = true;
                        LimpiarPantalla();
                        break;
                    case 2:
                        if (datosCargados == false)
                        {
                            Console.WriteLine("\nPrimero debe cargar las temperaturas diarias.");
                            LimpiarPantalla();
                            continue;
                        }
                        MostrarTemperaturasDiarias(temperaturasDiarias);
                        LimpiarPantalla();                        
                        break;
                    case 3:
                        if (datosCargados == false)
                        {
                            Console.WriteLine("\nPrimero debe cargar las temperaturas diarias.");
                            LimpiarPantalla();
                            continue;
                        }

                        temperaturaPromedioSemanal = ObtenerTemperaturasPromedioSemanal(temperaturasDiarias);
                        for (int i = 0; i < temperaturaPromedioSemanal.Count; i++)
                        {
                            Console.WriteLine($"La temperatura promedio de la semana {i + 1} es: {temperaturaPromedioSemanal[i]} ºC.");
                        }
                        LimpiarPantalla();
                        break;
                    case 4:
                        if (datosCargados == false)
                        {
                            Console.WriteLine("\nPrimero debe cargar las temperaturas diarias.");
                            LimpiarPantalla();
                            continue;
                        }

                        temperaturaEncimaUmbral = ObtenerTemperaturasEncimaUmbral(temperaturaUmbral, temperaturasDiarias);
                        Console.WriteLine($"\n\nTemperaturas por encima de {temperaturaUmbral} ºC:");
                        foreach (DiaUmbral diaU in temperaturaEncimaUmbral)
                        {
                            Console.WriteLine($"\tDía {diaU.dia}. Temperatura: {diaU.temperatura} ºC.");
                        }
                        LimpiarPantalla();
                        break;
                    case 5:
                        if (datosCargados == false)
                        {
                            Console.WriteLine("\nPrimero debe cargar las temperaturas diarias.");
                            LimpiarPantalla();
                            continue;
                        }

                        Console.WriteLine($"\nTemperatura Promedio Mensual: {ObtenerTemperaturaPromedioMensual(temperaturasDiarias)} ºC.");
                        LimpiarPantalla();
                        break;
                    case 6:
                        if (datosCargados == false)
                        {
                            Console.WriteLine("\nPrimero debe cargar las temperaturas diarias.");
                            LimpiarPantalla();
                            continue;
                        }

                        Console.WriteLine($"\n{ObtenerTemperaturaMaximaMensual(temperaturasDiarias)}");
                        LimpiarPantalla();
                        break;
                    case 7:
                        if (datosCargados == false)
                        {
                            Console.WriteLine("\nPrimero debe cargar las temperaturas diarias.");
                            LimpiarPantalla();
                            continue;
                        }

                        Console.WriteLine($"\n{ObtenerTemperaturaMinimaMensual(temperaturasDiarias)}");
                        LimpiarPantalla();
                        break;
                    case 8:
                        if (datosCargados == false)
                        {
                            Console.WriteLine("\nPrimero debe cargar las temperaturas diarias.");
                            LimpiarPantalla();
                            continue;
                        }

                        Console.WriteLine($"\n{obtenerPronosticoExtendido()}");
                        LimpiarPantalla();
                        break;
                    case 9:
                        if (datosCargados == false)
                        {
                            Console.WriteLine("\nPrimero debe cargar las temperaturas diarias.");
                            LimpiarPantalla();
                            continue;
                        }

                        Random random = new Random();   //Para generar temperatura random
                        int diaRandom = (int)(1 + (random.NextDouble() * (31 - 1)));
                        Console.WriteLine($"\n{obtenerTemperaturaDiaEspecifico(diaRandom, temperaturasDiarias)}");
                        LimpiarPantalla();
                        break;
                    case 10:
                        Console.WriteLine("\nGracias por usar Weather Forecast 2.0!");
                        break;
                    default:
                        Console.WriteLine("\nIngrese una opción válida.");
                        LimpiarPantalla();
                        break;
                }
            } while (opcion != 10);
        }
    }
}
