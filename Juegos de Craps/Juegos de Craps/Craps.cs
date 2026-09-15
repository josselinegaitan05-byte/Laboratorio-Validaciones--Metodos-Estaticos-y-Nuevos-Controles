using System;

namespace Juego_de_Craps
{
    public class Craps
    {
        // crea el generador de números aleatorios para usarlo en el método TirarDados
        private Random numerosAleatorios = new Random();

        // enumeración con constantes que representan el estado del juego
        private enum Estado { CONTINUA, GANO, PERDIO }

        // enumeración con constantes que representan tiros comunes del dado
        private enum NombreDados
        {
            DOS_UNO = 2,
            TRES = 3,
            SIETE = 7,
            ONCE = 11,
            DOCE = 12
        }

        // ejecuta un juego de craps
        public void Jugar()
        {
            // estadoJuego puede contener CONTINUA, GANO o PERDIO
            Estado estadoJuego = Estado.CONTINUA;
            int miPunto = 0; // punto si no gana ni pierde en el primer tiro

            int sumaDeDados = TirarDados(); // primer tiro de los dados

            // determina el estado del juego y el punto con base en el primer tiro
            // conversión explícita (o casting)
            switch ((NombreDados)sumaDeDados)
            {
                case NombreDados.SIETE: // gana con 7 en el primer tiro
                case NombreDados.ONCE:  // gana con 11 en el primer tiro
                    estadoJuego = Estado.GANO;
                    break;

                case NombreDados.DOS_UNO: // pierde con 2 en el primer tiro
                case NombreDados.TRES:    // pierde con 3 en el primer tiro
                case NombreDados.DOCE:    // pierde con 12 en el primer tiro
                    estadoJuego = Estado.PERDIO;
                    break;

                default: // no ganó ni perdió, entonces hay que recordar el punto
                    estadoJuego = Estado.CONTINUA;
                    miPunto = sumaDeDados;
                    Console.WriteLine($"El punto es {miPunto}");
                    break;
            } // fin de switch

            // mientras el juego no haya terminado, sigue tirando
            while (estadoJuego == Estado.CONTINUA)
            {
                sumaDeDados = TirarDados();

                if (sumaDeDados == miPunto) // gana volviendo a sacar el punto
                {
                    estadoJuego = Estado.GANO;
                }
                else if (sumaDeDados == 7) // pierde sacando un 7 antes del punto
                {
                    estadoJuego = Estado.PERDIO;
                }
            } // fin de while

            // muestra el resultado final del juego
            if (estadoJuego == Estado.GANO)
            {
                Console.WriteLine("El jugador gana");
            }
            else
            {
                Console.WriteLine("El jugador pierde");
            }
        } // fin del método Jugar

        // tira los dados, calcula su suma, la muestra y la devuelve
        public int TirarDados()
        {
            int dado1 = numerosAleatorios.Next(1, 7);
            int dado2 = numerosAleatorios.Next(1, 7);

            int suma = dado1 + dado2;

            Console.WriteLine($"El jugador lanzó {dado1} + {dado2} = {suma}");

            return suma;
        } // fin del método TirarDados
    } // fin de la clase Craps
}