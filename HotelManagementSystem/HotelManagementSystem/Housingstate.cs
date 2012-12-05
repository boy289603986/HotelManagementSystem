using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    public partial class Housingstate : Form
    {
        string roomnum;
        public Housingstate()
        {
            InitializeComponent();
        }

        public Housingstate(string strTextBox1Text) 
        { 
            InitializeComponent(); 
            this.textBox1.Text = strTextBox1Text;
            string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
            string sql = "select Gtenant,Gprice,Gdiscount,Gquantity,Gfloor,Gstate from roomstate where Gno ='" + textBox1.Text + "'";
            SqlConnection mycon = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(sql, mycon);
            if (mycon.State == ConnectionState.Closed)
                mycon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        roomnum = textBox1.Text;
                        textBox2.Text = reader.GetString(0);
                        textBox3.Text = reader.GetString(1);
                        textBox4.Text = reader.GetString(2);
                        textBox5.Text = reader.GetString(3);
                        textBox6.Text = reader.GetString(4);
                        textBox7.Text = reader.GetString(5);
                    }
                }
                if (false == reader.IsClosed)// 判断SqlDataReader对象创建的连接是否关闭
                {
                    reader.Close();//关闭SqlDataReader对象的连接
                }
                reader.Dispose();//释放SqlDataReader对象的资源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();//软件异常，退出
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (roomnum == textBox1.Text)
            {
                string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
                string sql = "update roomstate set Gno ='" + textBox1.Text + "',Gtenant ='" + textBox2.Text + "',Gprice ='" + textBox3.Text + "',Gdiscount ='" + textBox4.Text + "',Gquantity ='" + textBox5.Text + "',Gfloor ='" + textBox6.Text + "',Gstate ='" + textBox7.Text + "' where Gno='" + roomnum + "'";
                SqlConnection mycon = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand(sql, mycon);
                if (mycon.State == ConnectionState.Closed)
                    mycon.Open();
                int records = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (records > 0)
                {
                    MessageBox.Show("修改成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.Dispose();
                mycon.Close();
            }
            else
            {
                string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
                string sql = "insert into roomstate(Gno,Gtenant,Gprice,Gdiscount,Gquantity,Gfloor,Gstate) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                SqlConnection mycon = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand(sql, mycon);
                if (mycon.State == ConnectionState.Closed)
                    mycon.Open();
                int records = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (records > 0)
                {
                    MessageBox.Show("添加成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                cmd.Dispose();
                mycon.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
