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
                if (container.IsSingleType())
                {

                    dataGrid.ColumnCount = 3;

                    int priceNumber = priceAmounts.Count;
                    dataGrid.RowCount = priceNumber + 1;

                    dataGrid.Columns[0].HeaderCell.Value = "Покупка";
                    dataGrid.Columns[1].HeaderCell.Value = "Продажа";
                    dataGrid.Columns[2].HeaderCell.Value = "Разница";

                    dataGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    int i = 0;
                    foreach (double price in priceAmounts.Keys)
                    {
                        dataGrid.Rows[priceNumber - i - 1].HeaderCell.Value = price.ToString();
                        PriceAmount priceAmount = priceAmounts[price];

                        var row = dataGrid.Rows[priceNumber - i - 1];

                        row.Cells[0].Value = priceAmount.Buy.ToString("N0", CultureInfo.InvariantCulture);
                        row.Cells[1].Value = priceAmount.Sell.ToString("N0", CultureInfo.InvariantCulture);
                        row.Cells[2].Value = priceAmount.Difference.ToString("N0", CultureInfo.InvariantCulture);

                        row.Cells[0].Style.Font = new Font(dataGrid.Font, FontStyle.Bold);
                        row.Cells[0].Style.ForeColor = Color.Green;

                        row.Cells[1].Style.Font = new Font(dataGrid.Font, FontStyle.Bold);
                        row.Cells[1].Style.ForeColor = Color.Red;

                        row.Cells[2].Style.Font = new Font(dataGrid.Font, FontStyle.Bold);
                        if (priceAmount.Difference >= 0)
                            row.Cells[2].Style.ForeColor = Color.Green;
                        else
                            row.Cells[2].Style.ForeColor = Color.Red;

                        i++;
                    }

                    var totalRow = dataGrid.Rows[dataGrid.Rows.Count - 1];

                    totalRow.HeaderCell.Value = "Всего:";

                    totalRow.Cells[0].Value = priceAmounts.Sum(x => x.Value.Buy).ToString("N0", CultureInfo.InvariantCulture);
                    totalRow.Cells[1].Value = priceAmounts.Sum(x => x.Value.Sell).ToString("N0", CultureInfo.InvariantCulture);

                    double totalDiff = priceAmounts.Sum(x => x.Value.Difference);
                    totalRow.Cells[2].Value = totalDiff.ToString("N0", CultureInfo.InvariantCulture);

                    totalRow.Cells[0].Style.Font = new Font(dataGrid.Font, FontStyle.Bold);
                    totalRow.Cells[0].Style.ForeColor = Color.Green;

                    totalRow.Cells[1].Style.Font = new Font(dataGrid.Font, FontStyle.Bold);
                    totalRow.Cells[1].Style.ForeColor = Color.Red;

                    totalRow.Cells[2].Style.Font = new Font(dataGrid.Font, FontStyle.Bold);
                    if (totalDiff >= 0)
                        totalRow.Cells[2].Style.ForeColor = Color.Green;
                    else
                        totalRow.Cells[2].Style.ForeColor = Color.Red;
                }
                else
                    MessageBox.Show("Были загружены данные о разных акциях", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            chartBuy.Series["buy"].Color = Color.Green;

            chartBuy.Series.Add("sell");
            chartBuy.Series["sell"].LegendText = "Продажа";
            chartBuy.Series["sell"]["PixelPointWidth"] = "10";
            chartBuy.Series["sell"].Points.Clear();
            chartBuy.Series["sell"].Color = Color.Red;

            chartBuy.Series.Add("diff");
            chartBuy.Series["diff"].LegendText = "Разница";
            chartBuy.Series["diff"]["PixelPointWidth"] = "10";
            chartBuy.Series["diff"].Points.Clear();
            chartBuy.Series["diff"].Color = Color.Blue;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            chartBuy.ChartAreas[0].AxisX.ScaleView.Size = this.trackBar1.Value / 10.0;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ContainerFactoryAbstract newContainerFactory = new ContainerFactory();
            container = new TransactionContainer();

            foreach (string filePath in containerFactory.FilePaths)
                newContainerFactory.GetContainer(container, filePath);

            containerFactory = newContainerFactory;

            updateComputation();
        }
    }
}
