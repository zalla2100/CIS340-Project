using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShopEasy.UI
{
    public partial class UserActionsForm : Form
    {
        public UserActionsForm()
        {
            InitializeComponent();
        }

        private void tableViewCmboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = tableViewCmboBx.SelectedIndex;
            var value = tableViewCmboBx.Items[index];
            MessageBox.Show(value.ToString());
        }
    }
}
