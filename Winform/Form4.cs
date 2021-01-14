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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=USER\LOCAL;Initial Catalog=Weather;Integrated Security=True");
        private void Form4_Load(object sender, EventArgs e)
        {
            Data();

        }


        public void Data()
        {

            SqlDataAdapter data = new SqlDataAdapter("select * from tbl_weather", connection);
            DataTable DataTable = new DataTable();
            data.Fill(DataTable);
            dataGridView1.DataSource = DataTable;
        }
    }
}
