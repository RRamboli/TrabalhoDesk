using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliação1
{
    internal class Angulo
    {
        public Angulo()
        {
            Graus = 0;
            Minutos = 0;
            Segundos = 0;
        }
        public Angulo(int graus, int minutos, int segundos)
        {
            Graus = graus;
            Minutos = minutos;
            Segundos = segundos;
        }

        public int Graus { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public override string ToString()
        {
            return String.Concat(Graus + "° " + Minutos + "' " + Segundos + "'' ");
        }
    }
}
