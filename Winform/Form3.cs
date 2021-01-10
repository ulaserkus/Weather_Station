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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
         //(SicaklikDeger, NemDeger, BasincDeger)
         if ((Values.Sıcaklık <= 5) && (Values.Nem <= 10) && (Values.Basınç > 1020))
                {

                    label1.Text = "Kar Riski";

                }

                else if ((Values.Sıcaklık <= 15) && (Values.Nem > 45)&&(1015 <= Values.Basınç&&Values.Basınç <= 1020))
                {
                   
                    label1.Text = "Yagmur Riski";
                }

                else if ((15 < Values.Sıcaklık&&Values.Sıcaklık <= 30) && (10 < Values.Nem&&Values.Nem <= 45)
                && (1013 <= Values.Basınç&&Values.Basınç < 1015))
                {

                    label1.Text = "Normal Hava";
                }
                   
                else if ((Values.Sıcaklık > 30) && (Values.Nem >= 75)
                && (Values.Basınç < 1012))
                {

                    label1.Text = "Sıcak Hava";
                }

                else
                {

                    label1.Text = "Ölçüm Hatası";
                }
                  
        }
        
  }


}
