using System;

namespace Juego_de_Craps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de Craps!");

            Craps juego = new Craps();
            juego.Jugar();

            Console.ReadKey();
        }
    }
}