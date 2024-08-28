using ScottPlot.WinForms;
using System.Windows.Forms;

namespace Plot_that_line
{
    public partial class Form1 : Form
    {
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public Form1()
        {
            InitializeComponent();
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };

            formsPlot1.Plot.Add.Scatter(dataX, dataY);
            formsPlot1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        
        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

    }
}
