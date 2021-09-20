using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DbRelatedTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbRelatedTable;Integrated Security=True");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select MovementID as 'Hareket ID',ProductName as 'Ürün Adı',CustomerNameSurname as 'Müşteri Ad Soyad',PersonelNameSurname as 'Personel Ad Soyad',Price   from TblMovement " +
                "INNER JOIN TblProduct on TblProduct.ProductID=TblMovement.Product " +
                "INNER JOIN	TblCustomer on TblCustomer.CustomerID=TblMovement.Customer " +
                "INNER JOIN TblPersonel on TblPersonel.PersonelID=TblMovement.Personel",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAdd fr = new FrmAdd();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select MovementID as 'Hareket ID',ProductName as 'Ürün Adı',CustomerNameSurname as 'Müşteri Ad Soyad',PersonelNameSurname as 'Personel Ad Soyad',Price   from TblMovement " +
                "INNER JOIN TblProduct on TblProduct.ProductID=TblMovement.Product " +
                "INNER JOIN	TblCustomer on TblCustomer.CustomerID=TblMovement.Customer " +
                "INNER JOIN TblPersonel on TblPersonel.PersonelID=TblMovement.Personel", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

        }
    }
}
