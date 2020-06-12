using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace WindowsFormsApplication15
{
    public partial class Form2 : Form
    {
        

        
        public int P;
        private TcpClient client;
        private TcpListener listen;
        private NetworkStream main;

        private readonly Thread listening;
        private readonly Thread gettiming;

        public Form2(int port)
        {
            P = port;
            client = new TcpClient();
            listening = new Thread(start);
            gettiming = new Thread(recieve);



            InitializeComponent();
        }

        private void start()
        {
            while (!client.Connected)
            {
                listen.Start();
                client = listen.AcceptTcpClient();

            }
            gettiming.Start();
        }

        private void stop()
        {
            listen.Stop();
            client = null;
            if (listening.IsAlive)
            {
                listening.Abort();
            }

            if (gettiming.IsAlive)
            {
                gettiming.Abort();

            }

        }

        private void recieve()
        {
            BinaryFormatter bf = new BinaryFormatter();
            while (client.Connected)
            {
                main = client.GetStream();
                pictureBox1.Image = (Image)bf.Deserialize(main);
            }

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            listen = new TcpListener(IPAddress.Any, P);
            listening.Start();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            stop();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
