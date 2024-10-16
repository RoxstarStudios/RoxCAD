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
        public static int BackendApiPort;
        public static int BackendWSPort;
        public static int FrontendWebPort;

        public SetPortsDialog()
        {
            InitializeComponent();
        }

        private void SetPortsDialog_Load(object sender, EventArgs e)
        {
            backendApiPortInput.Text = BackendApiPort.ToString();
            backendWSPortInput.Text = BackendWSPort.ToString();
            frontendWebPortInput.Text = FrontendWebPort.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            BackendApiPort = int.Parse(backendApiPortInput.Text);
            BackendWSPort = int.Parse(backendWSPortInput.Text);
            FrontendWebPort = int.Parse(frontendWebPortInput.Text);

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
