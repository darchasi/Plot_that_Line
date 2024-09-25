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
        public Crypto(List<DateTime> date, List<float> open, List<float> high, List<float> low, List<float> close, List<float> volume, List<float> currency)
        {
            Date = date; 
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Currency = CurrencyConverter.fromString(currency);
        }

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
    public string sourceDirectory = "..\\..\\..\\..\\..\\Info";

    public List<Crypto> LoadData()
    {
        if (Directory.Exists(sourceDirectory))
        {
            string[] paths = Directory.GetFiles(sourceDirectory);
            foreach (string csv in paths) {
                var data = new List<Crypto>();

                using (FileStream aFile = new FileStream(csv, FileMode.Open))
                using (StreamReader sr = new StreamReader(aFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        DateTime date = DateTime.Parse(values[0]);
                        float open = float.Parse(values[1], CultureInfo.InvariantCulture);
                        float high = float.Parse(values[2], CultureInfo.InvariantCulture);
                        float close = float.Parse(values[3], CultureInfo.InvariantCulture);
                        float low = float.Parse(values[4], CultureInfo.InvariantCulture);
                        float volume = float.Parse(values[5], CultureInfo.InvariantCulture);
                        string currency = values[6];
                    }
                   
                }
                data.Add(new Crypto(date, open, high, low, close, volume, currency));
            }
            return data;
        }
        else
        {
            MessageBox.Show("{0} is not a valid directory.");
        }
    }
}