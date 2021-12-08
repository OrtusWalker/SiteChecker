using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Size = new Size(ActiveForm.Width, ActiveForm.Height / 7 * 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //print(getResponse(@"https:\\google.com"));
            print(getHtml(@"https:\\google.com"));

        }

        public void print(string text)
        {
            richTextBox1.AppendText(text);
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        static string getHtml(string url)
        {
            var webClient = new System.Net.WebClient();
            webClient.Credentials = new System.Net.NetworkCredential("login", "password");
            return webClient.DownloadString(url);
        }

        static string getResponse(string uri)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            int count = 0;
            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    sb.Append(Encoding.Default.GetString(buf, 0, count));
                }
            }
            while (count > 0);
            return sb.ToString();
        }
    }
}
