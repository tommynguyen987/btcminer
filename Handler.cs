using System;

namespace MyUtility
{
    public class Handler
    {   
        public static System.Data.DataTable LoadData()
        {
            DataBase db = new DataBase();
            string strSQLAdded = "SELECT Site,Username as User,Amount,MinPay as Min,LastRun as 'Last Run',Status,Message FROM SiteInfo";
            System.Data.DataTable dt = db.LoadTry(strSQLAdded);

            return dt;
        }

        public static System.Data.DataTable LoadDataByID(string id)
        {
            DataBase db = new DataBase();
            string strSQLAdded = "SELECT * FROM SiteInfo WHERE ID = '" + id + "'";
            System.Data.DataTable dt = db.LoadTry(strSQLAdded);

            return dt;
        }

        public static void AddSite(SiteInfo site)
        {
            DataBase db = new DataBase();                    
            System.Text.StringBuilder sbQuery = new System.Text.StringBuilder();
            sbQuery.Append("INSERT INTO SiteInfo (\"ID\",\"Site\",\"Username\",\"Password\",\"ShowPassword\",\"Email\",\"Minpay\",\"Amount\") ");
            sbQuery.AppendFormat("VALUES ({0}, '{1}', '{2}', '{3}', {4}, '{5}', {6}, 0)", site.ID, site.Site, site.Username, site.Password, site.ShowPassword==true?1:0, site.Email, site.MinPay);
            db.UpdateTry(sbQuery.ToString());
        }            

        public static void RemoveSite(string id)            
        {
            DataBase db = new DataBase();
            string strSQL = "DELETE FROM SiteInfo WHERE ID = '" + id + "'";
            db.UpdateTry(strSQL);
        }

        public static void UpdateSite(SiteInfo site)
        {
            DataBase db = new DataBase();
            System.Text.StringBuilder sbQuery = new System.Text.StringBuilder();
            sbQuery.AppendFormat("UPDATE SiteInfo SET Username='{0}', Password='{1}', ShowPassword={2}, Email='{3}', MinPay={4} WHERE ID={5}", site.Username, site.Password, site.ShowPassword==true?1:0, site.Email, site.MinPay, site.ID);
            db.UpdateTry(sbQuery.ToString());
        }

        public static void UpdateValues(SiteInfo site)
        {
            DataBase db = new DataBase();
            System.Text.StringBuilder sbQuery = new System.Text.StringBuilder();
            sbQuery.AppendFormat("UPDATE SiteInfo SET Amount='{0}', LastRun='{1}', Status={2}, Message='{3}' WHERE ID={5}", site.Amount, site.LastRun,  site.Status, site.Message, site.ID);
            db.UpdateTry(sbQuery.ToString());
        }

        [System.ThreadStatic]
        private static System.Random rnd;
        public static int GetRandomInteger()
        {
            if (rnd == null) rnd = new System.Random((int)System.DateTime.Now.Ticks);
            return System.Math.Abs(System.Convert.ToInt32(rnd.Next(int.MaxValue - 10000) + 10000));            
        }
    }

    public class SiteInfo
    {
        public int ID { get ; set; }
        public string Site { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool ShowPassword { get; set; }
        public string Email { get; set; }
        public long MinPay { get; set; }
        public double Amount { get; set; } 
        public string LastRun { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
