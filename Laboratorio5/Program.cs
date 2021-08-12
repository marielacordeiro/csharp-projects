using System;
using System.Collections.Generic;

namespace Laboratorio5 {
    class Program
    {
        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>();
            contas.Add(new ContaPoupanca(0.1M, new DateTime(2021,8,12), "12345678901") {
                Saldo = 500,  Titular = "Ana Clara"
            });
            contas.Add(new ContaPoupanca(0.01M, new DateTime(2021,1,5), "12345678902"));

            foreach (Conta conta in contas) {
                 Console.WriteLine($"Id: {conta.Id} Saldo: {conta.Saldo}");
            }

            ContaPoupanca c1 = (ContaPoupanca)contas[0];
            c1.AdicionarRendimento();
            Console.WriteLine(c1.Saldo);
            c1.AdicionarRendimento();
            Console.WriteLine(c1.Saldo);
            Console.WriteLine(c1.DataAniversario);
            Console.WriteLine(c1.Juros);
            c1.Sacar(50);
            Console.WriteLine(c1.Saldo);


            // Conta[] contas = new Conta[2];
            // contas[0] = new ContaPoupanca(0.01M, new DateTime(2020,3,10), "12345678901");
            // contas[1] = new ContaPoupanca(0.01M, new DateTime(2021,1,5), "12345678902");
            // foreach (Conta c in contas)
            // {
            //     Console.WriteLine($"Id: {c.Id} Saldo: {c.Saldo}");
            // }
        }
    }
}

