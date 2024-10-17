using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoxCAD.Backend
{
    public partial class SetPortsDialog : Form
    {
        public static int ServicePort;

        public SetPortsDialog()
        {
            InitializeComponent();
        }

        private void SetPortsDialog_Load(object sender, EventArgs e)
        {
            servicePortInput.Text = ServicePort.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ServicePort = int.Parse(servicePortInput.Text);

            this.Close();
        }

        private void portInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (backspace, delete, etc.) and digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Disallow the character if it's not a digit
                e.Handled = true;
            }
        }
    }
}
