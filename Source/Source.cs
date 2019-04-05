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
        public string homepage;
        public Form1()
        {
            if (homepage == null)
            {
                homepage = "google.com";
            }
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
            webTab.Navigate(homepage);
            textBox1.Text = homepage;
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
            webTab.Navigate(homepage);
            textBox1.Text = homepage;
            webTab.DocumentCompleted += WebTab_DocumentCompled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string WebPage = textBox1.Text.Trim();
            //webBrowser1.Navigate(WebPage);
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (textBox1.Text.Contains(".local") || textBox1.Text.Contains(".com") || textBox1.Text.Contains("http://") || textBox1.Text.Contains("https://") || textBox1.Text.Contains("www.") || textBox1.Text.Contains(".net") || textBox1.Text.Contains(".tk") || textBox1.Text.Contains(".org"))
            {
                web.Navigate(textBox1.Text);
            }
            else
            {
                this.DoSearch(textBox1.Text);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
        }
        private void DoSearch(string keywords)

        {

            string googleSearchString = "http://www.google.co.uk/search?hl=en&q=" + keywords + "&meta=";
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            web.Navigate(googleSearchString);

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
                if (textBox1.Text.Contains("."))
                {
                    web.Navigate(textBox1.Text);
                }
                else
                {
                    this.DoSearch(".NET");
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
        }

        private void VojislavButton_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            web.Navigate("Google.com");
        }

        private void YT_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            web.Navigate("youtube.com");
        }

        private void homebut_Click(object sender, EventArgs e)
        {
            homepage = textBox1.Text;
            textBox1.Text = "This page has been set to your home page!";
        }
    }
}
