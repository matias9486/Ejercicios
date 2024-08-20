using Modulo3Library;

namespace Ejercicio_Obligatorio_M3
{
    public class Program
    {
        static void Main(string[] args)
        {
            EstacionMeteorologica estacionMeteorologica = new EstacionMeteorologica(28);
            List<Persona> personasDeTurno = new List<Persona>();

            //Generacion de profesionales
            Profesional profesional1 = new Profesional("Lionel", "Messi", 1111);
            Profesional profesional2 = new Profesional("Angel", "Di Maria", 2222);
            Profesional profesional3 = new Profesional("Lionel", "Escaloni", 3333);
            //Generacion de pasantes
            Pasante pasante1 = new Pasante("Antonela", "Rocuzzo", 1111);
            Pasante pasante2 = new Pasante("Carolina", "Ardohain", 2222);
            Pasante pasante3 = new Pasante("Scarlett", "Johanson", 3333);
            //Carga de Personas a lista de personas de turno
            personasDeTurno.Add(profesional1);
            personasDeTurno.Add(pasante1);
            personasDeTurno.Add(profesional2);
            personasDeTurno.Add(pasante2);
            personasDeTurno.Add(profesional3);
            personasDeTurno.Add(pasante3);

            estacionMeteorologica.SimularCargaTemperaturas(personasDeTurno);
            
            Console.WriteLine(estacionMeteorologica.VerTemperaturas(TipoColeccion.TEMPERATURAS_DIARIAS));
            Console.WriteLine(estacionMeteorologica.VerTemperaturas(TipoColeccion.TEMPERATURAS_ENCIMA_UMBRAL));
            Console.WriteLine(estacionMeteorologica.VerTemperaturas(TipoColeccion.TEMPERATURAS_PROMEDIO_SEMANAL));
            
            Console.WriteLine($"\nLa temperatura Promedio Mensual fue {CalculoTemperaturas.ObtenerTemperaturaPromedioMensual(estacionMeteorologica.TemperaturasDiarias)} ºC.");
            
            RegistroTemperatura temperaturaFiltrada = CalculoTemperaturas.ObtenerTemperaturaMinimaMensual(estacionMeteorologica.TemperaturasDiarias);
            Console.WriteLine($"\nLa temperatura mínima del mes fue {temperaturaFiltrada.TemperaturaRegistrada}ºC, el día {temperaturaFiltrada.NombreDia} {temperaturaFiltrada.NumeroDia} del mes.");

            temperaturaFiltrada = CalculoTemperaturas.ObtenerTemperaturaMaximaMensual(estacionMeteorologica.TemperaturasDiarias);
            Console.WriteLine($"\nLa temperatura máxima del mes fue {temperaturaFiltrada.TemperaturaRegistrada}ºC, el día {temperaturaFiltrada.NombreDia} {temperaturaFiltrada.NumeroDia} del mes.");
            
            Console.WriteLine(CalculoTemperaturas.obtenerTemperaturaDiaEspecifico(3, estacionMeteorologica.TemperaturasDiarias));
            Console.WriteLine(estacionMeteorologica.obtenerPronosticoExtendido());            
        }
    }
}
