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
            updateListBoxFile();
            drawHistogram();
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
            containerFactory = new ContainerFactory();

            updateComputation();
        }

        private void buttonClearSelected_Click(object sender, EventArgs e)
        {
            ContainerFactoryAbstract newContainerFactory = new ContainerFactory();

            foreach (string filePath in containerFactory.FilePaths)
                if (!ListBoxFile.SelectedItems.Contains(filePath))
                    newContainerFactory.GetContainer(container, filePath);

            containerFactory = newContainerFactory;

            updateComputation();
        }



        private void drawHistogram()
        {
            double minPrice, maxPrice;

            var priceAmounts = container.PriceAmounts;

            minPrice = priceAmounts.Keys.Min();
            maxPrice = priceAmounts.Keys.Max();
        }
    }
}
