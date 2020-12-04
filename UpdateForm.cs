using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtility
{
    public partial class UpdateForm : Form
    {
        static string[] Sites = { "http://btcclicks.com", "http://getyourbitco.in" };

        public UpdateForm()
        {
            InitializeComponent();
            cbSites.DataSource = Sites;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            chkShowPassword.Checked = chkShowPassword.Checked;
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SiteInfo site = new SiteInfo();            
            site.Site = cbSites.Text;
            site.Username = txtUsername.Text.Trim();
            site.Password = txtPassword.Text.Trim();
            site.ShowPassword = chkShowPassword.Checked;
            site.Email = txtEmail.Text.Trim();
            site.MinPay =  string.IsNullOrEmpty(txtMinPay.Text.Trim())==true?0:long.Parse(txtMinPay.Text.Trim());            
            if (BTCMiner.isNew)
            {
                site.ID = Handler.GetRandomInteger();
                Handler.AddSite(site);
            }
            else
            {
                Handler.UpdateSite(site);
            }            
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSites_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
