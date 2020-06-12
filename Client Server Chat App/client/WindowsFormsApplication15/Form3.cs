using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication15
{
    public partial class Form3 : Form
    {
        private int Ticks;
        public Form3()
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            timer1.Start();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ticks++;
            if (Ticks == 30)
            {
                timer1.Dispose();
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }
    }
}
