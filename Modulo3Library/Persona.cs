namespace Modulo3Library
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }        

        public Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;            
        }

        public override string ToString() {
            return $"{Apellido}, {Nombre}.";
        }
    }
}
