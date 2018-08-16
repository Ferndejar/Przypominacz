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
        TimeSpan aktualny;
        public Form1()
        {
            InitializeComponent();
            OdswiezListBoxa();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan tmp = new TimeSpan(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value));
            lista.Add(tmp);
            DateTime UTCNow = DateTime.UtcNow;
            int hour = UTCNow.Hour;
            int min = UTCNow.Minute;
            int sec = UTCNow.Second;
            aktualny = new TimeSpan(hour, min, sec);

            // lista.Sort(delegate(TimeSpan c1,TimeSpan c2) { return c1.CompareTo(aktualny); });
            OdswiezListBoxa();
           
        }
        private void OdswiezListBoxa()
        {
            listBox1.Items.Clear();
            foreach (var z in lista)
            {
                listBox1.Items.Add(z); //odswiezamy listboxa
            }
        }

        private void obslugaAlarmu(TimeSpan k)
        {
            MessageBox.Show("Alarm");
            lista.Remove(k);
            OdswiezListBoxa();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime UTCNow = DateTime.UtcNow;
            int hour = UTCNow.Hour;
            int min = UTCNow.Minute;
            int sec = UTCNow.Second;
            aktualny = new TimeSpan(hour, min, sec);
            foreach(var k in lista)
            {
                if(aktualny==k)
                {
                    obslugaAlarmu(k);
                    break;

                }
            }
        }
    }
}