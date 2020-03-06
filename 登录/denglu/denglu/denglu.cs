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

namespace denglu
{
    public partial class denglu : Form
    {
        public denglu()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            zhuche obj = new zhuche();
            obj.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtuid.Text) ||
                String.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("请输入登录名和密码！！！", "系统提示...");
                return;
            }
            else
            {
                string uid = txtuid.Text;
                string password = txtpassword.Text;
                if (asdhja(uid, password) == true)
                {
                    QQ.jiemian oa = new QQ.jiemian();
                    oa.asfd = uid;



                    oa.Show();
                    this.Opacity = 0;
                }
                else
                {
                    MessageBox.Show("登录名和密码不正确！！！", "系统提示...");
                }
            }
        }

        private bool asdhja(string uid, string password)
        {
            SqlConnection con = null;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select count(1) from denglu");
                sb.AppendFormat("where uid = '{0}' and password = '{1}'", txtuid.Text, txtpassword.Text);


                con = new SqlConnection(DB.str);
                SqlCommand cmd = new SqlCommand(sb.ToString(), con);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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
