using System;
using System.Collections.Generic;
using System.Collections;

namespace Laboratorio7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] lista = {"Julio", "Lucia", "Daniel", "Joao"};
            Console.WriteLine("Array antes da ordenação: ");
            for (int i = 0; i < lista.Length; i++) {
                Console.WriteLine(lista[i] + " ");
            }
            Console.WriteLine();
            Array.Sort(lista);
            Console.WriteLine("Array depois da ordenção: ");
            for (int i = 0; i < lista.Length; i++) {
                Console.WriteLine(lista[i] + " ");
            }

            Console.WriteLine();
            */
            List<Pessoa> pessoas = new List<Pessoa>()
            {
                new Pessoa {Nome = "Julio", Idade = 30},
                new Pessoa {Nome = "Lucia", Idade = 25},
                new Pessoa {Nome = "Daniel", Idade = 20},
                new Pessoa {Nome = "Julio", Idade = 15}
            };
            Console.WriteLine("Pessoas:");
            foreach (Pessoa pessoa in pessoas)
            {
                Console.WriteLine(pessoa.Nome + " " + pessoa.Idade);
            }

            //pessoas.Sort();
            //pessoas.Sort(new PessoaComparadorIdade());

            pessoas.Sort((p1,p2) => p1.Nome.CompareTo(p2.Nome));
            Console.WriteLine("Pessoas ordenadas:");
            foreach (Pessoa pessoa in pessoas)
            {
                Console.WriteLine(pessoa.Nome + " " + pessoa.Idade);
            }
            Console.WriteLine(pessoas.Exists(p => p.Nome == "Julio"));


            /*
            Array.Sort(lista2);
            Console.WriteLine("Array 2 depois da ordenação: ");
             for (int i = 0; i < lista2.Length; i++) {
                Console.WriteLine(lista2[i] + " ");
            }
            */

            ArrayList temperatures = new ArrayList();
            // Initialize random number generator.
            Random rnd = new Random();

            // Generate 10 temperatures between 0 and 100 randomly.
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int degrees = rnd.Next(0, 100);
                Temperature temp = new Temperature();
                temp.Fahrenheit = degrees;
                temperatures.Add(temp);
            }

            // Sort ArrayList.
            temperatures.Sort();

            foreach (Temperature temp in temperatures)
                Console.WriteLine(temp.Fahrenheit);
        }
    }
}