using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Money m1 = new Money(10.00, Currency.Franken);
            Money m2 = new Money(20, Currency.Franken);
            
            var newMoney = m1 + m2;
            var newMoney2 = m1 + 1.5;
            var newMoney3 = 7.5 + m2;

            //Explizit Convert Money to double
            double moneyValue = (double)newMoney;

            Console.WriteLine("newMoney: "+ newMoney.ToString());
            Console.WriteLine("newMoney2: " + newMoney2.ToString());
            Console.WriteLine("newMoney3: " + newMoney3.ToString());
            Console.ReadKey();
        }
    }

    public class Money
    {
        public double Value { get; set; }

        public Currency Currency { get; set; }

        public Money(double amount, Currency currency)
        {
            Value = amount;
            Currency = currency;
        }

        public Money()
        {
            Value = 0;
            Currency = Currency.Franken;
        }

        #region Operator Overload

        public static Money operator +(Money left, Money right)
        {
            AssertCurrencyIsEqual(left,right);
            return new Money(left.Value + right.Value, left.Currency);
        }

        public static Money operator +(Money left, double right)
        {
            return new Money(left.Value + right, left.Currency);
        }

        public static Money operator +(double left, Money right)
        {
            return new Money(left + right.Value, right.Currency);
        }

        public static Money operator -(Money left, Money right)
        {
            AssertCurrencyIsEqual(left, right);
            return new Money(left.Value - right.Value, left.Currency);
        }
        public static Money operator -(Money left, double right)
        {
            return new Money(left.Value - right, left.Currency);
        }

        public static Money operator -(double left, Money right)
        {
            return new Money(left - right.Value, right.Currency);
        }

        public static Money operator *(Money left, Money right)
        {
            AssertCurrencyIsEqual(left, right);
            return new Money(left.Value * right.Value, left.Currency);
        }

        public static Money operator /(Money left, Money right)
        {
            AssertCurrencyIsEqual(left, right);
            return new Money(left.Value / right.Value, left.Currency);
        }

        public static bool operator ==(Money left, Money right)
        {
            AssertCurrencyIsEqual(left, right);
            return left.Value == right.Value;
        }

        public static bool operator !=(Money left, Money right)
        {
            AssertCurrencyIsEqual(left, right);
            return left.Value != right.Value;
        }

        public static bool operator <(Money left, Money right)
        {
            AssertCurrencyIsEqual(left, right);
            return left.Value < right.Value;
        }

        public static bool operator >(Money left, Money right)
        {
            AssertCurrencyIsEqual(left, right);
            return left.Value > right.Value;
        }

        //public static implicit operator double(Money m)
        //{
        //    //implizit convert Money to double
        //    // Careful: We are loosing data...
        //    return m.Value;
        //}

        public static explicit operator double(Money m)
        {
            // explizit convert Money to double
            // Careful: We are loosing data...
            return m.Value;
        }

        #endregion

        private static void AssertCurrencyIsEqual(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Die beiden Money-Objekte haben nicht die selbe Währung.");
        }

        public override string ToString()
        {
            return String.Format("{0:F2} {1}", Round(Value), Currency.ToString());
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() == typeof(Money))
            {
                if ((obj as Money).Currency == Currency && (obj as Money).Value == Value)
                    return true;
            }
            return false;
        }

        private static double Round(double value)
        {
            //Kaufmännisches Runden auf 2 Nachkommastellen
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

    }

    public enum Currency
    {
        Franken,
        Euro,
        Dollar
    }
}
