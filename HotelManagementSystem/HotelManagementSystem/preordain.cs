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
    public partial class preordain : Form
    {
        public preordain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = "server=Crazyboy-PC;Initial Catalog=master;Integrated Security=SSPI";
            string sql = "insert into Gname(Gno,Gname,Sintime,Msum,GID) values('" + textBox6.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text.ToString() + "','" + textBox3.Text + "','" + textBox4.Text + "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
