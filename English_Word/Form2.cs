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

namespace English_Word
{
    public partial class Kelimeler : Form
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EnglishWord;Integrated Security=True";
        public Kelimeler()
        {
            InitializeComponent();
        }
       
        private void Kelimeler_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM dbo.Word";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}

