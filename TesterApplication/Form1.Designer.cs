namespace TesterApplication
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
            this.btn200 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnMetacritic = new System.Windows.Forms.Button();
            this.cmbSites = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn200
            // 
            this.btn200.Location = new System.Drawing.Point(470, 12);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(120, 23);
            this.btn200.TabIndex = 1;
            this.btn200.Text = "Billboard 200";
            this.btn200.UseVisualStyleBackColor = true;
            this.btn200.Click += new System.EventHandler(this.btn200_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1077, 500);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Sites";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnMetacritic
            // 
            this.btnMetacritic.Location = new System.Drawing.Point(969, 12);
            this.btnMetacritic.Name = "btnMetacritic";
            this.btnMetacritic.Size = new System.Drawing.Size(120, 23);
            this.btnMetacritic.TabIndex = 2;
            this.btnMetacritic.Text = "Metacritic";
            this.btnMetacritic.UseVisualStyleBackColor = true;
            this.btnMetacritic.Click += new System.EventHandler(this.btnMetacritic_Click);
            // 
            // cmbSites
            // 
            this.cmbSites.FormattingEnabled = true;
            this.cmbSites.Items.AddRange(new object[] {
            "Metacritic",
            "Billboard"});
            this.cmbSites.Location = new System.Drawing.Point(139, 12);
            this.cmbSites.Name = "cmbSites";
            this.cmbSites.Size = new System.Drawing.Size(121, 21);
            this.cmbSites.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 589);
            this.Controls.Add(this.cmbSites);
            this.Controls.Add(this.btnMetacritic);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn200);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn200;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnMetacritic;
        private System.Windows.Forms.ComboBox cmbSites;
    }
}

