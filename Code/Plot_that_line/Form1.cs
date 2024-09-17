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
        public string filePath = "C:\\Users\\pv20qck\\Desktop\\Line\\Plot_that_Line\\Info\\Fantom.csv";
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
            CryptoDataReader reader = new CryptoDataReader(filePath);

            List<Crypto> data = reader.LoadData();

            DateTime[] dates = data.Select(d => d.Date).ToArray();
            double[] closePrices = data.Select(d => d.Close).ToArray();
            double[] volumes = data.Select(d => d.Volume).ToArray();
            double[] lows = data.Select(d => d.Low).ToArray();

            double maxVolume = volumes.Max();
            double maxClose = closePrices.Max();
            double maxLow = lows.Max();

            double[] normalizedClosePrices = closePrices.Select(x => x / maxClose).ToArray();
            double[] normalizedVolumes = volumes.Select(x => x / maxVolume).ToArray();
            double[] normalizedLows = lows.Select(x => x / maxLow).ToArray();

            var Prices = formsPlot1.Plot.Add.ScatterLine(dates.Select(d => d.ToOADate()).ToArray(), normalizedClosePrices);
            Prices.Color = Colors.Black;
            var Volumes = formsPlot1.Plot.Add.ScatterLine(dates.Select(d => d.ToOADate()).ToArray(), normalizedVolumes);
            Volumes.Color = Colors.Aqua;
            var Low = formsPlot1.Plot.Add.ScatterLine(dates.Select(d => d.ToOADate()).ToArray(), normalizedLows);
            Low.Color = Colors.Yellow;
            formsPlot1.Refresh();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            formsPlot1.Plot.Add.Scatter(dates, ys);

            var d = formsPlot1.Plot.Add.Signal(ys);
            d.Data.XOffset = dates[0].ToOADate();

            var d2 = formsPlot1.Plot.Add.Signal(ys);
            d2.Data.XOffset = dates[1].ToOADate();
            formsPlot1.Refresh();

            formsPlot1.Plot.Add.Scatter(dates, ys);
            formsPlot1.Refresh();

        }
        private void UpdatePlot()
        {
            formsPlot1.Plot.Clear();
            
            CryptoDataReader reader = new CryptoDataReader(filePath);

            List<Crypto> data = reader.LoadData();

            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime finalDate = dateTimePickerFinal.Value.Date;
            List<DateTime> datesValues = new List<DateTime>();
            datesValues.Add(startDate);
            datesValues.Add(finalDate);

            DateTime[] dates = data.Select(d => d.Date).ToArray();
            double[] closePrices = data.Where(d => d.Date >= startDate && d.Date <= finalDate).Select(d => d.Close).ToArray();

            if (startDate > finalDate)
            {
                MessageBox.Show("The start date must be before the finish date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filteredData = data.Where(d => d.Date >= startDate && d.Date <= finalDate).ToList();

            if (filteredData.Count == 0)
            {
                MessageBox.Show("No data available for the selected date range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            formsPlot1.Plot.Add.Scatter(dates, closePrices);
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
 voidPlotListData()

void Reset

file.readonly

 */