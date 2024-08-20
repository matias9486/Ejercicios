namespace Modulo3Library
{
    /*Las colecciones deben ir en una clase llamada EstacionMeteorologica, con los siguientes métodos:
    - Un método llamado RegistrarTemperatura, que recibirá un objeto de tipo RegistroDemperatura, para ser almacenado en la matriz.
    Un método VerTemperaturas, con parámetro para elegir qué colección ver. Este método puede devolver sólo las temperaturas.
    Utiliza el constructor para la carga inicial de la matriz, si usaste carga automática.
    Utiliza un método de carga para la matriz, si le pediste al usuario que cargue manualmente.
    Puedes agregar algunas funciones anteriores como métodos de esta clase, como por ejemplo "Ver temperatura de un día específico". 
        Tu eliges las que creas conveniente que pueden ir en esta clase.
    Recuerda que ahora la matriz ya no es de tipo int, sino que almacena objetos de la clase nueva Registro! Modificalo!
     */
    public class EstacionMeteorologica
    {
        public RegistroTemperatura[,] TemperaturasDiarias { get; set; }        
        public List<double> TemperaturaPromedioSemanal { get; set; }
        public List<RegistroTemperatura> TemperaturaEncimaUmbral { get; set; }
        public double TemperaturaUmbral { get; set; }

        public EstacionMeteorologica(double temperaturaUmbral)
        {
            TemperaturasDiarias = new RegistroTemperatura[5, 7]; //Arreglo de 5x7 para semanas y dias                        
            TemperaturaPromedioSemanal = new List<double>();
            TemperaturaEncimaUmbral = new List<RegistroTemperatura>();
            TemperaturaUmbral = temperaturaUmbral;            
        }

        public void RegistrarTemperatura(int semana, int dia, RegistroTemperatura registro)
        {
            this.TemperaturasDiarias[semana, dia] = registro;
        }        

        public void SimularCargaTemperaturas(List<Persona> personasDeTurno)
        {
            Random random = new Random();   //Para generar temperatura random
            int min = 0, max = 35, numeroDia = 0; //temperaturas min y max para generar temperatura random. Y dias para interrumpir ciclo.
            int temperaturaRandom;
            int indicePersonaTurno = 0, registrosIngresados = 0;
            Persona personaDeTurno;

            for (int i = 0; i < TemperaturasDiarias.GetLength(0); i++)
            {
                for (int j = 0; j < TemperaturasDiarias.GetLength(1); j++)
                {
                    numeroDia++;
                    if (numeroDia == 32)
                        break;

                    //Para que carguen registros las 6 personas, se iran cambiando cada 6 registros. La lista de personas se supone tiene intercalados profesional y pasante
                    registrosIngresados++;
                    if(registrosIngresados >6)
                    {
                        indicePersonaTurno++;
                        registrosIngresados = 1;
                    }
                    personaDeTurno = personasDeTurno.ElementAt(indicePersonaTurno);

                    // Se genera un número entero aleatorio entre min (incluido y max(excluido)
                    temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));

                    //Uso de DateTime y Conversion de DateTime a DateOnly y TimeOnly
                    DateTime fechaCompleta = DateTime.Now;                    
                    DateOnly fecha = DateOnly.FromDateTime(fechaCompleta);
                    TimeOnly hora = TimeOnly.FromDateTime(fechaCompleta);

                    DiasSemana nombreDia = (DiasSemana)j;
                    //Instancia para registrar temperatura
                    RegistroTemperatura registro = new RegistroTemperatura(nombreDia, numeroDia ,temperaturaRandom, personaDeTurno, fecha, hora);
                    RegistrarTemperatura(i, j, registro);
                }
            }
        }

        public string MostrarTemperaturasDiarias()
        {
            string mensaje = "\nTemperaturas Diarias:";
            int dia = 0;
            for (int i = 0; i < TemperaturasDiarias.GetLength(0); i++)
            {
                mensaje += $"\nSemana {i + 1}:";
                for (int j = 0; j < TemperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;
                    RegistroTemperatura registro = TemperaturasDiarias[i, j];                    
                    mensaje += $"\n\t{registro.NombreDia} {registro.NumeroDia}. Temperatura: {registro.TemperaturaRegistrada} ºC. Registrado el {registro.FechaRegistro} a las {registro.HoraRegistro} por {registro.PersonaDeTurno.ToString()}";
                }
                mensaje += "\n";
            }
            return mensaje;
        }

        public List<RegistroTemperatura> ObtenerTemperaturasEncimaUmbral()
        {
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
                    if (registro.TemperaturaRegistrada > TemperaturaUmbral)
                    {                                                
                        TemperaturaEncimaUmbral.Add(registro);
                    }
                }
            }
            return TemperaturaEncimaUmbral;
        }

        public List<double> ObtenerTemperaturasPromedioSemanal()
        {
            double temperaturaTotalSemanal = 0, temperaturaPromedio = 0;
            int dia = 0;
            RegistroTemperatura registro;  

            for (int i = 0; i < TemperaturasDiarias.GetLength(0); i++)
            {
                temperaturaTotalSemanal = 0;
                for (int j = 0; j < TemperaturasDiarias.GetLength(1); j++)
                {
                    dia++;
                    if (dia == 32)
                        break;

                    registro = TemperaturasDiarias[i, j];
                    //acumulando temperatura total de la semana
                    temperaturaTotalSemanal += registro.TemperaturaRegistrada;
                }

                //si es la 4 semana, solo tiene 3 dias para calcula el promedio
                if (i == 4)
                    temperaturaPromedio = Math.Round(temperaturaTotalSemanal / 3, 2);
                else
                    temperaturaPromedio = Math.Round(temperaturaTotalSemanal / 7, 2);
                TemperaturaPromedioSemanal.Add(temperaturaPromedio);
            }

            return TemperaturaPromedioSemanal;
        }
                
        public string VerTemperaturas(TipoColeccion tipoColeccion)
        {
            string mensaje = "";
            switch (tipoColeccion)
            {
                case TipoColeccion.TEMPERATURAS_DIARIAS:
                    mensaje += MostrarTemperaturasDiarias();
                    break;
                case TipoColeccion.TEMPERATURAS_PROMEDIO_SEMANAL:
                    List<double> temperaturaPromedioSemanal = ObtenerTemperaturasPromedioSemanal();
                    mensaje += "\nTemperaturas promedio semanales:";
                    for (int i = 0; i < temperaturaPromedioSemanal.Count; i++)
                    {
                        mensaje += $"\n\tLa temperatura promedio de la semana {i + 1} es: {temperaturaPromedioSemanal[i]} ºC.";
                    }                    
                    break;
                case TipoColeccion.TEMPERATURAS_ENCIMA_UMBRAL:
                    mensaje += $"\nTemperaturas por encima de {TemperaturaUmbral} ºC:";
                    foreach (RegistroTemperatura registro in ObtenerTemperaturasEncimaUmbral())
                    {
                        mensaje += $"\n\t{registro.NombreDia} {registro.NumeroDia}. Temperatura: {registro.TemperaturaRegistrada} ºC. Registrada por: {registro.PersonaDeTurno.ToString()}";
                    }                    
                    break;
                default:
                    mensaje = "No ingreso una opción válida.";
                    break;
            }
            return mensaje;
        }

        public string obtenerPronosticoExtendido()
        {
            Random random = new Random();   //Para generar temperatura random
            int temperaturaRandom, min = 0, max = 35; //temperaturas min y max para generar temperatura random
            string mensaje = "Pronóstico para los próximos cinco días:";
            DiasSemana dia;
            // Se genera un número aleatorio entre min y max para los primeros 5 dias
            for (int i = 0; i < 5; i++)
            {
                temperaturaRandom = (int)(min + (random.NextDouble() * (max - min)));
                dia = (DiasSemana)i;
                mensaje += $"\n\t{dia}: {temperaturaRandom} ºC";
            }
            return $"\n{mensaje}";
        }
    }
}