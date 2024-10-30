using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_Word
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("EnglishWord", "İngilizce Kelime");
            dataGridView1.Columns.Add("TurkishWord", "türkçe Kelime");
            dataGridView1.Columns.Add("CorrectCount", "Doğru Cevap");
            dataGridView1.Columns.Add("WrongCount", "Yanlış Cevap");
        }

      public void AddWordToGrid(string enWord, string trWord, int correctCount, int wrongCount)
        {
            dataGridView1.Rows.Add(enWord, trWord, correctCount, wrongCount);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
