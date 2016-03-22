using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {
            Money m1 = new Money(10, Currency.Franken);
            Money m2 = new Money(20, Currency.Franken);
            var newMoney = m1 + m2;
            Console.Write(newMoney.Amount);
            Console.Write(" " + newMoney.Currency.ToString());
            Console.ReadKey();
        }
    }

    public class Money
    {
        public double Amount { get; set; }

        public Currency Currency { get; set; }

        public Money(double amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money m1, Money m2)
        {
            return new Money(m1.Amount + m2.Amount, m1.Currency);
        }

    }

    public enum Currency
    {
        Franken,
        Euro,
        Dollar
    }
}
