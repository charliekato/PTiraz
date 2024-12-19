using Microsoft.Data.SqlClient;
namespace PTiraz
{
    public partial class SelectServer : Form
    {
        public SelectServer()
        {
            InitializeComponent();
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ServerAccessOK(tbxServerName.Text))
            {
                GlobalV.ServerName = tbxServerName.Text;
                SelectEvent.SetServerName(tbxServerName.Text);

                SelectEvent selEventForm = new SelectEvent();
                selEventForm.Show();
            }
            else
            {
                MessageBox.Show("Could not access the server.", "!!ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        static public bool ServerAccessOK(string serverName)
        {
            GlobalV.ServerName = serverName;
            string connectionString = GlobalV.MagicHead + GlobalV.ServerName + GlobalV.MagicWord;
            string sqlQuery = "select * from ëÂâÔê›íË";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static class GlobalV
        {
            public const string MagicWord = "\\SQLEXPRESS;Encrypt=True;TrustServerCertificate=True;";
            public const string MagicHead = "Persist Security Info=False;User ID=Sw;Password=;Initial Catalog=Sw;Server=";
            public static int EventNo;
            public static string ServerName = string.Empty;
        }
    }
}
