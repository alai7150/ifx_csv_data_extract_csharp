
namespace IFX_CSV_Data_Extractor
{
    partial class Frm_IFX_CSV
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelRowCount = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonBrowseFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewRaw = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewStatistics = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTestStatistics = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaw)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Extractor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTestStatistics);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelRowCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 374);
            this.panel1.TabIndex = 1;
            // 
            // labelRowCount
            // 
            this.labelRowCount.AutoSize = true;
            this.labelRowCount.Location = new System.Drawing.Point(20, 20);
            this.labelRowCount.Name = "labelRowCount";
            this.labelRowCount.Size = new System.Drawing.Size(116, 18);
            this.labelRowCount.TabIndex = 0;
            this.labelRowCount.Text = "Total rows: ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textBoxFileName);
            this.flowLayoutPanel1.Controls.Add(this.buttonBrowseFile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(786, 38);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxFileName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxFileName.Location = new System.Drawing.Point(3, 3);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(638, 31);
            this.textBoxFileName.TabIndex = 0;
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Location = new System.Drawing.Point(647, 3);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(109, 35);
            this.buttonBrowseFile.TabIndex = 1;
            this.buttonBrowseFile.Text = "Browse";
            this.buttonBrowseFile.UseVisualStyleBackColor = true;
            this.buttonBrowseFile.Click += new System.EventHandler(this.buttonBrowseFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewRaw);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rawdata";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRaw
            // 
            this.dataGridViewRaw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRaw.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRaw.Name = "dataGridViewRaw";
            this.dataGridViewRaw.RowHeadersWidth = 62;
            this.dataGridViewRaw.RowTemplate.Height = 30;
            this.dataGridViewRaw.Size = new System.Drawing.Size(786, 412);
            this.dataGridViewRaw.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewStatistics);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStatistics
            // 
            this.dataGridViewStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStatistics.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStatistics.Name = "dataGridViewStatistics";
            this.dataGridViewStatistics.RowHeadersWidth = 62;
            this.dataGridViewStatistics.RowTemplate.Height = 30;
            this.dataGridViewStatistics.Size = new System.Drawing.Size(792, 418);
            this.dataGridViewStatistics.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "VTH@IG=3.000000E-005A";
            // 
            // labelTestStatistics
            // 
            this.labelTestStatistics.AutoSize = true;
            this.labelTestStatistics.Location = new System.Drawing.Point(26, 104);
            this.labelTestStatistics.Name = "labelTestStatistics";
            this.labelTestStatistics.Size = new System.Drawing.Size(179, 18);
            this.labelTestStatistics.TabIndex = 2;
            this.labelTestStatistics.Text = "Mean, Median, Stdev";
            // 
            // Frm_IFX_CSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_IFX_CSV";
            this.Text = "Frm_IFX_CSV";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_IFX_CSV_FormClosed);
            this.Load += new System.EventHandler(this.Frm_IFX_CSV_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaw)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonBrowseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelRowCount;
        private System.Windows.Forms.DataGridView dataGridViewRaw;
        private System.Windows.Forms.DataGridView dataGridViewStatistics;
        private System.Windows.Forms.Label labelTestStatistics;
        private System.Windows.Forms.Label label1;
    }
}