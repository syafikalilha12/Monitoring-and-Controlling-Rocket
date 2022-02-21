using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parsingdata
{
    public partial class Form1 : Form
    {
        long max = 100, min = -100;
        long max1 = 110, min1 = -110;
        int c;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            String[] portlist = System.IO.Ports.SerialPort.GetPortNames();
            foreach (String portName in portlist)
                comboBox1.Items.Add(portName);
            comboBox1.Text = comboBox1.Items[comboBox1.Items.Count - 1].ToString();
            comboBox2.Items.Add("9600");
            comboBox2.Items.Add("38400");
            comboBox2.Items.Add("57600");
            comboBox2.Items.Add("115200");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        string RXstring;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String receivedMsg = serialPort1.ReadLine();
            Tampilkan(receivedMsg);
        }
        private void tampil_kata(object sender,EventArgs e)
        {
            
        }
        private delegate void TampilkanDelegate(object item);
        private void Tampilkan(object item)
        {
            if (InvokeRequired)
                listBox1.Invoke(new TampilkanDelegate(Tampilkan), item);
            else
            {
                listBox1.Items.Add(item);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                splitData(item);
            }
        }
        private void splitData(object item)
        {
            String[] data = item.ToString().Split(',');
            textBox5.Text = data[0];
            textBox6.Text = data[1];
            textBox7.Text = data[2];
            textBox8.Text = data[3];
            textBox9.Text = data[4];
            textBox10.Text = data[5];
            textBox11.Text = data[6];
            textBox12.Text = data[7];
            

            chart1.ChartAreas[0].AxisX.Minimum = min;
            chart1.ChartAreas[0].AxisX.Maximum = max;

            chart2.ChartAreas[0].AxisX.Minimum = min1;
            chart2.ChartAreas[0].AxisX.Maximum = max1;

            chart1.ChartAreas[0].AxisY.Minimum = -60000;
            chart1.ChartAreas[0].AxisY.Maximum = 60000;

            chart2.ChartAreas[0].AxisY.Minimum = -60000;
            chart2.ChartAreas[0].AxisY.Maximum = 60000;

            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(min, max);
            serialPort1.Write("1");
            if(data[0]!=null)
            {
                this.chart1.Series[0].Points.AddXY((min + max) / 2, data[0]);
                max++;
                min++;
            }
            if(data[1]!=null)
            {
                this.chart2.Series[0].Points.AddXY((min1 + max1) / 2, data[1]);
                max1++;
                min1++;
            }
            serialPort1.DiscardInBuffer();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            String data = "C";
            serialPort1.WriteLine(data);
            c = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String data = "A";
            serialPort1.WriteLine(data);
            c = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String data = "B";
            serialPort1.WriteLine(data);
            c = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String data = "D";
            serialPort1.WriteLine(data);
            c = 1;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("yakin ingin keluar?","konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                serialPort1.Close();
                timer1.Stop();
                Application.Exit();
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Int32.Parse(comboBox2.Text);
                serialPort1.NewLine = "\r\n";
                serialPort1.Open();
                toolStripStatusLabel1.Text = serialPort1.PortName + "is connected.";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "error:" + ex.Message.ToString();
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            toolStripStatusLabel1.Text = serialPort1.PortName + "is closed.";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String data = "E";
            serialPort1.WriteLine(data);
            c = 1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

    }
}
