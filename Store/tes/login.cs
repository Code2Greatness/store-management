using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace tes
{
    public partial class login : Form
    {
        private Form fremm;
        public login(Form menu)
        {
            InitializeComponent();
            this.fremm = menu;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
           

        private void bunifuCustomLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

     

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (Textbox1.Text == "" && textBox3.Text == "")
                    {
                        MessageBox.Show("Veuillez remplir tous les champs");
                    }
                    else
                    {
                        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
                        SqlCommand cmd = new SqlCommand("select * from Adminn where Name=@name and Pass=@password", co);
                        SqlCommand cmd2 = new SqlCommand("select * from utilisat where Name=@name and Pass=@password", co);
                        cmd.Parameters.AddWithValue("@name", Textbox1.Text);
                        cmd.Parameters.AddWithValue("@password", textBox3.Text);
                        cmd2.Parameters.AddWithValue("@name", Textbox1.Text);
                        cmd2.Parameters.AddWithValue("@password", textBox3.Text);

                        if (radioButton1.Checked == true)
                        {

                            co.Open();
                            SqlDataAdapter dtp = new SqlDataAdapter(cmd);
                            DataSet dts = new DataSet();
                            dtp.Fill(dts);
                            co.Close();

                            int count = dts.Tables[0].Rows.Count;

                            if (count == 1)
                            {
                                MessageBox.Show("connecter");
                                (fremm as Main).activerform();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("invalid password or user name");
                            }
                        }
                        else
                        {
                            if (radioButton2.Checked == true)
                            {
                                co.Open();
                                SqlDataAdapter dtp = new SqlDataAdapter(cmd2);
                                DataSet dts = new DataSet();
                                dtp.Fill(dts);
                                co.Close();

                                int count = dts.Tables[0].Rows.Count;

                                if (count == 1)
                                {
                                    MessageBox.Show("connecter");
                                    (fremm as Main).activerform();
                                }
                                else
                                {
                                    MessageBox.Show("invalid password or user name");
                                }
                            }
                        }



                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("erreur" + err.Message);
                }
            }
        }

       

        private void login_Load(object sender, EventArgs e)
        {
           
            textBox3.UseSystemPasswordChar = true;

        }

        private void Textbox1_TextChanged(object sender, EventArgs e)
        {
            Textbox1.ForeColor = Color.Black;
        }

        private void Textbox2_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = true;
               
            }
            else
            {
                textBox3.UseSystemPasswordChar = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Textbox1_Click(object sender, EventArgs e)
        {
            if (Textbox1.Text == "Username")
            {
                Textbox1.Text = "";
                Textbox1.ForeColor = Color.Black;

            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "Password")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }
    }
}
