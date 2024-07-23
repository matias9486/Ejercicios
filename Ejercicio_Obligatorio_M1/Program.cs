/* Crear una aplicación simple de consola para el siguiente escenario:
Escenario: Weather Forecast

1. Solicitar al usuario que introduzca la temperatura actual (en grados Celsius).
2. Basándose en la temperatura introducida, la aplicación debería mostrar un mensaje:
   - Si la temperatura es inferior a 0, mostrar "Hace mucho frío afuera, asegúrate de abrigarte bien."
   - Si la temperatura está entre 0 y 20, mostrar "El clima está fresco, una chaqueta ligera sería perfecta."
   - Si la temperatura es superior a 20, mostrar "Hace calor afuera, no necesitas una chaqueta."
3. Luego, la aplicación debería preguntar al usuario si quiere conocer el pronóstico para los próximos cinco días (sí/no).
4. Si el usuario responde 'sí', la aplicación debería generar y mostrar un pronóstico simple. 
5. Finalmente, la aplicación debería preguntar al usuario si quiere consultar otro pronóstico. 
   - Si el usuario responde 'sí', la aplicación debería comenzar de nuevo. 
   - Si el usuario responde 'no', la aplicación debería mostrar un mensaje de despedida y terminar.
 */

bool pronostico = true;
bool pronosticoExtendido = true;
bool pronosticoOtro = true;

string mensaje;
double temperatura;
int opcionElegida;

int min = -5; //rango de temperatura mínimo
int max = 30;  //rango de temperatura máximo

// Crear una instancia de Random para generar números aleatorios
Random random = new Random();
int temperaturaRandom;

do
{
    Console.WriteLine("Ingrese la temperatura actual (En grados Celsius)");
    if (!double.TryParse(Console.ReadLine(), out temperatura))
    {
        Console.WriteLine("Ingrese una opción válida. Presione enter para continuar.");
        Console.ReadLine();
        Console.Clear(); // Limpiar la consola para comenzar de nuevo
        continue;
    }
    else
    {
        switch (temperatura)
        {
            case double t when t < 0:
                mensaje = "Hace mucho frío afuera, asegúrate de abrigarte bien.";
                break;
            case double t when t >= 0 && t <= 20:
                mensaje = "El clima está fresco, una chaqueta ligera sería perfecta.";
                break;
            case var t when t > 20:
                mensaje = "Hace calor afuera, no necesitas una chaqueta.";
                break;
            default:
                mensaje = "No se puede determinar el clima.";
                break;
        }

        Console.WriteLine(mensaje);
    }

    //pronóstico extendido
    do
    {        
        Console.WriteLine("\n¿Quieres conocer el pronóstico para los próximos cinco días? 1-Sí. 2-No:");
        if (!int.TryParse(Console.ReadLine(), out opcionElegida))
        {
            Console.WriteLine("Ingrese una opción válida. Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        else
        {
            if (opcionElegida == 1)
            {
                Console.WriteLine("\nPronóstico para los próximos cinco días:");
                // Se genera un número double aleatorio entre min (inclusive) y max (exclusive)
                temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
                // Interpolación de cadenas
                Console.WriteLine($"Lunes: {temperaturaRandom} ºC");

                temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
                Console.WriteLine($"Martes: {temperaturaRandom} ºC");

                temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
                Console.WriteLine($"Miércoles: {temperaturaRandom} ºC");

                temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
                Console.WriteLine($"Jueves: {temperaturaRandom} ºC");

                temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
                Console.WriteLine($"Viernes: {temperaturaRandom} ºC");

                pronosticoExtendido = false;
            }
            else
            {
                if(opcionElegida == 2){
                    pronosticoExtendido = false;
                }
                else
                {
                    if (opcionElegida != 2){
                        Console.WriteLine("Ingrese una opción válida. Presione enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                }                
            }
        }
    } while (pronosticoExtendido);

    //consultar otro prónostico
    do
    {
        Console.WriteLine("\n¿Quieres consultar otro pronóstico? 1-Sí. 2-No:");
        if (!int.TryParse(Console.ReadLine(), out opcionElegida)){
            Console.WriteLine("Ingrese una opción válida. Presione enter para continuar.");
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        else
        {            
            if(opcionElegida == 1){
                pronostico = true;
                pronosticoOtro = false;
                Console.Clear();
            }
            else{
                if (opcionElegida == 2){
                    Console.WriteLine("\nGracias por usar nuestra aplicación de pronóstico del clima. ¡Hasta luego!");
                    pronostico = false;
                    pronosticoOtro = false;
                }
                else{
                    if (opcionElegida != 1 && opcionElegida != 2){
                        Console.WriteLine("Ingrese una opción válida. Presione enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        pronosticoOtro = true;
                    }                                 
                }
            }
        }                                    
    } while (pronosticoOtro);        

} while (pronostico);