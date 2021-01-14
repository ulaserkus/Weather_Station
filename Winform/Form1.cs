using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Bitirme_Projesi_Arayüz
{
    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] portsname = SerialPort.GetPortNames();

            foreach(string port in portsname)
            {
                comboBox1.Items.Add(port);
            }
          


        }


       

        private void onbutton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (!serialPort1.IsOpen)
            {
                if (comboBox1.Text == null)
                    return;
                serialPort1.BaudRate = 9600;
                serialPort1.PortName = comboBox1.Text;
            
                try
                {
                    serialPort1.Open();
              
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            


        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {

           
            try
            {
                string data = serialPort1.ReadLine();
              
                string[] values = data.Split('*');
                var rain = int.Parse(values[0]);
                var dirt = int.Parse(values[1]);
                Values.Sıcaklık = float.Parse(values[2]);
                Values.Nem = float.Parse(values[3]);
               Values.Basınç = float.Parse(values[4]);
               Values.Yükseklik = float.Parse(values[5]);
                Values.Rüzgar =(values[6]);
       

                if (rain >= 901)
                {
                    textBox7.Text = "yağmur yok !";
                }
               if (rain > 301 && rain <= 900)
                {
                    textBox7.Text = "yagmur yağıyor !";
                }
                 if (300 > rain)
                {
                    textBox7.Text = "sağanak yağmur !";
                }

                textBox1.Text = (Values.Sıcaklık / 100).ToString();
                textBox2.Text = (Values.Basınç/100000).ToString();
                textBox3.Text = (Values.Nem/100).ToString();
                textBox4.Text = (Values.Yükseklik/100).ToString();
                textBox5.Text = (Values.Rüzgar).ToString();


                if (dirt >= 850)
                {
                    textBox6.Text = "Kuru Toprak!";
                }
                if (dirt > 301 && dirt <= 850)
                {
                    textBox6.Text = "Hafif Nemli Toprak !";
                }
                if (300 > dirt)
                {
                    textBox6.Text = "Yüksek Nemli Toprak !";
                }

                

                serialPort1.DiscardInBuffer();

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
                timer1.Stop();
            }
        }

        private void off_btn_Click(object sender, EventArgs e)
        {



            timer1.Stop();

            if (serialPort1.IsOpen)
            {

                try
                {
                    serialPort1.Close();
            

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void grafiklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void havaDurumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.Show();
        }

        private void kayıtlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form4 = new Form4();
            form4.Show();
        }
    }
}
