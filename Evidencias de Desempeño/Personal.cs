using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencias_de_Desempeño
{
    internal class Personal
    {
        public string Nombre;
        public string ID;
        public string HoraEntrada;
        public string HoraSalida = "";

        public Personal()
        {
        }
        public string RegistrarEntrada(string Hora)
        {
            HoraEntrada = Hora;
            return HoraEntrada;
        }

        public string RegistrarSalida(string hora)
        {
            HoraSalida = hora;
            return HoraSalida;
        }
    }
}
