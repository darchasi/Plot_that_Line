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
            var form = new Form1();

            CryptoDataReader reader = new CryptoDataReader();
            form.allCryptoData = reader.LoadData();

            form.Fantom.Checked = true;
            form.Celsius.Checked = false;
            form.BitTorrent.Checked = false;

            DateTime startDate = new DateTime(2021, 01, 01);
            DateTime endDate = new DateTime(2022, 01, 01);

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
        public void checkBox2_CheckedYear()
        {
            // Arrange
            var form = new Form1();
            form.LastYear.Checked = false;

            CryptoDataReader reader = new CryptoDataReader();
            form.allCryptoData = reader.LoadData();

            // Act
            var finalDate = form.allCryptoData.Max(d => d.Date.Max());
            DateTime OneYearAgo = form.allCryptoData.Max(d => d.Date.Max()).AddYears(-1);

            var yearfinal = finalDate.Year - OneYearAgo.Year;
            
            // Assert
            Assert.AreEqual(1, yearfinal);
        }

        [TestMethod()]
        public void checkBox1_CheckedChangedTest()
        {
            // Arrange
            var form = new Form1();
            form.LastYear.Checked = false;

            CryptoDataReader reader = new CryptoDataReader();
            form.allCryptoData = reader.LoadData();

            // Act
            var finalDate = form.allCryptoData.Max(d => d.Date.Max());
            DateTime OneMonthAgo = form.allCryptoData.Max(d => d.Date.Max()).AddMonths(-1);

            var monthfinal = finalDate.Month - OneMonthAgo.Month;

            // Assert
            Assert.AreEqual(1, monthfinal);
        }

        [TestMethod()]
        public void LastDay_CheckedChangedTest()
        {
            // Arrange
            var form = new Form1();
            form.LastYear.Checked = false;

            CryptoDataReader reader = new CryptoDataReader();
            form.allCryptoData = reader.LoadData();

            // Act
            var finalDate = form.allCryptoData.Max(d => d.Date.Max());
            DateTime OneWeekAgo = form.allCryptoData.Max(d => d.Date.Max()).AddDays(-7);

            var weekfinal = finalDate.Day - OneWeekAgo.Day;

            // Assert
            Assert.AreEqual(7, weekfinal);
        }
    }
}