using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Price2017.Backend;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace Price2017
{
    public partial class Form1 : Form
    {
        ContainerFactoryAbstract containerFactory = new ContainerFactory();
        TransactionContainerAbstract container = new TransactionContainer();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void updateListBoxFile()
        {
            ListBoxFile.Items.Clear();

            foreach (string filePath in containerFactory.FilePaths)
                ListBoxFile.Items.Add(filePath);
        }

        private void updateComputation()
        {
            this.Text = "Вычисляется";
            updateListBoxFile();
            updateGrid();
            drawHistogram();
            this.Text = "Price2017";
        }


        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var filePath in openFileDialog.FileNames)
                    containerFactory.GetContainer(container, filePath);

                updateComputation();
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            container = new TransactionContainer();
            containerFactory = new ContainerFactory(); 

            updateComputation();
        }

        private void buttonClearSelected_Click(object sender, EventArgs e)
        {
            ContainerFactoryAbstract newContainerFactory = new ContainerFactory();
            container = new TransactionContainer();

            foreach (string filePath in containerFactory.FilePaths)
                if (!ListBoxFile.SelectedItems.Contains(filePath))
                    newContainerFactory.GetContainer(container, filePath);

            containerFactory = newContainerFactory;

            updateComputation();
        }


        private void updateGrid()
        {
            var priceAmounts = container.PriceAmounts;

            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            if (priceAmounts.Count > 0)
            {
                dataGrid.RowCount = 3;
                dataGrid.ColumnCount = priceAmounts.Count;

                dataGrid.Rows[0].HeaderCell.Value = "Покупка";
                dataGrid.Rows[1].HeaderCell.Value = "Продажа";
                dataGrid.Rows[2].HeaderCell.Value = "Разница";

                dataGrid.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGrid.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGrid.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                int i = 0;
                foreach (double price in priceAmounts.Keys)
                {
                    dataGrid.Columns[i].HeaderCell.Value = price.ToString();
                    PriceAmount priceAmount = priceAmounts[price];

                    dataGrid.Rows[0].Cells[i].Value = priceAmount.Buy.ToString("N", CultureInfo.InvariantCulture);
                    dataGrid.Rows[1].Cells[i].Value = priceAmount.Sell.ToString("N", CultureInfo.InvariantCulture);
                    dataGrid.Rows[2].Cells[i].Value = priceAmount.Difference.ToString("N", CultureInfo.InvariantCulture);

                    i++;
                }
            }
        }

        private void drawHistogram()
        {
            double minPrice, maxPrice;

            var priceAmounts = container.PriceAmounts;

            if (priceAmounts.Count != 0)
            {
                minPrice = priceAmounts.Keys.Min();
                maxPrice = priceAmounts.Keys.Max();
            }

            setChart();
            
            foreach (var x in priceAmounts)
                chartBuy.Series["buy"].Points.AddXY(x.Key, x.Value.Buy);
            
            foreach (var x in priceAmounts)
                chartBuy.Series["sell"].Points.AddXY(x.Key, -x.Value.Sell);
            
            foreach (var x in priceAmounts)
                chartBuy.Series["diff"].Points.AddXY(x.Key, x.Value.Difference);
        }

        protected void setChart()
        {
            chartBuy.Series.Clear();

            var priceAmounts = container.PriceAmounts;

            chartBuy.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartBuy.ChartAreas[0].CursorX.IsUserEnabled = true;

            chartBuy.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartBuy.ChartAreas[0].CursorY.IsUserEnabled = true;

            chartBuy.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chartBuy.ChartAreas[0].AxisX.LabelStyle.Format = "#.##";

            chartBuy.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartBuy.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 0.01;
            chartBuy.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 0.01;
            chartBuy.ChartAreas[0].AxisX.ScaleView.MinSize = 0.01;

            if (priceAmounts.Count != 0)
            {
                chartBuy.ChartAreas[0].AxisX.Minimum = priceAmounts.Keys.Min();
                chartBuy.ChartAreas[0].AxisX.Maximum = priceAmounts.Keys.Max();
            }

            chartBuy.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chartBuy.ChartAreas[0].AxisX.MajorGrid.Interval = 0.1;

            chartBuy.Series.Add("buy");
            chartBuy.Series["buy"].LegendText = "Покупка";
            chartBuy.Series["buy"]["PixelPointWidth"] = "10";
            chartBuy.Series["buy"].Points.Clear();

            chartBuy.Series.Add("sell");
            chartBuy.Series["sell"].LegendText = "Продажа";
            chartBuy.Series["sell"]["PixelPointWidth"] = "10";
            chartBuy.Series["sell"].Points.Clear();

            chartBuy.Series.Add("diff");
            chartBuy.Series["diff"].LegendText = "Разница";
            chartBuy.Series["diff"]["PixelPointWidth"] = "10";
            chartBuy.Series["diff"].Points.Clear();
        }
    }
}
