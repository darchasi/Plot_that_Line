using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plot_that_line;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot_that_line.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            // Arrange
            Form1 form;

            // Act
            form = new Form1();

            // Assert
            Assert.IsNotNull(form, "Form1 instance should be created.");
        }

        [TestMethod()]
        public void UpdatePlotTest()
        {
            // Arrange
            var form = new Form1
            {
                allCryptoData = new List<Crypto>
        {
            new Crypto("Fantom",
                new List<DateTime> { DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-4) },
                new List<float> { 1.1f, 1.2f },
                new List<float> { 1.3f, 1.4f },
                new List<float> { 1.0f, 1.1f },
                new List<float> { 1.2f, 1.3f },
                new List<float> { 1000, 1100 },
                new List<string> { "USD", "USD" })
        }
            };

            form.Fantom.Checked = true;
            form.Celsius.Checked = false;
            form.BitTorrent.Checked = false;

            DateTime startDate = DateTime.Now.AddDays(-6);
            DateTime endDate = DateTime.Now;

            // Act
            form.UpdatePlot(startDate, endDate);

            // Assert
            Assert.AreEqual(1, form.formsPlot1.Plot.GetPlottables().Count(), "Fantom should be plotted once.");
            var scatter = form.formsPlot1.Plot.GetPlottables().First() as ScottPlot.Plottables.Scatter;
            Assert.IsNotNull(scatter, "The plotted item should be a Scatter plot.");
            Assert.AreEqual("Fantom", scatter.LegendText, "The legend text for the plotted item should be 'Fantom'.");
            Assert.AreEqual(Colors.Black, scatter.Color, "The color of the Fantom plot should be black.");
        }

        [TestMethod()]
        public void checkBox2_CheckedChangedTest()
        {
            // Arrange
            var form = new Form1();
            form.LastYear.Checked = false;


            form.allCryptoData = new List<Crypto>
            {
                new Crypto("Fantom",
                new List<DateTime> { DateTime.Now.AddYears(-1), DateTime.Now }, 
                new List<float> { 1.1f, 1.2f }, 
                new List<float> { 1.3f, 1.4f },
                new List<float> { 1.0f, 1.1f },
                new List<float> { 1.2f, 1.3f },
                new List<float> { 1000, 1100 },
                new List<string> { "USD", "USD" })
            };

            
            form.LastYear.Checked = true;
            form.LastMonth.Checked = false; 
            form.LastWeek.Checked = false;

            // Act
            form.checkBox2_CheckedChanged(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(1, form.formsPlot1.Plot.GetPlottables().Count(), "Fantom should be plotted once.");
            var scatter = form.formsPlot1.Plot.GetPlottables().First() as ScottPlot.Plottables.Scatter;
            Assert.IsNotNull(scatter, "The plotted item should be a Scatter plot.");
        }
    }
}