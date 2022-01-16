using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parallel_async_await
{
    public partial class Form1 : Form
    {

        public int CalculateValue()
        {
            Thread.Sleep(5000);
            return 123;
        }

        public async Task<int> CalculateValueAsync()
        {
            await Task.Delay(5000);
            return 123;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnCalculate_Click(object sender, EventArgs e)
        {
            int value = await CalculateValueAsync();
            LblResult.Text = value.ToString();

            await Task.Delay(5000);

            using (var wc = new WebClient())
            {
                string data = await
                    wc.DownloadStringTaskAsync("http://google.com/robots.txt");
                LblResult.Text = data.Split('\n')[0].Trim();
            }

        }
    }
}
