namespace Price2017
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ListBoxFile = new System.Windows.Forms.ListBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonClearSelected = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartBuy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBuy)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxFile
            // 
            this.ListBoxFile.FormattingEnabled = true;
            this.ListBoxFile.HorizontalScrollbar = true;
            this.ListBoxFile.Location = new System.Drawing.Point(16, 19);
            this.ListBoxFile.Name = "ListBoxFile";
            this.ListBoxFile.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxFile.Size = new System.Drawing.Size(288, 95);
            this.ListBoxFile.TabIndex = 0;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(16, 120);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(92, 42);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(114, 121);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(92, 41);
            this.buttonClearAll.TabIndex = 3;
            this.buttonClearAll.Text = "Удалить всё";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonClearSelected
            // 
            this.buttonClearSelected.Location = new System.Drawing.Point(212, 121);
            this.buttonClearSelected.Name = "buttonClearSelected";
            this.buttonClearSelected.Size = new System.Drawing.Size(92, 41);
            this.buttonClearSelected.TabIndex = 4;
            this.buttonClearSelected.Text = "Удалить выделенное";
            this.buttonClearSelected.UseVisualStyleBackColor = true;
            this.buttonClearSelected.Click += new System.EventHandler(this.buttonClearSelected_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Multiselect = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListBoxFile);
            this.groupBox1.Controls.Add(this.buttonClearSelected);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Controls.Add(this.buttonClearAll);
            this.groupBox1.Location = new System.Drawing.Point(44, 458);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 179);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Загруженные файлы";
            // 
            // chartBuy
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBuy.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBuy.Legends.Add(legend1);
            this.chartBuy.Location = new System.Drawing.Point(1, 0);
            this.chartBuy.Name = "chartBuy";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBuy.Series.Add(series1);
            this.chartBuy.Size = new System.Drawing.Size(1090, 452);
            this.chartBuy.TabIndex = 6;
            this.chartBuy.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 643);
            this.Controls.Add(this.chartBuy);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Price2017";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBuy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxFile;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonClearSelected;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBuy;
    }
}

