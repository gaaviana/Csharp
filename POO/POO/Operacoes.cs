using System;
using System.Collections.Generic;
using System.Text;

namespace POO
{
    public class Operacoes
    {
        decimal saldo = 1000;

        public void Saldo()
        {
            Console.WriteLine($"Seu saldo é de R$ {saldo}");
        }
        public void Deposito()
        {
            Console.WriteLine("Informe o valor a ser depositado: R$ ");
            
            if(decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
            {
                saldo += valor;
            }
            else
            {
                Console.WriteLine("Valor invalido. Tente novamente");
            }
        }
        public void Saque()
        {
            Console.WriteLine("Informe o valor a ser retirado: R$ ");

            if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
            {
                if (valor <= saldo)
                {
                    Console.WriteLine($"Valor de R$ {valor} retirado com sucesso!");
                    Console.WriteLine($"Saldo atual: R$ {saldo - valor}");
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente");
                }
            }
            else
            {
                Console.WriteLine("Valor invalido. Tente novamente");
            }
        }
    }
}
