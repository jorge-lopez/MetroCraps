using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroCraps
{
    class Craps
    {

        private static int ronda = 1;
        private static int punto = 1;

        public static int Punto { get { return punto; } }
        enum ESTADO
        {
            PERDIO = -1,
            CONTINUA,
            GANO
        };

        enum JUGADAS
        {
            SNAIK_AYS = 2, 
            TREY,
            SEVEN = 7,
            YO_LEVEN = 11,
            BOX_CARS
        };

        public static int Jugar(out int PrimerDado, out int SegundoDado)
        {
            if (ronda == 1)
            {
                int estado = PrimeraJugada(out PrimerDado, out SegundoDado);
                switch ((ESTADO)estado)
                {
                    case ESTADO.PERDIO:
                        return (int)ESTADO.PERDIO;
                    case ESTADO.CONTINUA:
                        punto = PrimerDado + SegundoDado;
                        ronda++;
                        return (int)ESTADO.CONTINUA;
                    case ESTADO.GANO:
                        return (int)ESTADO.GANO;
                    default:
                        return (int)ESTADO.PERDIO;
                }
            }

            else
            {
                int estado = SiguientesJugadas(out PrimerDado, out SegundoDado, punto);
                switch ((ESTADO)estado)
                {
                    case ESTADO.PERDIO:
                        RestaurarValores();
                        return (int)ESTADO.PERDIO;
                    case ESTADO.CONTINUA:
                        return (int)ESTADO.CONTINUA;
                    case ESTADO.GANO:
                        RestaurarValores();
                        return (int)ESTADO.GANO;
                    default:
                        return (int)ESTADO.CONTINUA;
                }
            }
        }
        private static int SiguientesJugadas(out int PrimerDado, out int SegundoDado, int punto)
        {
            int dados = TirarDados(out PrimerDado, out SegundoDado);

            if (dados == punto)
            {
                return (int)ESTADO.GANO;
            }
            else if(dados == (int)JUGADAS.SEVEN)
            {
                return (int)ESTADO.PERDIO;
            }
            else
            {
                return (int)ESTADO.CONTINUA;
            }
        }
        private static int PrimeraJugada(out int PrimerDado, out int SegundoDado) 
        {
            switch ((JUGADAS)TirarDados(out PrimerDado,out SegundoDado))
            {
                case JUGADAS.SNAIK_AYS:
                    return (int)ESTADO.PERDIO;
                case JUGADAS.TREY:
                    return (int)ESTADO.PERDIO;
                case JUGADAS.SEVEN:
                    return (int)ESTADO.GANO;
                case JUGADAS.YO_LEVEN:
                    return (int)ESTADO.GANO;
                case JUGADAS.BOX_CARS:
                    return (int)ESTADO.PERDIO;
                default:
                    return (int)ESTADO.CONTINUA;
            }
        }
        private static int TirarDados(out int PrimerDado, out int SegundoDado) 
        {
            Random r = new Random();
            PrimerDado = r.Next(1, 6);
            SegundoDado = r.Next(1, 6);

            int suma = PrimerDado + SegundoDado;

            return suma;
        }
        private static void RestaurarValores()
        {
            ronda = 1;
            punto = 1;
        }
    }
}
