using Microsoft.VisualBasic.Logging;
using Plot_that_line;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Plot_that_line 
{


    public class Crypto
    {
        public Crypto(string cryptoName, List<DateTime> date, List<float> open, List<float> high, List<float> low, List<float> close, List<float> volume, List<string> currency)
        {
            CryptoName = cryptoName;
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;

            Currency = currency.Select(CurrencyConverter.fromString).ToList();
        }

        public string CryptoName { get; set; }
        public List<DateTime> Date { get; set; }
        public List<float> Open { get; set; }
        public List<float> High { get; set; }
        public List<float> Low { get; set; }
        public List<float> Close { get; set; }
        public List<float> Volume { get; set; }
        public List<Currency> Currency { get; set; }
    }
}
public enum Currency
{
    USD, // Dolar
    EUR, // Euro
    GBP, // Pound sterling
    JPY, // Yen
    CAD  // Canadian dolars
}

static class CurrencyConverter
{
    public static Currency fromString(string currency)
    {
        switch (currency.ToUpper())
        {
            case "USD": return Currency.USD;
            case "EUR": return Currency.EUR;
            case "GBP": return Currency.GBP;
            case "JPY": return Currency.JPY;
            case "CAD": return Currency.CAD;
            default: throw new ArgumentException($"Unknow currency: {currency}");
        }
    }
}


public class CryptoDataReader
{
    public string sourceDirectory = "..\\..\\..\\..\\..\\Info";

    public List<Crypto> LoadData()
    {
        var data = new List<Crypto>();
        //Check file existence
        if (Directory.Exists(sourceDirectory))
        {
            string[] paths = Directory.GetFiles(sourceDirectory);

            foreach (string csv in paths)
            {
                //File name use to give a name to thr crypto
                string cryptoName = Path.GetFileNameWithoutExtension(csv);

                // List to stock valors in each column
                List<DateTime> dates = new List<DateTime>();
                List<float> opens = new List<float>();
                List<float> highs = new List<float>();
                List<float> lows = new List<float>();
                List<float> closes = new List<float>();
                List<float> volumes = new List<float>();
                List<string> currencies = new List<string>();

                using (FileStream aFile = new FileStream(csv, FileMode.Open))
                using (StreamReader sr = new StreamReader(aFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        // Add valors to the list
                        dates.Add(DateTime.Parse(values[0]));
                        opens.Add(float.Parse(values[1], CultureInfo.InvariantCulture));
                        highs.Add(float.Parse(values[2], CultureInfo.InvariantCulture));
                        closes.Add(float.Parse(values[3], CultureInfo.InvariantCulture));
                        lows.Add(float.Parse(values[4], CultureInfo.InvariantCulture));
                        volumes.Add(float.Parse(values[5], CultureInfo.InvariantCulture));
                        currencies.Add(values[6]);
                    }
                }

                // Create instance and add to "add"
                data.Add(new Crypto(cryptoName, dates, opens, highs, lows, closes, volumes, currencies));
            }
        }
        else
        {
            MessageBox.Show($"{sourceDirectory} is not a valid directory.");
        }

        return data;
    }
}
