using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorio10
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa{Nome="Ana",DataNascimento=new DateTime(1980,3,14), Casada=true},
                new Pessoa{Nome="Paulo",DataNascimento=new DateTime(1978,10,23), Casada=true},
                new Pessoa{Nome="Maria",DataNascimento=new DateTime(2000,1,10), Casada=false},
                new Pessoa{Nome="Carlos",DataNascimento=new DateTime(1999,12,12), Casada=false}
            };

            var linq1 = from p in pessoas
                        where p.Casada && p.DataNascimento >= new DateTime(1980, 1, 1)
                        select p;

            foreach (var pessoa in linq1) {
                Console.WriteLine(pessoa);
            }

            var linq2 = pessoas.Where(p => p.Casada && p.DataNascimento >= new DateTime(1980, 1, 1));

            foreach (var pessoa in linq2) {
                Console.WriteLine(pessoa);
            }

            var linq3 = from p in pessoas
                        where p.Casada && p.DataNascimento > new DateTime(2020, 1, 1)
                        select p.Nome;
            linq3.ToList().ForEach(Console.WriteLine);

            
            var linq4 = pessoas.Where(p => p.Casada).Count();
            Console.WriteLine(linq4);
            /*
            var linq5 = from p in pessoas
                        group p by p.Casada;
                        */
            var linq5 = pessoas.GroupBy(p => p.Casada);
            foreach (var g in linq5)
            {
                Console.WriteLine(g.Key);
                foreach (var p in g)
                {
                    Console.WriteLine(p);
                }
            }

            var linq6 = from p in pessoas
                        group p by p.Casada into grupoPessoas 
                        select new {
                            Categoria = grupoPessoas.Key ? "Casada" : "Solteira",
                            Pessoas = grupoPessoas.ToList(),
                            Quantidade = grupoPessoas.Count()
                        };

                foreach (var pessoa in linq6) {
                    Console.WriteLine(pessoa);
                    foreach( var x in pessoa.Pessoas) {
                        Console.WriteLine(x);
                    }
                }
            
            var older = pessoas.OrderBy((pessoa) => pessoa.DataNascimento).First();
            Console.WriteLine(older);
            var youngestSingle = pessoas.Where(p => !p.Casada).OrderBy((pessoa) => pessoa.DataNascimento).Last();
            Console.WriteLine(youngestSingle);


            List<Pet> pets =
                new List<Pet>{ new Pet { Name="Barley", Age=8.0 },
                            new Pet { Name="Boots", Age=4.0 },
                            new Pet { Name="Whiskers", Age=1.0 },
                            new Pet { Name="Daisy", Age=4.0 } };

            // Group the pets using Age as the key value
            // and selecting only the pet's Name for each value.
            IEnumerable<IGrouping<double, string>> query =
                pets.GroupBy(pet => pet.Age, pet => pet.Name);

            // Iterate over each IGrouping in the collection.
            foreach (IGrouping<double, string> petGroup in query)
            {
                // Print the key value of the IGrouping.
                Console.WriteLine(petGroup.Key);
                // Iterate over each value in the
                // IGrouping and print the value.
                foreach (string name in petGroup)
                    Console.WriteLine("  {0}", name);
            }

            List<Pet> petsList =
                new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                            new Pet { Name="Boots", Age=4.9 },
                            new Pet { Name="Whiskers", Age=1.5 },
                            new Pet { Name="Daisy", Age=4.3 } };

            // Group Pet objects by the Math.Floor of their age.
            // Then project an anonymous type from each group
            // that consists of the key, the count of the group's
            // elements, and the minimum and maximum age in the group.
            var query2 = petsList.GroupBy(
                pet => Math.Floor(pet.Age),
                (age, pets) => new
                {
                    Key = age,
                    Count = pets.Count(),
                    Min = pets.Min(pet => pet.Age),
                    Max = pets.Max(pet => pet.Age)
                });

            // Iterate over each anonymous type.
            foreach (var result in query2)
            {
                Console.WriteLine("\nAge group: " + result.Key);
                Console.WriteLine("Number of pets in this age group: " + result.Count);
                Console.WriteLine("Minimum age: " + result.Min);
                Console.WriteLine("Maximum age: " + result.Max);
            }
        }
    }
}
