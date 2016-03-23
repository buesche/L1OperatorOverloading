using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace L1.Test
{
    [TestClass]
    public class MoneyUnitTests
    {
        [TestMethod]
        [Owner("Fabian")]
        public void Can_Initialize_Empty_Money_Object()
        {
            // Arrange
            // Act
            Money m = new Money();

            // Assert
            Assert.AreEqual(m.Currency, Currency.Franken);
            Assert.AreEqual(m.Value,0);
        }

        [TestMethod]
        [Owner("Fabian")]
        public void Can_Initialize_Money_Object()
        {
            // Arrange
            // Act
            Money m = new Money(10.0, Currency.Dollar);

            // Assert
            Assert.AreEqual(m.Currency, Currency.Dollar);
            // oder anders geschrieben
            Assert.That(m.Currency, Is.EqualTo(Currency.Dollar));

            Assert.AreEqual(m.Value, 10.0);
        }

        [TestMethod]
        [Owner("Fabian")]
        public void Can_Add_Money_and_Money()
        {
            // Arrange
            // Act
            Money m1 = new Money(10.5, Currency.Euro);
            Money m2 = new Money(5.5, Currency.Euro);
            var m3 = m1 + m2;

            // Assert
            Assert.That(m3.Value, Is.EqualTo(16.0));
            Assert.That(m3.Currency, Is.EqualTo(Currency.Euro));
        }

        [TestMethod]
        [Owner("Fabian")]
        public void Can_Add_Money_and_Double()
        {
            // Arrange
            // Act
            Money m = new Money(10.5, Currency.Euro);
            double d = 5.5;

            var m3 = m + d;
            var m4 = d + m;

            // Assert
            Assert.That(m3.Value, Is.EqualTo(16.0));
            Assert.That(m3.Currency, Is.EqualTo(Currency.Euro));

            Assert.That(m4.Value, Is.EqualTo(16.0));
            Assert.That(m4.Currency, Is.EqualTo(Currency.Euro));
        }

        [TestMethod]
        [Owner("Fabian")]
        public void Can_Substract_Money_and_Money()
        {
            // Arrange
            // Act
            Money m1 = new Money(10.5, Currency.Franken);
            Money m2 = new Money(5.5, Currency.Franken);
            var m3 = m1 - m2;

            // Assert
            Assert.That(m3.Value, Is.EqualTo(5.0));
            Assert.That(m3.Currency, Is.EqualTo(Currency.Franken));
        }

        [TestMethod]
        [Owner("Fabian")]
        public void Can_Substract_Money_and_Double()
        {
            // Arrange
            // Act
            Money m = new Money(10.5, Currency.Euro);
            double d = 5.5;

            var m3 = m - d;
            var m4 = d - m;

            // Assert
            Assert.That(m3.Value, Is.EqualTo(5.0));
            Assert.That(m3.Currency, Is.EqualTo(Currency.Euro));

            Assert.That(m4.Value, Is.EqualTo(-5.0));
            Assert.That(m4.Currency, Is.EqualTo(Currency.Euro));
        }

        [TestMethod]
        [Owner("Fabian")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_Dollar_and_Franken_Throws()
        {
            // Arrange
            // Act
            Money m1 = new Money(10.5, Currency.Dollar);
            Money m2 = new Money(10.5, Currency.Franken);

            // Assert
            var m3 = m1 + m2;
            Assert.That(m3, Is.Null);
        }

        [TestMethod]
        [Owner("Fabian")]
        public void Money_with_Same_Currency_and_Value_are_equal()
        {
            // Arrange
            // Act
            Money m1 = new Money();
            Money m2 = new Money();
            Money m3 = new Money(10.0,Currency.Dollar);
            Money m4 = new Money(10.0, Currency.Dollar);
            //// Assert
            Assert.AreEqual(m1, m2);
            Assert.AreEqual(m3, m4);
        }

        [TestMethod]
        [Owner("Fabian")]
        public void Test_that_toString_produces_right_output()
        {
            // Arrange
            // Act
            Money m1 = new Money(10.45, Currency.Franken);
            Money m2 = new Money(9.998, Currency.Dollar);

            // Assert
            Assert.AreEqual("10.45 Franken", m1.ToString());
            Assert.AreEqual("10.00 Dollar", m2.ToString());
        }

        [TestMethod]
        [Owner("Fabian")]
        public void Explicit_Convert_Is_Correct()
        {
            // Arrange
            // Act
            Money m = new Money(10.45, Currency.Franken);
            double d = (double)m;

            // Assert
            Assert.AreEqual(m.Value, d);
        }


    }
}
