using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace VojaBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }
        private void WebTab_DocumentCompled(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            textBox1.Text = web.Url.AbsoluteUri;
            tabControl1.SelectedTab.Text = webTab.DocumentTitle;
        }
        


        /*private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            textBox1.Text = web.Url.AbsoluteUri;
            tabControl1.SelectedTab.Text = web.DocumentTitle;
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
           
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            web.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New tab";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://vojislav.tk/browser.php");
            textBox1.Text = "https://vojislav.tk/browser.php";
            webTab.DocumentCompleted += WebTab_DocumentCompled;
            /*
            RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            string keyName32 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
            string valueName32 = "VojaBrowser.exe";
            string keyName64 = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
            string valueName64 = "VojaBrowser.exe";
            if (Registry.GetValue(keyName32, valueName32, null) == null)
            {
                key32.SetValue("VojaBrowser.exe", 11001, RegistryValueKind.DWord);
                this.Close();
            }

            if (Registry.GetValue(keyName64, valueName64, null) == null)
            {
                key64.SetValue("VojaBrowser.exe", 11001, RegistryValueKind.DWord);
                this.Close();
            }*/
        }
        WebBrowser webTab = null;
        private void btnNewTab_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New tab";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://vojislav.tk/browser.php");
            textBox1.Text = "https://vojislav.tk/browser.php";
            webTab.DocumentCompleted += WebTab_DocumentCompled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string WebPage = textBox1.Text.Trim();
            //webBrowser1.Navigate(WebPage);
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            web.Navigate(textBox1.Text);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
        }
    }
}
