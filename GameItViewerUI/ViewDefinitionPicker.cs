using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameItViewerUI
{
    public partial class ViewDefinitionPicker : Form
    {
        public ViewDefinitionPicker()
        {
            InitializeComponent();

            lstViewDefinitions.Items.Add("Underwriting - Team 1");
            lstViewDefinitions.Items.Add("Underwriting - Team 2");
            lstViewDefinitions.Items.Add("AE - Team 1");
            lstViewDefinitions.Items.Add("AE - Team 2");

            lstViewDefinitions_SelectedIndexChanged(null, null);

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            txtSelectedValue.Text = string.Empty;
            this.Close();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            txtSelectedValue.Text = lstViewDefinitions.SelectedItem.ToString();
            this.Close();
        }

        private void lstViewDefinitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdSelect.Enabled = (lstViewDefinitions != null && lstViewDefinitions.SelectedIndex >= 0);            
        }
    }
}
