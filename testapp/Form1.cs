using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testapp.Service1;

namespace testapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service1Client loClient = new Service1Client();
            string pesel = textBox1.Text.Trim()
                .Replace(" ", "")
                .Replace("-", "");
            label1.Text = loClient.check(pesel).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Service1Client loClient2 = new Service1Client();
            string konto = textBox2.Text.Trim()
                .Replace(" ", "")
                .Replace("-", "");
            label4.Text = loClient2.check_konto(konto).ToString();
        }
    }
}
