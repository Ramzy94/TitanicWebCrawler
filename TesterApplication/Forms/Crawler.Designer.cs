namespace TesterApplication.Forms
{
    partial class Crawler
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnMongo = new TesterApplication.Forms.FancyButton();
            this.btnMetacritic = new TesterApplication.Forms.FancyButton();
            this.btnBillboard = new TesterApplication.Forms.FancyButton();
            this.fancyButton1 = new TesterApplication.Forms.FancyButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(927, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Metacritic",
            "Billboard"});
            this.comboBox1.Location = new System.Drawing.Point(15, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(240, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Select a Website";
            // 
            // btnMongo
            // 
            this.btnMongo.BackColor = System.Drawing.Color.White;
            this.btnMongo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMongo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMongo.ForeColor = System.Drawing.Color.Black;
            this.btnMongo.Location = new System.Drawing.Point(791, 42);
            this.btnMongo.Name = "btnMongo";
            this.btnMongo.Size = new System.Drawing.Size(151, 33);
            this.btnMongo.TabIndex = 5;
            this.btnMongo.Text = "Dump To MongoDB";
            this.btnMongo.UseVisualStyleBackColor = false;
            this.btnMongo.Click += new System.EventHandler(this.btnMongo_Click);
            // 
            // btnMetacritic
            // 
            this.btnMetacritic.BackColor = System.Drawing.Color.White;
            this.btnMetacritic.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMetacritic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMetacritic.ForeColor = System.Drawing.Color.Black;
            this.btnMetacritic.Location = new System.Drawing.Point(415, 42);
            this.btnMetacritic.Name = "btnMetacritic";
            this.btnMetacritic.Size = new System.Drawing.Size(151, 33);
            this.btnMetacritic.TabIndex = 4;
            this.btnMetacritic.Text = "Raw Metacritic Data";
            this.btnMetacritic.UseVisualStyleBackColor = false;
            this.btnMetacritic.Click += new System.EventHandler(this.btnMetacritic_Click);
            // 
            // btnBillboard
            // 
            this.btnBillboard.BackColor = System.Drawing.Color.White;
            this.btnBillboard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBillboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillboard.ForeColor = System.Drawing.Color.Black;
            this.btnBillboard.Location = new System.Drawing.Point(240, 42);
            this.btnBillboard.Name = "btnBillboard";
            this.btnBillboard.Size = new System.Drawing.Size(151, 33);
            this.btnBillboard.TabIndex = 3;
            this.btnBillboard.Text = "Raw Billboard Data";
            this.btnBillboard.UseVisualStyleBackColor = false;
            this.btnBillboard.Click += new System.EventHandler(this.btnBillboard_Click);
            // 
            // fancyButton1
            // 
            this.fancyButton1.BackColor = System.Drawing.Color.White;
            this.fancyButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.fancyButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fancyButton1.ForeColor = System.Drawing.Color.Black;
            this.fancyButton1.Location = new System.Drawing.Point(15, 42);
            this.fancyButton1.Name = "fancyButton1";
            this.fancyButton1.Size = new System.Drawing.Size(151, 33);
            this.fancyButton1.TabIndex = 2;
            this.fancyButton1.Text = "Crawl Site";
            this.fancyButton1.UseVisualStyleBackColor = false;
            this.fancyButton1.Click += new System.EventHandler(this.fancyButton1_Click);
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnMongo);
            this.Controls.Add(this.btnMetacritic);
            this.Controls.Add(this.btnBillboard);
            this.Controls.Add(this.fancyButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Crawler";
            this.Size = new System.Drawing.Size(954, 410);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private FancyButton fancyButton1;
        private FancyButton btnBillboard;
        private FancyButton btnMetacritic;
        private FancyButton btnMongo;
    }
}
