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
    public partial class main : Form
    {
        string oldkey;
        static int i = 0;
        static UserControl1[] room = new UserControl1[10];
        static string name;
        public main()
        {
            InitializeComponent();
            string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
            string sql = "select Buserid,Bkey from userid";
            SqlConnection mycon = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(sql, mycon);
            if (mycon.State == ConnectionState.Closed)
                mycon.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                label13.Text = "收银员:" + reader.GetString(0);
                oldkey = reader.GetString(1);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string oldKey = this.textBox4.Text.Trim();
            string newKey = this.textBox6.Text.Trim();
            string checkKey = this.textBox7.Text.Trim();
            string username = "30524";
            if (oldKey.Length > 0 && newKey.Length > 0 && checkKey.Length > 0)
            {
                if (oldKey == oldkey && newKey == checkKey)
                {
                    string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
                    string sql = "update userid set Bkey ='" + newKey + "' where Buserid='" + username + "'";
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
                    MessageBox.Show("原密码错误或两次新密码不符", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请确认已经输入", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1 room = new UserControl1();
            room.Name = i.ToString();
            i++;
            flowLayoutPanel1.Controls.Add(room);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
            string sql = "select Gname,Sintime,Gno,Msum,GID from Gname where Sintime='" + dateTimePicker1.Text.ToString() + "'";
            SqlConnection mycon = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(sql, mycon);
            if (mycon.State == ConnectionState.Closed)
                mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dataGridView2.DataSource = 0;
            if (dr.HasRows)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                this.dataGridView2.DataSource = bs;
                dataGridView2.Columns[0].HeaderCell.Value = "客户姓名";
                dataGridView2.Columns[1].HeaderCell.Value = "预定时间";
                dataGridView2.Columns[2].HeaderCell.Value = "客房号";
                dataGridView2.Columns[3].HeaderCell.Value = "预付金额";
                dataGridView2.Columns[4].HeaderCell.Value = "身份证号";
            }

            mycon.Close();

                        
            //关闭连接并释放资源
            if (ConnectionState.Open == mycon.State)
            {
                mycon.Close();
            }
            mycon.Dispose();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
            string sql = "select Gname,Sintime,Gno,Msum,GID from Gname where Gname='" + textBox5.Text + "'";
            SqlConnection mycon = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(sql, mycon);
            if (mycon.State == ConnectionState.Closed)
                mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dataGridView2.DataSource = 0;
            if (dr.HasRows)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                this.dataGridView2.DataSource = bs;
                dataGridView2.Columns[0].HeaderCell.Value = "客户姓名";
                dataGridView2.Columns[1].HeaderCell.Value = "预定时间";
                dataGridView2.Columns[2].HeaderCell.Value = "客房号";
                dataGridView2.Columns[3].HeaderCell.Value = "预付金额";
                dataGridView2.Columns[4].HeaderCell.Value = "身份证号";
            }

            mycon.Close();


            //关闭连接并释放资源
            if (ConnectionState.Open == mycon.State)
            {
                mycon.Close();
            }
            mycon.Dispose();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
            string sql = "select Cbill,Cstyle,Csum,Ctime,CID,Gno from cash where Ctime='" + dateTimePicker2.Text.ToString() + "'";
            SqlConnection mycon = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(sql, mycon);
            if (mycon.State == ConnectionState.Closed)
                mycon.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dataGridView1.DataSource = 0;
            if (dr.HasRows)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                this.dataGridView1.DataSource = bs;
                dataGridView1.Columns[0].HeaderCell.Value = "账单号";
                dataGridView1.Columns[1].HeaderCell.Value = "消费类型";
                dataGridView1.Columns[2].HeaderCell.Value = "消费金额";
                dataGridView1.Columns[3].HeaderCell.Value = "消费时间";
                dataGridView1.Columns[4].HeaderCell.Value = "收银员";
                dataGridView1.Columns[5].HeaderCell.Value = "客房号";
            }

            mycon.Close();


            //关闭连接并释放资源
            if (ConnectionState.Open == mycon.State)
            {
                mycon.Close();
            }
            mycon.Dispose();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        class rightClickMenu : ContextMenuStrip
        {
            //右键菜单
            public rightClickMenu()
            {
                Items.Add("房态修改");   //添加菜单项1
                Items.Add("预定");   //添加菜单项2
                Items.Add("删除房间");   //添加菜单项3
                Items[0].Click += new EventHandler(stateChange);     //定义菜单项1上的Click事件处理函数
                Items[1].Click += new EventHandler(order);     //定义菜单项2上的Click事件处理函数
                Items[2].Click += new EventHandler(deleteRoom);     //定义菜单项3上的Click事件处理函数
            }
            //房态修改
            private void stateChange(object sender, EventArgs e)
            {
                Housingstate state = new Housingstate(name);
                state.Show();
            }
            //预定
            private void order(object sender, EventArgs e)
            {
                preordain order = new preordain();
                order.Show();
            }

            private void deleteRoom(object sender, EventArgs e)
            {
                Dispose();
            }
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new rightClickMenu();   //初始化menu
                menu.Show(button9, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            }
            name = "301";
        }

        private void button12_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new rightClickMenu();   //初始化menu
                menu.Show(button12, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            }
            name = "302";
        }

        private void button13_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new rightClickMenu();   //初始化menu
                menu.Show(button13, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            }
            name = "303";
        }

        private void button14_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new rightClickMenu();   //初始化menu
                menu.Show(button14, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            }
            name = "304";
        }

        private void button18_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new rightClickMenu();   //初始化menu
                menu.Show(button18, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            }
            name = "305";
        }

        private void button19_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new rightClickMenu();   //初始化menu
                menu.Show(button19, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            }
            name = "401";
        }

        private void button20_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new rightClickMenu();   //初始化menu
                menu.Show(button20, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            }
            name = "402";
        }
    }
}
