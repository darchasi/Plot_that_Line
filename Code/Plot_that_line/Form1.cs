using ScottPlot.WinForms;
using System.Windows.Forms;
using System.Data;
using ScottPlot;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ScottPlot.Colormaps;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Plot_that_line
{
    public partial class Form1 : Form
    {
        public string filePathFantom = "..\\..\\..\\..\\..\\Info\\Fantom.csv";
        public string filePathCelsius = "..\\..\\..\\..\\..\\Info\\Celsius.csv";
        public string filePathBitTorrent = "..\\..\\..\\..\\..\\Info\\BitTorrent.csv";

        public Form1()
        {
            InitializeComponent();
            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            this.Controls.Add(formsPlot1);
            this.Load += Form1_Load;
            Fantom.Checked=true;
            Celsius.Checked = true;
            BitTorrent.Checked = true;
            formsPlot1.Plot.ShowLegend(Edge.Right);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void UpdatePlot(DateTime? startDate, DateTime? finalDate)
        {
            formsPlot1.Plot.Clear();

            CryptoDataReader readerFantom = new CryptoDataReader(filePathFantom);
            List<Crypto> dataFantom = readerFantom.LoadData();

            CryptoDataReader readerCelsius = new CryptoDataReader(filePathCelsius);
            List<Crypto> dataCelcius = readerCelsius.LoadData();

            CryptoDataReader readerBitTorrent = new CryptoDataReader(filePathBitTorrent);
            List<Crypto> dataBitTorrent = readerBitTorrent.LoadData();

            if (startDate == null || finalDate == null)
            {
                startDate = dataFantom.Min(d => d.Date);
                finalDate = dataFantom.Max(d => d.Date);
            }

            DateTime[] datesFantom = dataFantom.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Date).ToArray();
            double[] closeFantom = dataFantom.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Close).ToArray();

            DateTime[] datesCelsius = dataCelcius.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Date).ToArray();
            double[] closeCelsius = dataCelcius.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Close).ToArray();

            DateTime[] datesBitTorrent = dataBitTorrent.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Date).ToArray();
            double[] closeBitTorrent = dataBitTorrent.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Close).ToArray();

            if (datesFantom.Length == 0 || datesCelsius.Length == 0 || datesBitTorrent.Length == 0)
            {
                MessageBox.Show("No data available for the selected date range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Fantom = formsPlot1.Plot.Add.ScatterLine(datesFantom, closeFantom);
            Fantom.Color = Colors.Black;
            Fantom.LegendText = "Fantom";

            var Celsius = formsPlot1.Plot.Add.ScatterLine(datesCelsius, closeCelsius);
            Celsius.Color = Colors.Aqua;
            Celsius.LegendText = "Celsius";

            var BitTorrent = formsPlot1.Plot.Add.ScatterLine(datesBitTorrent, closeBitTorrent);
            BitTorrent.Color = Colors.Yellow;
            BitTorrent.LegendText = "BitTorrent";

            formsPlot1.Refresh();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerFinal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime StartDate = dateTimePickerStart.Value.Date;
            DateTime FinalDate = dateTimePickerFinal.Value.Date;

            if (StartDate > FinalDate)
            {
                MessageBox.Show("The start date have to be over de finish date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Dates:\n\nStart: {StartDate.ToShortDateString()}\nFin: {FinalDate.ToShortDateString()}",
                            "Chosen dates", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            UpdatePlot(StartDate, FinalDate);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CryptoDataReader readerFantom = new CryptoDataReader(filePathFantom);
            List<Crypto> dataFantom = readerFantom.LoadData();

            DateTime lastDate = dataFantom.Max(d => d.Date);
            DateTime oneYearAgo = lastDate.AddYears(-1);

            if (LastYear.Checked)
            {
                UpdatePlot(oneYearAgo, lastDate);
                LastMonth.Checked = false;
                LastWeek.Checked = false;
            }
            else
            {
                UpdatePlot(null, null);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CryptoDataReader readerFantom = new CryptoDataReader(filePathFantom);
            List<Crypto> dataFantom = readerFantom.LoadData();

            DateTime lastDate = dataFantom.Max(d => d.Date);
            DateTime oneYearAgo = lastDate.AddMonths(-1);

            if (LastMonth.Checked)
            {
                UpdatePlot(oneYearAgo, lastDate);
                LastYear.Checked = false;
                LastWeek.Checked = false;
            }
            else
            {
                UpdatePlot(null, null);
            }
        }

        private void LastDay_CheckedChanged(object sender, EventArgs e)
        {
            CryptoDataReader readerFantom = new CryptoDataReader(filePathFantom);
            List<Crypto> dataFantom = readerFantom.LoadData();

            DateTime lastDate = dataFantom.Max(d => d.Date);
            DateTime oneweekAgo = lastDate.AddDays(-7);

            if (LastWeek.Checked)
            {
                UpdatePlot(oneweekAgo, lastDate);
                LastYear.Checked = false;
                LastMonth.Checked = false;
            }
            else
            {
                UpdatePlot(null, null);
            }
        }

        private void Fantom_CheckedChanged(object sender, EventArgs e)
        {
            if (Fantom.Checked)
            {
                CryptoDataReader readerFantom = new CryptoDataReader(filePathFantom);
                List<Crypto> dataFantom = readerFantom.LoadData();

                DateTime[] datesFantom = dataFantom.Select(d => d.Date).ToArray();
                double[] closeFantom = dataFantom.Select(d => d.Close).ToArray();

                var Fantom = formsPlot1.Plot.Add.ScatterLine(datesFantom, closeFantom);
                Fantom.Color = Colors.Black;
                Fantom.LegendText = "Fantom";

                Currency currencyFantom = dataFantom.First().Currency;

                formsPlot1.Plot.YLabel(currencyFantom.ToString());
            }
            else
            {
                UpdatePlot(null, null);
            }
        }

        private void Celsius_CheckedChanged(object sender, EventArgs e)
        {
            if (Celsius.Checked)
            {
                CryptoDataReader readerCelsius = new CryptoDataReader(filePathCelsius);
                List<Crypto> dataCelsius = readerCelsius.LoadData();

                DateTime[] datesCelsius = dataCelsius.Select(d => d.Date).ToArray();
                double[] closeCelsius = dataCelsius.Select(d => d.Close).ToArray();

                var Celsius = formsPlot1.Plot.Add.ScatterLine(datesCelsius, closeCelsius);
                Celsius.LegendText = "Celsius";
                Celsius.Color = Colors.Aqua;

                Currency currencyCelsius = dataCelsius.First().Currency;

                formsPlot1.Plot.YLabel(currencyCelsius.ToString());
            }
            else
            {
                CryptoDataReader readerCelsius = new CryptoDataReader(filePathCelsius);
                List<Crypto> dataCelsius = readerCelsius.LoadData();

                DateTime[] datesCelsius = dataCelsius.Select(d => d.Date).ToArray();
                double[] closeCelsius = dataCelsius.Select(d => d.Close).ToArray();
                var Celsius = formsPlot1.Plot.Remove.ScatterLine(datesCelsius, closeCelsius);
            }
        }

        private void BitTorrent_CheckedChanged(object sender, EventArgs e)
        {
            if (BitTorrent.Checked)
            {
                CryptoDataReader readerBitTorrent = new CryptoDataReader(filePathBitTorrent);
                List<Crypto> dataBitTorrent = readerBitTorrent.LoadData();

                DateTime[] datesBitTorrent = dataBitTorrent.Select(d => d.Date).ToArray();
                double[] closeBitTorrent = dataBitTorrent.Select(d => d.Close).ToArray();

                var Low = formsPlot1.Plot.Add.ScatterLine(datesBitTorrent, closeBitTorrent);
                Low.Color = Colors.Yellow;
                Low.LegendText = "BitTorrent";

                Currency currencyBitTorrent = dataBitTorrent.First().Currency;

                formsPlot1.Plot.YLabel(currencyBitTorrent.ToString());
            }
            else
            {
                UpdatePlot(null, null);
            }
        }
    }
}

/*
void Reset
 */