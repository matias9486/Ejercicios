namespace Modulo3Library
{
    public class Profesional: Persona
    {
        public int NroMatricula { get; set; }

        public Profesional(string nombre, string apellido, int nroMatricula):base(nombre, apellido)
        {
            NroMatricula = nroMatricula;
        }

        public override string ToString()
        {
            return $"Profesional: {base.ToString()}";
        }
    }
}
