namespace TesterApplication.Forms
{
    partial class ViewData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataSelector = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataChart
            // 
            this.dataChart.BackColor = System.Drawing.Color.Transparent;
            this.dataChart.BorderlineWidth = 0;
            this.dataChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea1);
            this.dataChart.Location = new System.Drawing.Point(3, 46);
            this.dataChart.Name = "dataChart";
            this.dataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.dataChart.Size = new System.Drawing.Size(726, 332);
            this.dataChart.TabIndex = 0;
            this.dataChart.Text = "chart1";
            // 
            // dataSelector
            // 
            this.dataSelector.FormattingEnabled = true;
            this.dataSelector.Items.AddRange(new object[] {
            "The Perfct Album",
            "Overrated Albums",
            "Underrated Albums"});
            this.dataSelector.Location = new System.Drawing.Point(24, 19);
            this.dataSelector.Name = "dataSelector";
            this.dataSelector.Size = new System.Drawing.Size(250, 21);
            this.dataSelector.TabIndex = 1;
            this.dataSelector.Text = "Select a Chart to view";
            this.dataSelector.SelectedIndexChanged += new System.EventHandler(this.dataSelector_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(735, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataSelector);
            this.Controls.Add(this.dataChart);
            this.Name = "ViewData";
            this.Size = new System.Drawing.Size(954, 410);
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.ComboBox dataSelector;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Collections.Generic.List<TitanicCrawler.Albums.BillboardAlbum> bill;
    }
}
