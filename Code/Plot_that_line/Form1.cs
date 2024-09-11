using ScottPlot.WinForms;
using System.Windows.Forms;
using System.Data;
using ScottPlot;
using System;
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
            FileStream aFile = new FileStream("C:/Users/pv20qck/Desktop/Plot/Plot_that_Line/Info/Fantom.csv", FileMode.Open);
            StreamReader sr = new StreamReader(aFile);

            var data = new List<Crypto>();

            string line;
            while ((line = sr.ReadLine()) != null)
            {

                string[] values = line.Split(',');

                DateTime date = DateTime.Parse(values[0]);
                double open = double.Parse(values[1]);
                double high = double.Parse(values[2]);
                double close = double.Parse(values[3]);
                double low = double.Parse(values[4]);
                double volume = double.Parse(values[5]);
                string currency = values[6];

                data.Add(new Crypto(date, open, high, low, close, volume, currency));
            }
            sr.Close();
            DateTime[] dates = data.Select(d => d.Date).ToArray();
            double[] closePrices = data.Select(d => d.Close).ToArray();

            formsPlot1.Plot.Add.Scatter(dates.Select(d => d.ToOADate()).ToArray(), closePrices);
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
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime finalDate = dateTimePickerFinal.Value.Date;

            DateTime[] dates = startDate.Select(d => d.Date).ToArray();
            double[] closePrices = data.Select(d => d.Close).ToArray();

            if (startDate > finalDate)
            {
                MessageBox.Show("The start date must be before the finish date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
    }
}

/*
 voidPlotListData()

void Reset

file.readonly

 */