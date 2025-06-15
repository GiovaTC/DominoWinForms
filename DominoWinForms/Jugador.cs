using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoWinForms
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public List<FichaDomino> Fichas { get; set; } = new();

        public Jugador(string nombre)
        {
            Nombre = nombre;
        }
    }
}
