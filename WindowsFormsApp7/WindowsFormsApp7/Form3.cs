using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form3 : Form
    {
        
        private Form1 parent;
        Stack<object[]> soal;
        object[] penjelasan =new object[10];
        public Form3(Form1 formparent)
        {
            InitializeComponent();
            parent = formparent;
        }

        public void setsoal(Stack<object[]> soalpr)
        {
            soal = soalpr;
            this.setPenjelasan();
        }

        public void setAwal()
        {
            String Msg = "Kosong";
                label1.Text = Msg; 
                label4.Text = Msg; 
                label3.Text = Msg; 
                label6.Text = Msg; 
                label2.Text = Msg; 
                label5.Text = Msg; 
                label7.Text = Msg; 
                label8.Text = Msg; 
                label9.Text = Msg; 
                label10.Text = Msg;
        }

        public void setMessage(String Msg,int number)
        {
            switch (number)
            {
                case 1: label1.Text = number.ToString() + ". " + Msg; break;
                case 2: label4.Text = number.ToString() + ". " + Msg; break;
                case 3: label3.Text = number.ToString() + ". " + Msg; break;
                case 4: label6.Text = number.ToString() + ". " + Msg; break;
                case 5: label2.Text = number.ToString() + ". " + Msg; break;
                case 6: label5.Text = number.ToString() + ". " + Msg; break;
                case 7: label7.Text = number.ToString() + ". " + Msg; break;
                case 8: label8.Text = number.ToString() + ". " + Msg; break;
                case 9: label9.Text = number.ToString() + ". " + Msg; break;
                case 10: label10.Text = number.ToString() + ". " + Msg; break;
            }
        }

        public void setPenjelasan()
        {
            object[] obj1 = soal.Pop();
            penjelasan[9] = obj1[3].ToString();
            label11.Text = "10. "+obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[8] = obj1[3].ToString();
            label12.Text = "9. "+obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[7] = obj1[3].ToString();
            label13.Text = "8. "+obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[6] = obj1[3].ToString();
            label14.Text = "7. "+obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[5] = obj1[3].ToString();
            label16.Text = "6. "+obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[4] = obj1[3].ToString();
            label19.Text = "5. "+obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[3] = obj1[3].ToString();
            label15.Text = "4. "+obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[2] = obj1[3].ToString();
            label18.Text = "3. " + obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[1] = obj1[3].ToString();
            label17.Text = "2. " + obj1[chek(obj1[2].ToString())].ToString();
            obj1 = soal.Pop();
            penjelasan[0] = obj1[3].ToString();
            label20.Text = "1. "+obj1[chek(obj1[2].ToString())].ToString();
        }

        public int chek(String jawaban)
        {
            switch (jawaban)
            {
                case "a": return 5;
                case "b": return 6;
                case "c": return 7;
                case "d": return 8;
                case "e": return 9;
            }
            return 0;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[0].ToString(), "PENJELASAN");
        }

        private void label17_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[1].ToString(), "PENJELASAN");
        }

        private void label18_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[2].ToString(), "PENJELASAN");
        }

        private void label15_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[3].ToString(), "PENJELASAN");
        }

        private void label19_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[4].ToString(), "PENJELASAN");
        }

        private void label16_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[5].ToString(), "PENJELASAN");
        }

        private void label14_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[6].ToString(), "PENJELASAN");
        }

        private void label13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[7].ToString(), "PENJELASAN");
        }

        private void label12_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[8].ToString(), "PENJELASAN");
        }

        private void label11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(penjelasan[9].ToString(), "PENJELASAN");
        }
    }
}
