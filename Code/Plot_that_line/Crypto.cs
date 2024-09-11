using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot_that_line
{
    public class Crypto
    {
        public Crypto(DateTime date, double open, double high, double low, double close, double volume, string currency)
        {
            Date = date; 
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Currency = CurrencyConverter.fromString(currency);
        }

        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public Currency Currency { get; set; }
    }
}
public enum Currency
{
    USD
}

static class CurrencyConverter
{
    public static Currency fromString(string currency)
    {
        switch (currency)
        {
            case "USD": return Currency.USD;

            default: return Currency.USD;
        }
    }
}