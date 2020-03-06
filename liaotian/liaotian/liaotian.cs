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

namespace liaotian
{
    public partial class liaotian : Form
    {
        public string asfd2 { get; set; }

        public liaotian()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void liaotian_Load(object sender, EventArgs e)
        {
            //隐藏
            this.pictureBox11.Visible = false;
            this.pictureBox13.Visible = false;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select top 9 * from xingxi");
            sb.AppendLine(" order by birthday desc");
            SqlDataAdapter sqlData = new SqlDataAdapter(sb.ToString(), denglu.DB.str);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("insert into xingxi(uid,message)");
                sb.AppendFormat(" values ('{0}','{1}')", asfd2,textBox1.Text);


                con = new SqlConnection(denglu.DB.str);
                SqlCommand cmd = new SqlCommand(sb.ToString(), con);
                con.Open();
                cmd.ExecuteNonQuery();
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select top 9 * from xingxi");
            sb.AppendLine("order by birthday desc");
            SqlDataAdapter sqlData = new SqlDataAdapter(sb.ToString(), denglu.DB.str);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        #region 点击X关闭+显示隐藏
        //点击X
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //显示
        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            //显示背景
            this.pictureBox11.Visible = true;
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(215)))), ((int)(((byte)(214)))));
        }
        //离开
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            //隐藏背景
            this.pictureBox11.Visible = false;
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(150)))), ((int)(((byte)(147)))));
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            //显示背景
            this.pictureBox13.Visible = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(215)))), ((int)(((byte)(214)))));
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            //隐藏背景
            this.pictureBox13.Visible = false;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(150)))), ((int)(((byte)(147)))));
        }
        #endregion
        #region 消息框
        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            this.textBox1.BackColor = System.Drawing.Color.White;
            
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(215)))), ((int)(((byte)(214)))));
        }

        #endregion
        //隐藏
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
