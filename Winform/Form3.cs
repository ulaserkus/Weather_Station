using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitirme_Projesi_Arayüz
{
    public partial class Form3 : Form
    {
      
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=USER\LOCAL;Initial Catalog=Weather;Integrated Security=True");

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            label2.Text = (DateTime.Now).ToString();

            
         //(SicaklikDeger, NemDeger, BasincDeger)
                if ((Values.Sıcaklık/100 <= 10) && (Values.Nem/100 <= 10) && (Values.Basınç/100 > 1020))
                {

                    label1.Text = "Kar Riski";
                pictureBox1.Image = Image.FromFile(@"C:\Users\Asus\Desktop\Bitirme Projesi Arayüz\Bitirme Projesi Arayüz\bin\Image\kar.jpeg");



            }

                else if ((Values.Sıcaklık/100 <= 20) && (Values.Nem/100 > 45)&&(1015 <= Values.Basınç/100&&Values.Basınç/100 <= 1020))
                {
                   
                    label1.Text = "Yagmur Riski";
                pictureBox1.Image = Image.FromFile(@"C:\Users\Asus\Desktop\Bitirme Projesi Arayüz\Bitirme Projesi Arayüz\bin\Image\yagmur.png");
            }

                else if ((15 < Values.Sıcaklık/100&&Values.Sıcaklık/100 <= 30) && (10 < Values.Nem/100&&Values.Nem/100 <= 60)
                && (1005 <= Values.Basınç/100&&Values.Basınç/100 < 1015))
                {
            
                   label1.Text = "Normal Hava";


                pictureBox1.Image = Image.FromFile(@"C:\Users\Asus\Desktop\Bitirme Projesi Arayüz\Bitirme Projesi Arayüz\bin\Image\normal.jpg");


            }
                   
                else if ((Values.Sıcaklık/100 > 25) && (Values.Nem/100 >= 60)
                && (Values.Basınç/100 < 1012))
                {

                    label1.Text = "Sıcak Hava";
                   pictureBox1.Image = Image.FromFile(@"C:\Users\Asus\Desktop\Bitirme Projesi Arayüz\Bitirme Projesi Arayüz\bin\Image\gunes.png");
            }

                else
                {

                    label1.Text = "Ölçüm Hatası";
                }
                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into tbl_weather (Sicaklik,Nem,Basınc,Yukseklik,Ruzgar,Gun,Durum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connection);

            command.Parameters.AddWithValue("@p1", Values.Sıcaklık/100);
            command.Parameters.AddWithValue("@p2", Values.Nem/100);
            command.Parameters.AddWithValue("@p3",Values.Basınç/ 100000);
            command.Parameters.AddWithValue("@p4", Values.Yükseklik/100);
            command.Parameters.AddWithValue("@p5", Values.Rüzgar);
            command.Parameters.AddWithValue("@p6", DateTime.Now);
            command.Parameters.AddWithValue("@p7", label1.Text);

            command.ExecuteNonQuery();

            MessageBox.Show("İşlem Başarılı");

            connection.Close();

        }
    }


}
