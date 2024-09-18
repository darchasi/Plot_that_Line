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


namespace Plot_that_line
{
    public partial class Form1 : Form
    {

        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public int fontSize = 18;
        public float lineWidth = 2.0F;
        public string filePathFantom = "C:\\Users\\pv20qck\\Desktop\\Plot\\Plot_that_Line\\Info\\Fantom.csv";
        public string filePathCelcius = "C:\\Users\\pv20qck\\Desktop\\Plot\\Plot_that_Line\\Info\\Celsius.csv";
        public string filePathBitTorrent = "C:\\Users\\pv20qck\\Desktop\\Plot\\Plot_that_Line\\Info\\BitTorrent.csv";
        DateTime[] dates = Generate.ConsecutiveDays(100);
        double[] ys = Generate.RandomWalk(100);


        public Form1()
        {
            InitializeComponent();
            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            this.Controls.Add(formsPlot1);

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CryptoDataReader readerFantom = new CryptoDataReader(filePathFantom);
            List<Crypto> dataFantom = readerFantom.LoadData();

            CryptoDataReader readerCelsius = new CryptoDataReader(filePathCelcius);
            List<Crypto> dataCelsius = readerCelsius.LoadData();

            CryptoDataReader readerBitTorrent = new CryptoDataReader(filePathBitTorrent);
            List<Crypto> dataBitTorrent = readerBitTorrent.LoadData();

            DateTime[] datesFantom = dataFantom.Select(d => d.Date).ToArray();
            double[] closeFantom = dataFantom.Select(d => d.Close).ToArray();
            DateTime[] datesCelsius = dataCelsius.Select(d => d.Date).ToArray();
            double[] closeCelsius = dataCelsius.Select(d => d.Close).ToArray();
            DateTime[] datesBitTorren = dataBitTorrent.Select(d => d.Date).ToArray();
            double[] closeBitTorrent = dataBitTorrent.Select(d => d.Close).ToArray();

            var Prices = formsPlot1.Plot.Add.ScatterLine(datesFantom, closeFantom);
            Prices.Color = Colors.Black;
            Prices.LegendText = "Close";
            var Volumes = formsPlot1.Plot.Add.ScatterLine(datesCelsius, closeCelsius);
            Volumes.LegendText = "Celsius";
            Volumes.Color = Colors.Aqua;
            var Low = formsPlot1.Plot.Add.ScatterLine(datesBitTorren, closeBitTorrent);
            Low.Color = Colors.Yellow;
            Low.LegendText = "BitTorrent";

            Currency currencyFantom = dataFantom.First().Currency; 
            Currency currencyCelsius = dataCelsius.First().Currency; 
            Currency currencyBitTorrent = dataBitTorrent.First().Currency; 

   
            formsPlot1.Plot.YLabel(currencyFantom.ToString());
            formsPlot1.Plot.ShowLegend(Edge.Right);
            formsPlot1.Refresh();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void UpdatePlot()
        {
            formsPlot1.Plot.Clear();

            CryptoDataReader readerFantom = new CryptoDataReader(filePathFantom);
            List<Crypto> dataFantom = readerFantom.LoadData();

            CryptoDataReader readerCelcius = new CryptoDataReader(filePathCelcius);
            List<Crypto> dataCelcius = readerCelcius.LoadData();

            CryptoDataReader readerBitTorrent = new CryptoDataReader(filePathBitTorrent);
            List<Crypto> dataBitTorrent = readerBitTorrent.LoadData();

            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime finalDate = dateTimePickerFinal.Value.Date;
            List<DateTime> datesValues = new List<DateTime>();
            datesValues.Add(startDate);
            datesValues.Add(finalDate);

            DateTime[] datesFantom = dataFantom.Select(d => d.Date).ToArray();
            double[] closeFantom = dataFantom.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Close).ToArray();
            DateTime[] datesCelsius = dataCelcius.Select(d => d.Date).ToArray();
            double[] closeCelsius = dataCelcius.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Close).ToArray();
            DateTime[] datesBitTorrent = dataBitTorrent.Select(d => d.Date).ToArray();
            double[] closeBitTorrent = dataBitTorrent.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Close).ToArray();

            if (startDate > finalDate)
            {
                MessageBox.Show("The start date must be before the finish date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filteredDataFantom = dataFantom.Where(d => d.Date >= startDate && d.Date <= finalDate).ToList();

            if (filteredDataFantom.Count == 0)
            {
                MessageBox.Show("No data available for the selected date range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Prices = formsPlot1.Plot.Add.ScatterLine(dates, closeFantom);
            Prices.Color = Colors.Black;
            Prices.LegendText = "Fantom";
            var Volumes = formsPlot1.Plot.Add.ScatterLine(dates, closeCelsius);
            Volumes.Color = Colors.Aqua;
            Volumes.LegendText = "Celcius";
            var Low = formsPlot1.Plot.Add.ScatterLine(dates, closeBitTorrent);
            Low.Color = Colors.Yellow;
            Low.LegendText = "BitTorrent";

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
                MessageBox.Show("The start date have to ve over de finish date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Dates:\n\nStart: {StartDate.ToShortDateString()}\nFin: {FinalDate.ToShortDateString()}",
                            "Chosen dates", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            UpdatePlot();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox2_CheckedChanged.Checked = false;
            //checkBox2_CheckedChanged.Click += ButtonUpdatePlot_Click;

        }
    }
}

/*
void Reset
 */