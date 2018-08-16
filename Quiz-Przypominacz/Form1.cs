using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_Przypominacz
{
    public partial class Form1 : Form
    {
        List<TimeSpan> lista = new List<TimeSpan>();

        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // listBox1.Items.Add("10");
            TimeSpan tmp = new TimeSpan(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value));
            lista.Add(tmp);
            lista.Sort();
            listBox1.Items.Clear(); // czyscimy liste zeby nie duplikowalo wynikow
            foreach(var k in lista)
            {
                listBox1.Items.Add(k);
            }
           
        }
    }
}