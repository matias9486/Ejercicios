namespace Modulo3Library
{
    public class RegistroTemperatura
    {
        public DiasSemana NombreDia { get; set; }
        public int NumeroDia { get; set; }
        public int TemperaturaRegistrada { get; set; }        
        public Persona PersonaDeTurno { get; set; }
        //tomo la fecha y hora de registro como el momento en que se ingreso el dato al sistema.
        //No como el dia en se que registro la temperatura, ya que puede diferir de la misma
        public DateOnly FechaRegistro { get; set; }
        public TimeOnly HoraRegistro { get; set; }

        public RegistroTemperatura(DiasSemana nombreDia, int numeroDia,  int temperatura, Persona personaDeTurno, DateOnly fechaRegistro, TimeOnly horaRegistro)
        {
            NombreDia = nombreDia;
            NumeroDia = numeroDia;
            TemperaturaRegistrada = temperatura;
            PersonaDeTurno = personaDeTurno;
            FechaRegistro = fechaRegistro;
            HoraRegistro = horaRegistro;
        }
    }
}
