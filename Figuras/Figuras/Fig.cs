namespace Aplicacion
{
    public class Fig
    {
        
        public IFig GenerarFigura(string figura)
        {
            if(figura == "circulo")
            {
                return new Circulo();
            }

            else if(figura == "rectangulo")
            {
                return new Rectangulo();
            }

            else if(figura == "triangulo")
            {
                return new Triangulo();
            }

            else
            {
                return new Finex();
            }
        }

    }
}
