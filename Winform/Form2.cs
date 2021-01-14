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
        int time=0;

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            chart1.Titles.Add("Sıcaklık-Nem");
            chart2.Titles.Add("Basınç");
            chart3.Titles.Add("Rüzgar Hızı");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var Datetimex = DateTime.Now.Minute;
            var DatetimeS = DateTime.Now.Second;
            time += 1;
            chart1.Series["Sıcaklık"].Points.AddXY(Datetimex, (Values.Sıcaklık/100));

            chart1.Series["Nem"].Points.AddXY(Datetimex, (Values.Nem / 100));

            chart2.Series["Basınç"].Points.AddXY(Datetimex, (Values.Basınç/100 ));

            chart3.Series["Hız"].Points.AddXY(time, Values.Rüzgar);

           
        }
    }
}
