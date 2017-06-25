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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IContainerFactory containerFactory = new ContainerFactory();
            ITransactionContainer container = new TransactionContainer();

            containerFactory.GetContainer(container, @"D:\price-2017\Price2017\Price2017\bin\Debug\1.txt");
            containerFactory.GetContainer(container, @"D:\price-2017\Price2017\Price2017\bin\Debug\2.txt");
        }
    }
}
