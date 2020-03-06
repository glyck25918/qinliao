using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QQ
{
    public partial class jiemian : Form
    {
        public string asfd { get; set; }

        public jiemian()
        {
            InitializeComponent();

        }
        //头部
        private void Form1_Load(object sender, EventArgs e)
        {
            this.tabControl1.Visible = false;
            //头部隐藏
            this.pictureBox11.Visible = false;
            this.pictureBox5.Visible = false;
            this.pictureBox13.Visible = false;


            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select * from ziliao");
            sb.AppendFormat("where uid = '{0}'", asfd);
            SqlDataAdapter sqlData = new SqlDataAdapter(sb.ToString(), denglu.DB.str);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            label3.Text = dt.Rows[0]["uid"].ToString();
            label4.Text = dt.Rows[0]["signature"].ToString();

        }

       
        #region 点击隐藏
        //点击消息隐藏联系人
        private void label6_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Visible = true;
            this.pictureBox5.Visible = false;
            //隐藏tabControl1属性
            this.tabControl1.Visible = false;
            //显示
            this.groupBox1.Visible = true;
        }
        //点击联系人显示信息
        private void label7_Click(object sender, EventArgs e)
        {
            this.pictureBox11.Visible = false;
            this.pictureBox5.Visible = true;
            //显示
            this.tabControl1.Visible = true;
            //隐藏groupBox1属性
            this.groupBox1.Visible = false;
        }
        #endregion
        #region 字体颜色变化
        //移动变化颜色
        private void label6_MouseHover(object sender, EventArgs e)
        {
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(150)))), ((int)(((byte)(147)))));
        }
        //离开后的颜色
        private void label6_MouseLeave(object sender, EventArgs e)
        {
            this.label6.ForeColor = System.Drawing.Color.Black;
        }
        //移动变化颜色
        private void label7_MouseHover(object sender, EventArgs e)
        {
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(150)))), ((int)(((byte)(147)))));
        }
        //离开后的颜色
        private void label7_MouseLeave(object sender, EventArgs e)
        {
            this.label7.ForeColor = System.Drawing.Color.Black;
        }
        #endregion

        private void label13_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.Form1 obj = new WindowsFormsApp1.Form1();
            obj.asfd2 = asfd;
            obj.Show();
        }
        //点击头像
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            liaotian.liaotian obj = new liaotian.liaotian();
            obj.Show();
            obj.asfd2 = asfd;
            
        }
        #region 点击X关闭
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.pictureBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(150)))), ((int)(((byte)(147)))));
            //确定是否退出
            DialogResult dr = MessageBox.Show("确定要退出？", "轻聊", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //直接退出
                    Application.Exit();
                }
        }
        #endregion
        //显示
        private void pictureBox12_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox13.Visible = true;
            this.pictureBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(215)))), ((int)(((byte)(214)))));
        }
        //离开
        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox13.Visible = false;
            this.pictureBox12.BackColor = System.Drawing.Color.White;
        }
        //-
        private void label2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox14.Visible = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(215)))), ((int)(((byte)(214)))));
        }
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox14.Visible = false;
            this.label2.BackColor = System.Drawing.Color.White;
        }
    }
}
