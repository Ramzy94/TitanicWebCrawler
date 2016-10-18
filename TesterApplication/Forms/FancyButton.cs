using System.Windows.Forms;

namespace TesterApplication.Forms
{
    class FancyButton:Button
    {
        public FancyButton():base()
        {
            this.FlatStyle = FlatStyle.Flat;
            //.Dock = DockStyle.Fill;
            this.BackColor = System.Drawing.Color.White;
            this.ForeColor = System.Drawing.Color.Black;
            this.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        }
    }
}
