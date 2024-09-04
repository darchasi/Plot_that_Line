using ScottPlot.WinForms;
using System.Windows.Forms;
using System.Data;
using ScottPlot;


namespace Plot_that_line
{
    public partial class Form1 : Form
    {

        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public int fontSize = 18;
        public float lineWidth = 2.0F;
        DateTime[] dates = Generate.ConsecutiveDays(100);
        double[] ys = Generate.RandomWalk(100);

        //Use ScottPlot to generate arrays of values for plotting
        double[] dataX = { 1, 2, 3, 4, 5 };
        double[] dataY = { 1, 4, 9, 16, 25 };
        double[] dataZ = { 1, 3, 13, 17, 29 };


        public Form1()
        {
            InitializeComponent();
            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            this.Controls.Add(formsPlot1);

            // Evento de carga del Form
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Gráfico inicial
            formsPlot1.Plot.Add.Scatter(dates, ys);
            formsPlot1.Refresh();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var plot1 = formsPlot1.Plot.Add.Scatter(dataX, dataY, markerSize: 0, lineWidth: lineWidth, color: Color.AliceBlue);

            formsPlot1.Plot.Add.Scatter(dates, ys);

            // tell the plot to display dates on the bottom axis
            var d = formsPlot1.Plot.Add.Signal(ys);
            d.Data.XOffset = dates[0].ToOADate();

            // tell the plot to display dates on the bottom axis

            var d2 = formsPlot1.Plot.Add.Signal(ys);
            d2.Data.XOffset = dates[1].ToOADate();
            formsPlot1.Refresh();

            formsPlot1.Plot.Add.Scatter(dates, ys);
            formsPlot1.Refresh();

            //formsPlot1.Plot.Add.Scatter(dataX, dataY);
            //formsPlot1.Refresh();
        }
        private void UpdatePlot()
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime finalDate = dateTimePickerFinal.Value.Date;

            if (startDate > finalDate)
            {
                MessageBox.Show("The start date must be before the finish date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            /*int startIndex = Array.FindIndex(dates, date => date >= startDate);
            int endIndex = Array.FindLastIndex(dates, date => date <= finalDate);

            if (startIndex == -1 || endIndex == -1 || startIndex > endIndex)
            {
                MessageBox.Show("No data available for the selected date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            var filteredDates = dates[startIndex..(endIndex + 1)];
            var filteredYs = ys[startIndex..(endIndex + 1)];


            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Add.Scatter(filteredDates, filteredYs);
            }*/
            formsPlot1.Refresh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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

        private void dateTimePickerFinal_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

/*
 voidPlotListData()

void Reset

file.readonly

 */