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
            this.ListBoxFile = new System.Windows.Forms.ListBox();
            this.LabelLoadedFiles = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonClearSelected = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ListBoxFile
            // 
            this.ListBoxFile.FormattingEnabled = true;
            this.ListBoxFile.HorizontalScrollbar = true;
            this.ListBoxFile.Location = new System.Drawing.Point(12, 37);
            this.ListBoxFile.Name = "ListBoxFile";
            this.ListBoxFile.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxFile.Size = new System.Drawing.Size(288, 95);
            this.ListBoxFile.TabIndex = 0;
            // 
            // LabelLoadedFiles
            // 
            this.LabelLoadedFiles.AutoSize = true;
            this.LabelLoadedFiles.Location = new System.Drawing.Point(9, 12);
            this.LabelLoadedFiles.Name = "LabelLoadedFiles";
            this.LabelLoadedFiles.Size = new System.Drawing.Size(116, 13);
            this.LabelLoadedFiles.TabIndex = 1;
            this.LabelLoadedFiles.Text = "Загруженные файлы:";
            this.LabelLoadedFiles.Click += new System.EventHandler(this.LabelLoadedFiles_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 138);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(92, 42);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(110, 139);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(92, 41);
            this.buttonClearAll.TabIndex = 3;
            this.buttonClearAll.Text = "Удалить всё";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonClearSelected
            // 
            this.buttonClearSelected.Location = new System.Drawing.Point(208, 139);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 336);
            this.Controls.Add(this.buttonClearSelected);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.LabelLoadedFiles);
            this.Controls.Add(this.ListBoxFile);
            this.Name = "Form1";
            this.Text = "Price2017";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxFile;
        private System.Windows.Forms.Label LabelLoadedFiles;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonClearSelected;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

