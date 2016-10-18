namespace TesterApplication.Forms
{
    partial class Databases
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
            this.btnMongo = new TesterApplication.Forms.FancyButton();
            this.SuspendLayout();
            // 
            // btnMongo
            // 
            this.btnMongo.BackColor = System.Drawing.Color.White;
            this.btnMongo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMongo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMongo.ForeColor = System.Drawing.Color.Black;
            this.btnMongo.Location = new System.Drawing.Point(116, 145);
            this.btnMongo.Name = "btnMongo";
            this.btnMongo.Size = new System.Drawing.Size(75, 23);
            this.btnMongo.TabIndex = 0;
            this.btnMongo.Text = "fancyButton1";
            this.btnMongo.UseVisualStyleBackColor = false;
            // 
            // Databases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnMongo);
            this.Name = "Databases";
            this.Size = new System.Drawing.Size(954, 410);
            this.ResumeLayout(false);

        }

        #endregion

        private FancyButton btnMongo;
    }
}
