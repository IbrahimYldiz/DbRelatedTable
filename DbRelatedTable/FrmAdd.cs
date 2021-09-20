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
    public partial class FrmAdd : Form
    {
        public FrmAdd()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbRelatedTable;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("Select ProductID as 'Ürün Kayıt Numarası',ProductName as 'Ürün Adı',ProductPrice as 'Ürün Fiyatı',ProductStock as 'Ürün Stok Adeti' From TblProduct", connection);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * from TblProduct ", connection);
            DataTable dt1 = new DataTable();

            da.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "ProductName";
            comboBox1.ValueMember = "ProductID";
            
            connection.Close();
            

            connection.Open();
            SqlCommand komut1 = new SqlCommand("Select CustomerID,CustomerNameSurname from TblCustomer", connection);
            DataTable dt2 = new DataTable();

            dt2.Load(komut1.ExecuteReader());
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "CustomerNameSurname";
            comboBox2.ValueMember = "CustomerID";
            
            connection.Close();
            

            connection.Open();



            SqlCommand komut2 = new SqlCommand("Select PersonelID,PersonelNameSurname from TblPersonel", connection);
            DataTable dt3 = new DataTable();

            dt3.Load(komut2.ExecuteReader());


            comboBox3.DataSource = dt3;
            comboBox3.DisplayMember = "PersonelNameSurname";
            comboBox3.ValueMember = "PersonelID";
            
            connection.Close();
            
        }

        void text()
        {
            connection.Close();
            connection.Open();
            SqlCommand command8 = new SqlCommand("Select ProductPrice from TblProduct where ProductID=@p1", connection);

            command8.Parameters.AddWithValue("@p1", deger) ;
            SqlDataReader dr8 = command8.ExecuteReader();
            while (dr8.Read()) 
            { 
                textBox1.Text = dr8[0].ToString();
        }
            
            
            connection.Close();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() != "")
            {
                connection.Open();
                SqlCommand command4 = new SqlCommand("insert into TblMovement (Product,Customer,Personel,Price) values (@p1,@p2,@p3,@p4)", connection);

                command4.Parameters.AddWithValue("@p1", comboBox1.SelectedValue.ToString());
                command4.Parameters.AddWithValue("@p2", comboBox2.SelectedValue.ToString());
                command4.Parameters.AddWithValue("@p3", comboBox3.SelectedValue.ToString());

                command4.Parameters.AddWithValue("@p4", textBox1.Text);
                command4.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                MessageBox.Show ("Ürün Ücretini Hesaplatınız");
            }

        }
        string deger;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            deger = comboBox1.SelectedValue.ToString() ;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            text();
        }
    }
}

