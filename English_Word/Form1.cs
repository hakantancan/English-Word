using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace English_Word
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int dogruDeger = 0;
        private int yanlisDeger = 0;
        private string correctTurkishWord;
        private string correctEnglishWord;
        private Form4 form4; 


        public Form1()
        {
            InitializeComponent();
            form4 = new Form4(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn1.Click += Button_Click;
            btn2.Click += Button_Click;
            btn3.Click += Button_Click;
            btn4.Click += Button_Click;

            LoadRandomWord();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadRandomWord()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EnglishWord;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TOP 1 EnWord, TrWord FROM dbo.Word ORDER BY NEWID()";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string enWord = reader["EnWord"].ToString();
                        string trWord = reader["TrWord"].ToString();

                        kelime.Text = enWord;
                        correctEnglishWord = enWord;
                        correctTurkishWord = trWord;

                        List<string> turkishWords = new List<string> { trWord };
                        AddRandomTurkishWords(turkishWords);

                        AssignTurkishWordsToButtons(turkishWords);

                        // Her yeni kelime geldiğinde Form4'teki DataGridView'e ekle
                        form4.AddWordToGrid(enWord, trWord, dogruDeger, yanlisDeger);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void AddRandomTurkishWords(List<string> turkishWords)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EnglishWord;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TOP 3 TrWord FROM dbo.Word WHERE TrWord NOT IN (@CorrectAnswer) ORDER BY NEWID();";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CorrectAnswer", turkishWords[0]);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            turkishWords.Add(reader["TrWord"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void AssignTurkishWordsToButtons(List<string> turkishWords)
        {
            turkishWords = turkishWords.OrderBy(x => random.Next()).ToList();

            btn1.Text = turkishWords[0];
            btn2.Text = turkishWords[1];
            btn3.Text = turkishWords[2];
            btn4.Text = turkishWords[3];
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null && clickedButton.Text.Trim().ToLower() == correctTurkishWord.Trim().ToLower())
            {
                dogruDeger++;
            }
            else
            {
                yanlisDeger++;
            }

            LoadRandomWord();
        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            lblSonuc.Text = $"Doğru Cevap Sayısı: {dogruDeger}, Yanlış Cevap Sayısı: {yanlisDeger}";
        }

        private void cevaplarıGor_Click(object sender, EventArgs e)
        {
            form4.ShowDialog();
        }
    }
}
