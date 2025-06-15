using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoWinForms
{
    public class JuegoDomino
    {
        public List<FichaDomino> FichasMesa { get; set; }
        public List<FichaDomino> FichasDisponibles { get; private set; } = new();
        public Jugador Jugador1 { get; private set; }
        public Jugador Jugador2 { get; private set; }
        public int Turno { get; private set; } = 1;

        public JuegoDomino(string nombre1, string nombre2)
        {
            Jugador1 = new Jugador(nombre1);
            Jugador2 = new Jugador(nombre2);
            //GenerarFichas();
            //RepartirFichas();
        }

        private void GenerarFichas()
        {
            FichasDisponibles.Clear();
            for (int i = 0; i <= 6; i++)
                for (int j = i; j <= 6; j++)
                    FichasDisponibles.Add(new FichaDomino(i, j));

            var rand = new Random();
            FichasDisponibles = FichasDisponibles.OrderBy(f => rand.Next()).ToList();
        }

        private void RepartirFichas()
        {
            for (int i = 0; i < 7; i++)
            {
                Jugador1.Fichas.Add(FichasDisponibles[0]); FichasDisponibles.RemoveAt(0);
                Jugador2.Fichas.Add(FichasDisponibles[0]); FichasDisponibles.RemoveAt(0);
            }
        }

        public Jugador ObtenerJugadorActual() => Turno % 2 == 1 ? Jugador1 : Jugador2;

    }
}
