namespace Modulo3Library
{
    public static class CalculoTemperaturas
    {
        /*funciones que creas convenientes que están relacionadas a algún tipo de cálculo del programa, como por ejemplo, CalcularTemperaturaPromedio o similares. 
         Solo recuerda que estos métodos harán cálculo sobre algún parámetro que reciban de tipo de la colección seguramente
         */        

        public static double ObtenerTemperaturaPromedioMensual(RegistroTemperatura[,] TemperaturasDiarias)
        {
            double temperaturaTotal = 0, temperaturaPromedioMensual = 0;
            int dia = 0;
            RegistroTemperatura registro;

            for (int i = 0; i < TemperaturasDiarias.GetLength(0); i++)
            {
                for (int j = 0; j < TemperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    registro = TemperaturasDiarias[i, j];
                    //acumulando temperatura total de la semana
                    temperaturaTotal += registro.TemperaturaRegistrada;
                }
            }
            temperaturaPromedioMensual = Math.Round(temperaturaTotal / 31, 2);

            return temperaturaPromedioMensual;
        }

        public static RegistroTemperatura ObtenerTemperaturaMinimaMensual(RegistroTemperatura[,] TemperaturasDiarias)
        {
            int dia = 0;
            int minima = 40;
            RegistroTemperatura registro;
            RegistroTemperatura temperaturaMinima = null;

            for (int i = 0; i < TemperaturasDiarias.GetLength(0); i++)
            {
                for (int j = 0; j < TemperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    registro = TemperaturasDiarias[i, j];
                    if (registro.TemperaturaRegistrada < minima)
                    {
                        minima = registro.TemperaturaRegistrada;
                        temperaturaMinima = registro;
                    }

                }
            }            
            return temperaturaMinima;
        }

        public static RegistroTemperatura ObtenerTemperaturaMaximaMensual(RegistroTemperatura[,] TemperaturasDiarias)
        {
            int dia = 0;
            int maxima = -10;
            RegistroTemperatura registro;
            RegistroTemperatura temperaturaMaxima = null;

            for (int i = 0; i < TemperaturasDiarias.GetLength(0); i++)
            {
                for (int j = 0; j < TemperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    registro = TemperaturasDiarias[i, j];
                    if (registro.TemperaturaRegistrada > maxima)
                    {
                        maxima = registro.TemperaturaRegistrada;
                        temperaturaMaxima = registro;
                    }
                }
            }            
            return temperaturaMaxima;
        }

        public static string obtenerTemperaturaDiaEspecifico(int dia, RegistroTemperatura[,] TemperaturasDiarias)
        {
            int diaActual = 0;
            RegistroTemperatura registro = null;
            string mensaje;            
            for (int i = 0; i < TemperaturasDiarias.GetLength(0); i++)
            {
                for (int j = 0; j < TemperaturasDiarias.GetLength(1); j++)
                {
                    diaActual++;

                    if (diaActual == dia)
                    {
                        registro = TemperaturasDiarias[i, j];                        
                        break;
                    }

                    if (diaActual == 32)
                        break;
                }
            }

            if (diaActual == 32)
                return $"\nNo se encontró el día ingresado.";            

            mensaje = $"El {registro.NombreDia} {dia} del mes, la temperatura fue {registro.TemperaturaRegistrada} ºC.";
            if (registro.TemperaturaRegistrada < 0)
                return $"\n{mensaje} Hizo mucho frío.";

            if (registro.TemperaturaRegistrada < 20)
                return $"\n{mensaje} El clima estaba fresco.";

            return $"\n{mensaje} Hizo calor afuera.";            
        }
    }
}
