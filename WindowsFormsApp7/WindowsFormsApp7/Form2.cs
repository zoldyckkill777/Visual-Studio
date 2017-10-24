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
    public partial class Form2 : Form
    {
        String jurusan;
        String tabel = "", mapel = "";
        Form1 parent;
        MySqlDataReader read;
        MySqlConnection conn;
        MySqlCommand cmd;
        Stack<object[]> [] dataList = new Stack<object[]>[6];
        Stack<object[]> [] databackList = new Stack<object[]>[6];
        int [] number = new int [6];
        object[] soalprint;
        public Form2(String a, Form1 formparent)
        {
            InitializeComponent();
            for (int i = 0; i < dataList.Length; i++)
            {
                dataList[i] = new Stack<object[]>();
                databackList[i] = new Stack<object[]>();
                number[i] = 0;
            }
            jurusan = a;
            this.setTabPage();
            label2.Text = jurusan;
            label4.Text = jurusan;
            label7.Text = jurusan;
            label10.Text = jurusan;
            label13.Text = jurusan;
            label16.Text = jurusan;
            parent = formparent;
            this.getsoal();
            this.soal(true, 0);
            this.soal(true, 1);
            this.soal(true, 2);
            this.soal(true, 3);
            this.soal(true, 4);
            this.soal(true, 5);
        }

        private void setTabPage()
        {
            if (jurusan.Equals("IPS"))
            {
                this.tabPage1.Text = "Ekonomi";
                this.tabPage2.Text = "Bahasa Inggris";
                this.tabPage3.Text = "Geografi";
                this.tabPage4.Text = "Matematika";
                this.tabPage5.Text = "Sosiologi";
                this.tabPage6.Text = "Bahasa Indonesia";
            }
            if (jurusan.Equals("IPA"))
            {
                this.tabPage1.Text = "Bahasa Inggris";
                this.tabPage2.Text = "Biologi";
                this.tabPage3.Text = "Fisika";
                this.tabPage4.Text = "Matematika";
                this.tabPage5.Text = "Kimia";
                this.tabPage6.Text = "Bahasa Indonesia";
            }
        }

        public void getsoal()
        {
            parent.setAwal();
            String query = "select * from "+tabel+" where mapel = '"+mapel+"' order by rand() limit 3";
            if (jurusan.Equals("IPS"))
            {
                tabel = "project_ppk.soal_ips";
                mapel = "bahasa";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 0);
                mapel = "biologi";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 1);
                mapel = "ekonomi";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 2);
                mapel = "geografi";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 3);
                mapel = "matematika";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 4);
                mapel = "sosiologi";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 5);
            }
            else
            {
                tabel = "project_ppk.soal_ipa";
                mapel = "bahasa";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 0);
                mapel = "biologi";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 1);
                mapel = "ekonomi";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 2);
                mapel = "geografi";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 3);
                mapel = "matematika";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 4);
                mapel = "sosiologi";
                this.query("select * from " + tabel + " where mapel = '" + mapel + "' order by rand() limit 10", 5);
            }
        }

        private void query(String query, int index)
        {
            conn = parent.GetConnection();
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                object[] tempRow = new object[read.FieldCount];
                for (int i = 0; i < read.FieldCount; i++)
                {
                    tempRow[i] = read[i];
                }
                dataList[index].Push(tempRow);
            }
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            databackList[0].Push(soalprint);
            parent.showform3(databackList[0]);
            number[0] = 0;
            this.getsoal();
            this.soal(true,0);
        }

        private void chek(int index)
        {
            int max = 10;
            int min = 1;
            switch (index) {
                case 0 :
                          if (number[index] == max)
                            {
                                pictureBox1.Visible = false;
                                button2.Visible = true;
                            }
                          else
                            {
                                pictureBox1.Visible = true;
                                button2.Visible = false;
                            }

                          if (number[index] == min)
                            {
                                pictureBox2.Visible = false;
                            }
                          else
                                pictureBox2.Visible = true;
                    break;
                case 1:
                    if (number[index] == max)
                    {
                        pictureBox4.Visible = false;
                        button1.Visible = true;
                    }
                    else
                    {
                        pictureBox4.Visible = true;
                        button1.Visible = false;
                    }

                    if (number[index] == min)
                    {
                        pictureBox3.Visible = false;
                    }
                    else
                        pictureBox3.Visible = true;
                    break;
                case 2:
                    if (number[index] == max)
                    {
                        pictureBox6.Visible = false;
                        button3.Visible = true;
                    }
                    else
                    {
                        pictureBox6.Visible = true;
                        button3.Visible = false;
                    }

                    if (number[index] == min)
                    {
                        pictureBox5.Visible = false;
                    }
                    else
                        pictureBox5.Visible = true;
                    break;
                case 3:
                    if (number[index] == max)
                    {
                        pictureBox8.Visible = false;
                        button4.Visible = true;
                    }
                    else
                    {
                        pictureBox8.Visible = true;
                        button4.Visible = false;
                    }

                    if (number[index] == min)
                    {
                        pictureBox7.Visible = false;
                    }
                    else
                        pictureBox7.Visible = true;
                    break;
                case 4:
                    if (number[index] == max)
                    {
                        pictureBox10.Visible = false;
                        button5.Visible = true;
                    }
                    else
                    {
                        pictureBox10.Visible = true;
                        button5.Visible = false;
                    }

                    if (number[index] == min)
                    {
                        pictureBox9.Visible = false;
                    }
                    else
                        pictureBox9.Visible = true;
                    break;
                case 5:
                    if (number[index] == max)
                    {
                        pictureBox12.Visible = false;
                        button6.Visible = true;
                    }
                    else
                    {
                        pictureBox12.Visible = true;
                        button6.Visible = false;
                    }

                    if (number[index] == min)
                    {
                        pictureBox11.Visible = false;
                    }
                    else
                        pictureBox11.Visible = true;
                    break;
            }
        }

        private void soal(Boolean arah, int index)
        {
            switch (index)
            {
                case 0:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    break;
                case 1:
                    radioButton6.Checked = false;
                    radioButton7.Checked = false;
                    radioButton8.Checked = false;
                    radioButton9.Checked = false;
                    radioButton10.Checked = false;
                    break;
                case 2:
                    radioButton11.Checked = false;
                    radioButton12.Checked = false;
                    radioButton13.Checked = false;
                    radioButton14.Checked = false;
                    radioButton15.Checked = false;
                    break;
                case 3:
                    radioButton16.Checked = false;
                    radioButton17.Checked = false;
                    radioButton18.Checked = false;
                    radioButton19.Checked = false;
                    radioButton20.Checked = false;
                    break;
                case 4:
                    radioButton21.Checked = false;
                    radioButton22.Checked = false;
                    radioButton23.Checked = false;
                    radioButton24.Checked = false;
                    radioButton25.Checked = false;
                    break;
                case 5:
                    radioButton26.Checked = false;
                    radioButton27.Checked = false;
                    radioButton28.Checked = false;
                    radioButton29.Checked = false;
                    radioButton30.Checked = false;
                    break;
            }
            if (arah)
            {
                number[index]++;
                soalprint = dataList[index].Pop();
            }
            else
            {
                number[index]--;
                soalprint = databackList[index].Pop();
            }
            switch (index)
            {
                case 0:
                    label1.Text = soalprint[1].ToString();
                    radioButton1.Text = soalprint[5].ToString();
                    radioButton2.Text = soalprint[6].ToString();
                    radioButton3.Text = soalprint[7].ToString();
                    radioButton4.Text = soalprint[8].ToString();
                    radioButton5.Text = soalprint[9].ToString();
                    label3.Text = number[0].ToString();
                    chek(index);
                    break;
                case 1:
                    label6.Text = soalprint[1].ToString();
                    radioButton6.Text = soalprint[5].ToString();
                    radioButton7.Text = soalprint[6].ToString();
                    radioButton8.Text = soalprint[7].ToString();
                    radioButton9.Text = soalprint[8].ToString();
                    radioButton10.Text = soalprint[9].ToString();
                    label5.Text = number[1].ToString();
                    chek(index);
                    break;
                case 2:
                    label9.Text = soalprint[1].ToString();
                    radioButton11.Text = soalprint[5].ToString();
                    radioButton12.Text = soalprint[6].ToString();
                    radioButton13.Text = soalprint[7].ToString();
                    radioButton14.Text = soalprint[8].ToString();
                    radioButton15.Text = soalprint[9].ToString();
                    label8.Text = number[2].ToString();
                    chek(index);
                    break;
                case 3:
                    label12.Text = soalprint[1].ToString();
                    radioButton16.Text = soalprint[5].ToString();
                    radioButton17.Text = soalprint[6].ToString();
                    radioButton18.Text = soalprint[7].ToString();
                    radioButton19.Text = soalprint[8].ToString();
                    radioButton20.Text = soalprint[9].ToString();
                    label11.Text = number[3].ToString();
                    chek(index);
                    break;
                case 4:
                    label15.Text = soalprint[1].ToString();
                    radioButton21.Text = soalprint[5].ToString();
                    radioButton22.Text = soalprint[6].ToString();
                    radioButton23.Text = soalprint[7].ToString();
                    radioButton24.Text = soalprint[8].ToString();
                    radioButton25.Text = soalprint[9].ToString();
                    label14.Text = number[4].ToString();
                    chek(index);
                    break;
                case 5:
                    label18.Text = soalprint[1].ToString();
                    radioButton26.Text = soalprint[5].ToString();
                    radioButton27.Text = soalprint[6].ToString();
                    radioButton28.Text = soalprint[7].ToString();
                    radioButton29.Text = soalprint[8].ToString();
                    radioButton30.Text = soalprint[9].ToString();
                    label17.Text = number[5].ToString();
                    chek(index);
                    break;
            }
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            databackList[0].Push(soalprint);
            this.soal(true,0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataList[0].Push(soalprint);
            this.soal(false,0);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton obj = (RadioButton)sender;
            parent.sentAnswer(obj.Text, number[0]);
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton obj = (RadioButton)sender;
            parent.sentAnswer(obj.Text, number[1]);
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton obj = (RadioButton)sender;
            parent.sentAnswer(obj.Text, number[2]);
        }
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton obj = (RadioButton)sender;
            parent.sentAnswer(obj.Text, number[3]);
        }
        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton obj = (RadioButton)sender;
            parent.sentAnswer(obj.Text, number[4]);
        }
        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton obj = (RadioButton)sender;
            parent.sentAnswer(obj.Text, number[5]);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            databackList[1].Push(soalprint);
            this.soal(true, 1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dataList[1].Push(soalprint);
            this.soal(false, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databackList[1].Push(soalprint);
            parent.showform3(databackList[1]);
            number[1] = 0;
            this.getsoal();
            this.soal(true, 1);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            databackList[2].Push(soalprint);
            this.soal(true, 2);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataList[2].Push(soalprint);
            this.soal(false, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            databackList[2].Push(soalprint);
            parent.showform3(databackList[2]);
            number[2] = 0;
            this.getsoal();
            this.soal(true, 2);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            databackList[3].Push(soalprint);
            this.soal(true, 3);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            dataList[3].Push(soalprint);
            this.soal(false, 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            databackList[3].Push(soalprint);
            parent.showform3(databackList[2]);
            number[3] = 0;
            this.getsoal();
            this.soal(true, 3);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            databackList[4].Push(soalprint);
            this.soal(true, 4);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            dataList[4].Push(soalprint);
            this.soal(false, 4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            databackList[4].Push(soalprint);
            parent.showform3(databackList[4]);
            number[4] = 0;
            this.getsoal();
            this.soal(true, 4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            databackList[5].Push(soalprint);
            parent.showform3(databackList[5]);
            number[5] = 0;
            this.getsoal();
            this.soal(true, 5);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            databackList[5].Push(soalprint);
            this.soal(true, 5);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            dataList[5].Push(soalprint);
            this.soal(false, 5);
        }
    }
}
