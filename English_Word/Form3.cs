using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace English_Word
{
    public partial class yeniKelime : Form
    {
        public yeniKelime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EnglishWord;Trusted_Connection=True;";

            
            string englishWord = textBox1.Text;
            string turkishWord = textBox2.Text;

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();

                    
                    string query = "INSERT INTO dbo.Word (EnWord, TrWord) VALUES (@EnWord, @TrWord)";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@EnWord", englishWord);
                        command.Parameters.AddWithValue("@TrWord", turkishWord);

                        
                        int result = command.ExecuteNonQuery();

                        
                        if (result > 0)
                        {
                            MessageBox.Show("Kelime başarıyla eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Kelime eklenemedi.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Hatası: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Genel Hata: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EnglishWord;Trusted_Connection=True;";

            
            if (int.TryParse(textBox3.Text, out int id))
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        
                        connection.Open();

                        
                        string query = "DELETE FROM dbo.Word WHERE WordId = @WordId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            
                            command.Parameters.AddWithValue("@WordId", id);

                            
                            int result = command.ExecuteNonQuery();

                            
                            if (result > 0)
                            {
                                MessageBox.Show("Kelime başarıyla silindi.");
                            }
                            else
                            {
                                MessageBox.Show("Silinecek kelime bulunamadı.");
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL Hatası: " + ex.Number + " - " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Genel Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ID girin.");
            }
        }
    }
}


