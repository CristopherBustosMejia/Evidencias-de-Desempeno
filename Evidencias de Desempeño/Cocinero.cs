using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencias_de_Desempeño
{
    internal class Cocinero : Personal
    {
        string Compañero;

        public Cocinero() 
        {   
        }

        public void AsignarCompañero(string Compañero) 
        {
            this.Compañero = Compañero;
        }
    }
}
