namespace Libreria
{
    public class CalCanvas
    {
        public int ancho;
        public int alto;
        public int fuente;
        public double tamPuntoPixel = 0.5;

        public string procesar(int[] areas, string[] tipos, string[] textos, int[] espaciosTextos)
        {
            int areaTotal = CalcularArea(areas);
            bool canvasValido = ValidarAreaCanvas(areaTotal);

            string respuesta = "";

            if (canvasValido)
            {
                string[] figurasIncorrectas = ListarFigurasIncorrectas(areas, tipos, textos, espaciosTextos);

                if(figurasIncorrectas.Length > 0) 
                {
                    respuesta = "Error: las palabras de una o más figuras son grandes para su espacio en " + figurasIncorrectas[0];
                    for (int i = 1; i < figurasIncorrectas.Length; i++)
                    {
                        if(i == (figurasIncorrectas.Length - 1))
                        {
                            respuesta = respuesta + " y " + figurasIncorrectas[i];
                        }
                        else
                        {
                            respuesta = respuesta + ", " + figurasIncorrectas[i];
                        }
                    }
                }
                else
                {
                    respuesta = "las figuras si se pueden dibujar con sus palabras dentro del canvas";

                }
            }
            else
            {
                respuesta = "Error:los valores de la suma del área de las figuras geometricas(" + areaTotal + ") son mas altas que el area del canvas(" + (ancho * alto) + ")";
            }

            return respuesta;
        }

        public int CalcularArea(int[] areas)
        {
            int areaTotal = 0;

            for(int i = 0; i< areas.Length; i++)
            {
                areaTotal = areaTotal + areas[i];
            }

            return areaTotal;
        }

        public bool ValidarAreaCanvas(int areaTotal)
        {
            int areaCanvas = ancho * alto;
            if(areaCanvas >= areaTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] ListarFigurasIncorrectas(int[] areas, string[] tipos, string[] textos, int[] espaciosTextos) 
        {
            List<string> listaFigurasIncorrectas = new List<string>();

            for (int i = 0; i < espaciosTextos.Length; i++) 
            {
                int longitudTexto = CalcularLongitudTexto(textos[i]);
                bool validado = ValidarTexto(espaciosTextos[i], longitudTexto);

                if (!validado)
                {
                    string errorTextoFigura = "La figura geometrica" + tipos[i] + " cuenta con espacio disponible " + ((espaciosTextos[i] / 3) * 2) + " pero la palabra '" + textos[i] + "' contiene un espacio de " + longitudTexto;
                    listaFigurasIncorrectas.Add(errorTextoFigura);
                }
            }

            string[] figurasIncorrectas = listaFigurasIncorrectas.ToArray();

            return figurasIncorrectas;
        }

        public bool ValidarTexto(int espacio, int longitudTexto)
        {
            double espacioFigura = (espacio / 3) * 2;
            if(espacioFigura >= longitudTexto)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CalcularLongitudTexto(string texto)
        {
            double longitudTexto = fuente * tamPuntoPixel * texto.Length;
            return (int)longitudTexto;
        }

    }
}