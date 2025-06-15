# 🁢 Juego de Dominó con GUI en Visual Studio 2022

Este proyecto crea un juego de dominó con interfaz gráfica (GUI) en Visual Studio 2022 usando **Windows Forms (WinForms)** y **C#**. Es una versión básica en modo local para 2 jugadores humanos.

---

## ✅ 1. Crear el Proyecto

1. Abre Visual Studio 2022.
2. Ve a `Archivo → Nuevo → Proyecto`.
3. Selecciona **Aplicación de Windows Forms (.NET Framework)** en C#.
4. Ponle nombre: `DominoWinForms`.
5. Asegúrate de seleccionar `.NET Framework 4.7.2` o superior.

---

## ✅ 2. Estructura del Juego

Clases básicas necesarias:

- `FichaDomino`: Representa cada ficha del dominó.
- `Jugador`: Representa un jugador y sus fichas.
- `JuegoDomino`: Controla la lógica del juego.

---

## ✅ 3. Código de Ejemplo Básico

### 📄 `FichaDomino.cs`

```csharp
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
📄 Jugador.cs
csharp

using System.Collections.Generic;

public class Jugador
{
    public string Nombre { get; set; }
    public List<FichaDomino> Fichas { get; set; } = new();

    public Jugador(string nombre)
    {
        Nombre = nombre;
    }
}
📄 JuegoDomino.cs
csharp

using System;
using System.Collections.Generic;
using System.Linq;

public class JuegoDomino
{
    public List<FichaDomino> FichasMesa { get; set; } = new();
    public List<FichaDomino> FichasDisponibles { get; private set; } = new();
    public Jugador Jugador1 { get; private set; }
    public Jugador Jugador2 { get; private set; }
    public int Turno { get; private set; } = 1;

    public JuegoDomino(string nombre1, string nombre2)
    {
        Jugador1 = new Jugador(nombre1);
        Jugador2 = new Jugador(nombre2);
        GenerarFichas();
        RepartirFichas();
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

    public void SiguienteTurno() => Turno++;
}

✅ 4. Diseño del Formulario (GUI)
Desde el diseñador de WinForms agrega:

Un ListBox para las fichas del jugador actual (lstFichas).

Un ListBox para las fichas en la mesa (lstMesa).

Un botón btnColocarFicha.

Un Label para mostrar el jugador actual (lblJugador).

✅ 5. Código del Formulario
📄 Form1.cs
csharp

public partial class Form1 : Form
{
    JuegoDomino juego;

    public Form1()
    {
        InitializeComponent();
        juego = new JuegoDomino("Jugador 1", "Jugador 2");
        ActualizarInterfaz();
    }

    private void ActualizarInterfaz()
    {
        var jugadorActual = juego.ObtenerJugadorActual();
        lblJugador.Text = $"Turno: {jugadorActual.Nombre}";

        lstFichas.Items.Clear();
        foreach (var ficha in jugadorActual.Fichas)
            lstFichas.Items.Add(ficha);

        lstMesa.Items.Clear();
        foreach (var ficha in juego.FichasMesa)
            lstMesa.Items.Add(ficha);
    }

    private void btnColocarFicha_Click(object sender, EventArgs e)
    {
        var jugador = juego.ObtenerJugadorActual();
        if (lstFichas.SelectedItem is FichaDomino fichaSeleccionada)
        {
            if (juego.FichasMesa.Count == 0 ||
                fichaSeleccionada.PuedeConectarseCon(juego.FichasMesa.First().Lado1) ||
                fichaSeleccionada.PuedeConectarseCon(juego.FichasMesa.Last().Lado2))
            {
                juego.FichasMesa.Add(fichaSeleccionada);
                jugador.Fichas.Remove(fichaSeleccionada);
                juego.SiguienteTurno();
                ActualizarInterfaz();
            }
            else
            {
                MessageBox.Show("No se puede colocar esa ficha.");
            }
        }
    }
}

✅ 6. Compila y Ejecuta
Presiona F5 para compilar y probar el juego. Verás una interfaz básica donde puedes seleccionar una ficha y colocarla en la mesa.

🛠️ 7. Ideas para Mejoras
Agregar imágenes para las fichas (PictureBox).

Soporte para rotar fichas.

Agregar una IA básica para jugar contra la computadora.

Mostrar puntajes de cada jugador.

Validar ganador al quedarse sin fichas.

