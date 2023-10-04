using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Avaliação1
{
    internal class Estacao : Angulo
    {
            public double distancia;
            public int numero;
            public char deflexao;
            public Angulo agEstacao;
            public Angulo azimute;

            public Estacao(int num, double dis, char def, Angulo ag, Angulo az)
            {
                numero = num;
                distancia = dis;
                deflexao = def;
                agEstacao = ag;
                azimute = az;
            }
            public Estacao()
            {
                numero = 1;
                distancia = 0;
                deflexao = ' ';
                agEstacao = new Angulo();
                azimute = new Angulo();

            }
            public Angulo AngEstacao
            {
                get { return AngEstacao; }
                set { AngEstacao = value; }
            }
            public int Numero
            {
                get { return numero; }
                set { numero = value; }
            }
            public double Distancia
            {
                get { return distancia; }
                set { distancia = value; }
            }

            public char Deflexao
            {
                get { return deflexao; }
                set { deflexao = value; }
            }
            public override string ToString()
            {
                return String.Concat("".PadLeft(3) + Numero + "".PadRight(16)
                                    + AngEstacao + "".PadRight(9)
                                    + "".PadLeft(9) + Deflexao + "".PadRight(19)
                                    + Distancia + "".PadRight(9)
                                    + "".PadLeft(10) + azimute);
            }
    }

}