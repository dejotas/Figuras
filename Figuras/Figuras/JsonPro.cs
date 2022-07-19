using Newtonsoft.Json;

namespace Aplicacion
{
    public class JsonPro
    {
        public bool ValidarJson()
        {

            try 
            {
                
                StreamReader r = new StreamReader("Figura.json");
                string jsonString = r.ReadToEnd();

                MlLista jsonObjecto = JsonConvert.DeserializeObject<MlLista>(jsonString);
                bool error = false;

                foreach (MoFigur fig in jsonObjecto.Lista)
                {
                    if (fig.Tipo != "circulo" && fig.Tipo != "rectangulo" && fig.Tipo != "triangulo") 
                    {
                        error = true;
                    }
                }

                return !error;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<IFig> ProcesarJson()
        {

            Fig figura = new Fig();
            List<IFig> figuras = new List<IFig>();

            StreamReader r = new StreamReader("Figura.json");
            string jsonString = r.ReadToEnd();

            MlLista jsonObjecto = JsonConvert.DeserializeObject<MlLista>(jsonString);

            foreach (MoFigur fig in jsonObjecto.Lista)
            {

                IFig instanciaFigura = figura.GenerarFigura(fig.Tipo);
                instanciaFigura.Tipo = fig.Tipo;
                instanciaFigura.Texto = fig.Texto;
                instanciaFigura.Caracteristicas = fig.Caracteristicas;
                figuras.Add(instanciaFigura);

            }

            return figuras;

        }
    }
}
