using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form,Interface1
    {
        private MySqlConnection connection;
        private Form2 a;
        private Form3 form3;
        public void sentAnswer(String Msg, int number)
        {
            form3.setMessage(Msg, number);
        }
        public Form1()
        {
            InitializeComponent();
            this.Initialize();
            form3 = new Form3(this);
        }

        public void setAwal()
        {
            form3.setAwal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = new Form2((sender as Button).Text, this);
            this.Hide();
            a.ShowDialog();
        }
        public void Initialize()
        {
            connection = new MySqlConnection("datasource = localhost; port = 3306; username =root ; password =");
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
        public void showform3(Stack<object[]> soal)
        {
            form3.setsoal(soal);
            form3.ShowDialog();
        }
    }
}
