using System;

namespace Laboratorio9
{
    class Program
    {
        static void Main(string[] args)
        {
            // inicializa o termometro e mostra seu valor
            TermometroLimite term = new TermometroLimite(5);
            Console.WriteLine(term.ToString());
            // adiciona um tratador ao evento LimiteSuperiorEvent
            term.LimiteSuperiorEvent += new TermometroLimite.MeuDelegate(TrataLimiteSuperior);
            term.TemperaturaNormalEvent += new TermometroLimite.MeuDelegate(TrataTemperaturaNormal);
            // aumentar a temperatura além do limite
            term.Aumentar(6);
            Console.WriteLine(term.ToString());
            term.Diminuir(3);
            Console.WriteLine(term.ToString());
            term.Aumentar(10);
        }

        private static void TrataLimiteSuperior(string msg, double temp)
        {
            Console.WriteLine(msg + " Temperatura atual: " + temp);
        }

        private static void TrataTemperaturaNormal(string msg, double temp)
        {
            Console.WriteLine(msg + " Temperatura atual: " + temp);
        }
    }
}
