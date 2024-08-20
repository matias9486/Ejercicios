namespace Modulo3Library
{
    public class Pasante: Persona
    {
        public int NroLegajo { get; set; }

        public Pasante(string nombre, string apellido, int nroLegajo) : base(nombre, apellido)
        {
            NroLegajo = nroLegajo;
        }

        public override string ToString()
        {
            return $"Pasante: {base.ToString()}";
        }
    }
}
