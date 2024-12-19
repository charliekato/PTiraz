using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTiraz
{
    public partial class CustomMessageBox : Form
    {
        private System.Windows.Forms.Timer timer;
        private string messageSave;
        private Boolean messageOn = false;
        public CustomMessageBox(string message, string title)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.Text = title;
            lblMessage.Text = message;
            messageOn = true;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += FlickerMessage;
            timer.Start();
        }

        private void FlickerMessage(object sender, EventArgs e)
        {
            if (messageOn)
            {
                messageSave = lblMessage.Text;
                lblMessage.Text = "";
                messageOn = false;
            } else
            {
                lblMessage.Text = messageSave;
                messageOn = true;

            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static void Show(string message, string title = "Message")
        {
            using (var form = new CustomMessageBox(message, title))
            {
                form.ShowDialog();
            }
        }
    }
}
