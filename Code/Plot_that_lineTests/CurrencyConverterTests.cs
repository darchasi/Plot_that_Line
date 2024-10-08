using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class CurrencyConverterTests
    {
        [TestMethod()]
        public void fromStringTest()
        {
            // Arrange
            var validCurrencyUSD = "USD";
            var validCurrencyEUR = "EUR";
            var validCurrencyGBP = "GBP";

            // Act
            var resultUSD = CurrencyConverter.fromString(validCurrencyUSD);
            var resultEUR = CurrencyConverter.fromString(validCurrencyEUR);
            var resultGBP = CurrencyConverter.fromString(validCurrencyGBP);

            // Assert
            Assert.AreEqual(Currency.USD, resultUSD);
            Assert.AreEqual(Currency.EUR, resultEUR);
            Assert.AreEqual(Currency.GBP, resultGBP);
        }
    }
}