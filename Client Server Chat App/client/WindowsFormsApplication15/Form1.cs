using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
//using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace WindowsFormsApplication15
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent(); string hst = Dns.GetHostName(); // Retrive the Name of HOST  

            // Get the IP  
            string myIP = Dns.GetHostByName(hst).AddressList[0].ToString();

            label5.Text = myIP;
            textBox1.Text = myIP;
            textBox2.Text = "90";
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            if (radioButton1.Checked == true)
            {
                new Form2(int.Parse(textBox2.Text)).Show();
            }
            if (radioButton2.Checked == true)
            {
                portno = int.Parse(textBox2.Text);
                try
                {
                    tcp.Connect(textBox1.Text, portno);
                    MessageBox.Show("Connected");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        private readonly TcpClient tcp = new TcpClient();
        private NetworkStream mainstream;
        private int portno;

        private static Image grabdesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screen = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics gra = Graphics.FromImage(screen);
            gra.CopyFromScreen(bounds.X, bounds.Y, 5, 5, bounds.Size, CopyPixelOperation.SourceCopy);
            return screen;

        }

        private void senddesktop()
        {
            BinaryFormatter bf = new BinaryFormatter();
            mainstream = tcp.GetStream();
            bf.Serialize(mainstream, grabdesktop());

        }
       
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button7.Enabled = false;
                textBox1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                button7.Enabled = true;
                textBox1.Enabled = true;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text.StartsWith("S"))
            {
                timer1.Start();
                button7.Text = "stop share";
            }
            else
            {
                timer1.Stop();
                button7.Text = "Share my screen";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            senddesktop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chat c = new Chat();
            c.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
