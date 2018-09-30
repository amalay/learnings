using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amalay.WindowApp
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();

            Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            lblInputText.Text = string.Empty;
            lblInput.Text = string.Empty;
            lblOutputText.Text = string.Empty;
            lblOutput.Text = string.Empty;
        }
    }
}
