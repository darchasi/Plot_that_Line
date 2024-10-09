using System.Data;
using ScottPlot;


namespace Plot_that_line
{
    public partial class Form1 : Form
    {
        //Get data Cryptos
        public static CryptoDataReader reader = new CryptoDataReader();
        public List<Crypto> allCryptoData = reader.LoadData();


        //Cryptos used
        public static string cryptoNameFantom = "Fantom";
        public static string cryptoNameCelsius = "Celsius";
        public static string cryptoNameBitTorrent = "BitTorrent";

        public Form1()
        {
            InitializeComponent();
            //Plot initiated
            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            this.Controls.Add(formsPlot1);

            //Activation default Cryptos check
            Fantom.Checked=true;
            Celsius.Checked = true;
            BitTorrent.Checked = true;

            //Legend placement
            formsPlot1.Plot.ShowLegend(Edge.Right);

        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        public void UpdatePlot(DateTime? startDate, DateTime? finalDate)
        {
            formsPlot1.Plot.Clear();
            //If no chosen dates, it takes all the dates
            if (startDate == null || finalDate == null)
            {
                startDate = allCryptoData.Min(d => d.Date.Min());
                finalDate = allCryptoData.Max(d => d.Date.Max());
            }
            //if fantom checked it draws it
            if (this.Fantom.Checked) {
                //Get dates range
                DateTime[] datesFantom = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameFantom).SelectMany(c => c.Date).Where(date => date >= startDate && date <= finalDate).ToArray();
                //Get close price of crypto
                float[] closeFantom = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameFantom).SelectMany(crypto => crypto.Close).Where((_, index) => index < datesFantom.Length).ToArray();

                //if chosen data is out range, the user will have an error message 
                if (datesFantom.Length == 0)
                {
                    MessageBox.Show("No data available for the selected date range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Scottplot line design
                ScottPlot.Plottables.Scatter Fantom = formsPlot1.Plot.Add.ScatterLine(datesFantom, closeFantom);
                Fantom.Color = Colors.Black;
                Fantom.LegendText = cryptoNameFantom;
                Currency currencyFantom = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameFantom).Select(c => c.Currency.First()).First();

                formsPlot1.Plot.YLabel(currencyFantom.ToString());

            }
            //if Celsius checked it draws it
            if (this.Celsius.Checked) {
                DateTime[] datesCelsius = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameCelsius).SelectMany(c => c.Date).Where(date => date >= startDate && date <= finalDate).ToArray();
                float[] closeCelsius = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameCelsius).SelectMany(crypto => crypto.Close).Where((_, index) => index < datesCelsius.Length).ToArray();

                if ( datesCelsius.Length == 0)
                {
                    MessageBox.Show("No data available for the selected date range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ScottPlot.Plottables.Scatter Celsius = formsPlot1.Plot.Add.ScatterLine(datesCelsius, closeCelsius);
                Celsius.Color = Colors.Aqua;
                Celsius.LegendText = cryptoNameCelsius;

            }
            //if BitTorrent checked it draws it
            if (this.BitTorrent.Checked)
            {
                DateTime[] datesBitTorrent = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameBitTorrent).SelectMany(c => c.Date).Where(date => date >= startDate && date <= finalDate).ToArray();
                float[] closeBitTorrent = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameBitTorrent).SelectMany(crypto => crypto.Close).Where((_, index) => index < datesBitTorrent.Length).ToArray();

                if ( datesBitTorrent.Length == 0)
                {
                    MessageBox.Show("No data available for the selected date range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ScottPlot.Plottables.Scatter BitTorrent = formsPlot1.Plot.Add.ScatterLine(datesBitTorrent, closeBitTorrent);
                BitTorrent.Color = Colors.Yellow;
                BitTorrent.LegendText = cryptoNameBitTorrent;
            }

            formsPlot1.Refresh();
        }


        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void dateTimePickerFinal_ValueChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            DateTime StartDate = dateTimePickerStart.Value.Date;
            DateTime FinalDate = dateTimePickerFinal.Value.Date;

            //If StartDate isn't bigger than the FinalDat, then it will show an information message
            if (StartDate > FinalDate)
            {
                MessageBox.Show("The start date have to be over de finish date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Dates:\n\nStart: {StartDate.ToShortDateString()}\nEnd: {FinalDate.ToShortDateString()}",
                            "Chosen dates", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            UpdatePlot(StartDate, FinalDate);
        }

        public void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            DateTime lastDate = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameFantom).Max(d => d.Date.Max());
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

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            DateTime lastDate = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameFantom).Max(d => d.Date.Max());
            DateTime oneMonthAgo = lastDate.AddMonths(-1);

            if (LastMonth.Checked)
            {
                UpdatePlot(oneMonthAgo, lastDate);
                LastYear.Checked = false;
                LastWeek.Checked = false;
            }
            else
            {
                UpdatePlot(null, null);
            }
        }

        public void LastDay_CheckedChanged(object sender, EventArgs e)
        {
            DateTime lastDate = allCryptoData.Where(crypto => crypto.CryptoName == cryptoNameFantom).Max(d => d.Date.Max());
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

        public void Fantom_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePlot(null, null);
        }

        public void Celsius_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePlot(null, null);
        }

        private void BitTorrent_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePlot(null, null);
        }
    }
}

//Test remove not functinal
/*Func<IPlottable, bool> lambda = f => f.Axes == Fantom.Axes;
  formsPlot1.Plot.Remove(lambda);*/