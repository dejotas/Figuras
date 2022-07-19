namespace Aplicacion
{
    public class Finex : IFig
    {
        public string Tipo { get; set; }
        public string Texto { get; set; }
        public string Caracteristicas { get; set; }

        public int CalcularArea(string caracteristicas) { return 0; }

        public int CalcularEspacioTexto(string caracteristicas) { return 0; }
    }
}
