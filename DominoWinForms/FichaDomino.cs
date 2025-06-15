using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoWinForms
{
    public class FichaDomino
    {
        public int Lado1 { get; set; }
        public int Lado2 { get; set; }

        public FichaDomino(int lado1, int lado2)
        {
            Lado1 = lado1;
            Lado2 = lado2;
        }

        public override string ToString()
        {
            return $"[{Lado1}|{Lado2}]";
        }

        public bool EsDoble() => Lado1 == Lado2;

        public bool PuedeConectarseCon(int valor) => Lado1 == valor || Lado2 == valor;
    }
}
