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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Buserid = this.textBox1.Text.Trim();
            string Bkey = this.textBox2.Text.Trim();
            bool result = false;
            if (Buserid.Length > 0)
            {
                if (Bkey.Length > 0)
                {
                    string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
                    string sql = "select Buserid,Bkey from userid";
                    SqlConnection mycon = new SqlConnection(con);
                    SqlCommand cmd = new SqlCommand(sql,mycon);
                    if (mycon.State == ConnectionState.Closed)
                        mycon.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read() && reader.GetString(0) == Buserid && reader.GetString(1) == Bkey)
                            {
                                result = true;
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
                    //关闭连接并释放资源
                    if (ConnectionState.Open == mycon.State)
                    {
                        mycon.Close();
                    }
                    mycon.Dispose();
                    if (result == true)
                    {
                        this.Hide();
                        main interf = new main();
                        interf.Show();
                    }
                    else
                    {
                         MessageBox.Show("账号密码错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("请输入密码！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.textBox2.Focus();
                }
            }
            else
            {
                MessageBox.Show("请输入账号！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
