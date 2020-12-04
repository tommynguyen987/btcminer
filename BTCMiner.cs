using System;
using System.Data;
using System.Windows.Forms;

namespace MyUtility
{
    public partial class BTCMiner : Form
    {
        const string XinhNguyen = "01685244987";
        const string PhatNguyen = "01632540556";
        const string Password = "pA55WordFormE!@#";
        public static bool isNew = true;
        public static string site;
        static string[] Sites = { "http://btcclicks.com" };

        public BTCMiner()
        {
            InitializeComponent();
            
        }  

        private void LoginRequest()
        {            
            try
            {
                var url = "https://365.vtcpay.vn/dang-nhap";
                WebBrowser wbr = new WebBrowser();
                wbr.ScriptErrorsSuppressed = true;
                wbr.Url = new Uri(url);

                System.Threading.Thread.Sleep(2000);

                wbr.DocumentCompleted += wbr_LoginRequestDocumentCompleted;            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + Environment.NewLine + ex.Message);
            }
        }

        private void wbr_LoginRequestDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wbr = sender as WebBrowser;
            try
            {
                if (wbr.ReadyState == WebBrowserReadyState.Complete)
                {
                    wbr.Document.GetElementById("txtUserName").SetAttribute("value", PhatNguyen);
                    wbr.Document.GetElementById("txtPassWord").SetAttribute("value", Password);
                    wbr.Document.GetElementById("btnLogin").InvokeMember("submit");
                    
                    wbr.DocumentCompleted -= wbr_LoginRequestDocumentCompleted;
                    System.Threading.Thread.Sleep(1000);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + Environment.NewLine + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UpdateForm form = new UpdateForm();
            form.ShowDialog();            
            LoadSites();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isNew = false;
            UpdateForm form = new UpdateForm();
            form.ShowDialog();
            LoadSites();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        // Menu strip
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        // Menu context strip
        private void runSelectedSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        double amount = 0;
        int count = 0, siteCount = 0;
        private void BTCMiner_Load(object sender, EventArgs e)
        {
            siteCount = Handler.LoadData().Rows.Count;
            txtInfo.Text = "  Amount: " + amount + "     Running: " + count + System.Environment.NewLine + "  Total site: " + siteCount;
            LoadSites();
        }

        private void LoadSites()
        {
            DataTable dt = Handler.LoadData();
            grvWebsites.DataSource = dt;            
            grvWebsites.Columns[0].Width = 150;            
            for (int i = 1; i < grvWebsites.Columns.Count; i++)
            {
                grvWebsites.Columns[i].Width = 120;                
            }
            grvWebsites.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;
            grvWebsites.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            //grvWebsites.Sort(grvWebsites.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void grvWebsites_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn[] columns = new[] { grvWebsites.Columns[0], grvWebsites.Columns[1], grvWebsites.Columns[2], grvWebsites.Columns[3], grvWebsites.Columns[4], grvWebsites.Columns[5], grvWebsites.Columns[6] };
            DataGridViewColumnHeaderCell headerCell = grvWebsites.Columns[e.ColumnIndex].HeaderCell;

            if (headerCell.SortGlyphDirection != SortOrder.Ascending)
                headerCell.SortGlyphDirection = SortOrder.Ascending;
            else
                headerCell.SortGlyphDirection = SortOrder.Descending;

            //foreach (DataGridViewColumn c in columns)
            //{
            //    if (grvWebsites.Columns[e.ColumnIndex].HeaderText == c.HeaderText)
            //    {
            //        grvWebsites.Sort(grvWebsites.Columns[e.ColumnIndex], System.ComponentModel.ListSortDirection.Ascending);
            //    }
            //}            
        }       
    }    
}
