using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitirme_Projesi_Arayüz
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            chart1.Titles.Add("Sıcaklık-Nem");
            chart1.Titles.Add("Basınç-Yükseklik");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var Datetimex = DateTime.Now.Minute;

            chart1.Series["Sıcaklık"].Points.AddXY(Datetimex, (Values.Sıcaklık/100));

            chart1.Series["Nem"].Points.AddXY(Datetimex, (Values.Nem / 100));

            chart2.Series["Basınç"].Points.AddXY(Datetimex, (Values.Basınç / 100000));

            chart2.Series["Yükseklik"].Points.AddXY(Datetimex, (Values.Yükseklik / 100));


        }
    }
}
