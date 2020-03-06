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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string asfd2 { get; set; }

        public Form1()
        {
            InitializeComponent();

            //让多个控件复用同样的响应事件
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from ziliao where uid = '{0}'",asfd2);
            SqlDataAdapter sqlData = new SqlDataAdapter(sb.ToString(), denglu.DB.str);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            textBox1.Text = dt.Rows[0]["uid"].ToString();
            textBox3.Text = dt.Rows[0]["sex"].ToString();
            shenri.Text = dt.Rows[0]["birthday"].ToString();
            textBox2.Text = dt.Rows[0]["blood"].ToString();
            zhiye.Text = dt.Rows[0]["profession"].ToString();
            jiaxian.Text = dt.Rows[0]["home"].ToString();
            shuozaidi.Text = dt.Rows[0]["location"].ToString();
            xuexiao.Text = dt.Rows[0]["school"].ToString();
            gongshi.Text = dt.Rows[0]["company"].ToString();
            shouji.Text = dt.Rows[0]["phone"].ToString();
            youxiang.Text = dt.Rows[0]["mailbox"].ToString();
            gerengqiangming.Text = dt.Rows[0]["signature"].ToString();
            gerenshuoming.Text = dt.Rows[0]["explain"].ToString();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox3.Text != "男" && textBox3.Text != "女")
            {
                MessageBox.Show("性别格式不正确！！(男/女)");
                return;
            }
            if (textBox2.Text !="A" && textBox2.Text != "B" && textBox2.Text != "AB" && textBox2.Text != "O")
            {
                MessageBox.Show("血型格式不正确！！(A/B/AB/O)");
                return;
            }

            SqlConnection con = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("update ziliao set");
                sb.AppendFormat(" sex = '{0}',birthday ='{1}',blood ='{2}',profession='{3}',home='{4}',location='{5}',school ='{6}',company = '{7}',phone = '{8}',mailbox ='{9}',signature ='{10}',explain = '{11}'",
                                 textBox3.Text,shenri.Value,textBox2.Text,zhiye.Text, jiaxian.Text,
                                 shuozaidi.Text, xuexiao.Text, gongshi.Text, shouji.Text, youxiang.Text,
                                 gerengqiangming.Text, gerenshuoming.Text);
                sb.AppendFormat("  where uid = '{0}'", asfd2);
                

                con = new SqlConnection(denglu.DB.str);
                SqlCommand cmd = new SqlCommand(sb.ToString(), con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功");
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
    }
}
