using Plot_that_line;
using System;
using System.Collections.Generic;
using System.Globalization;
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

public class CryptoDataReader
{
    private string _filePath;

    public CryptoDataReader(string filePath)
    {
        _filePath = filePath;
    }


    public List<Crypto> LoadData()
    {
        var data = new List<Crypto>();

        using (FileStream aFile = new FileStream(_filePath, FileMode.Open))
        using (StreamReader sr = new StreamReader(aFile))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(',');

                DateTime date = DateTime.Parse(values[0]);
                double open = double.Parse(values[1], CultureInfo.InvariantCulture);
                double high = double.Parse(values[2], CultureInfo.InvariantCulture);
                double close = double.Parse(values[3], CultureInfo.InvariantCulture);
                double low = double.Parse(values[4], CultureInfo.InvariantCulture);
                double volume = double.Parse(values[5], CultureInfo.InvariantCulture);
                string currency = values[6];

                data.Add(new Crypto(date, open, high, low, close, volume, currency));
            }
        }

        return data;
    }
}