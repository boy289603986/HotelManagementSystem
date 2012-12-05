using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new rightClickMenu();   //初始化menu
                menu.Show(button1, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            }
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
                Housingstate state = new Housingstate(this.Name);
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
                //Dispose();
            }
        }


    }
}
