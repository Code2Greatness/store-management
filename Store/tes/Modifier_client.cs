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

namespace tes
{
    public partial class Modifier_client : Form
    {
        public Modifier_client()
        {
            InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
        DataSet dts = new DataSet();
        DataView dv = new DataView();
        DataView dv1 = new DataView();

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
        private void pictureBox8_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox7_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter dtp = new SqlDataAdapter("select codecl,nom_client,prenom_client,adresse_client,tel_client,pays_client,ville, email from dbo.Client", co);
                dtp.Fill(dts, "MesClients");
                SqlCommandBuilder BldBq = new SqlCommandBuilder(dtp);
                dtp.Update(dts, "MesClients");

                MessageBox.Show("Enregistrer Effectuée");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void Modifier_client_Load(object sender, EventArgs e)
        {
            dv1.AllowEdit = true;
            SqlDataAdapter dtp = new SqlDataAdapter("select codecl,nom_client,prenom_client,adresse_client,tel_client,pays_client,ville, email from dbo.Client", co);
            dts.Clear();
            dtp.Fill(dts, "MesClients");


            try
            {
                comboBox1.DisplayMember = "codecl";
                comboBox1.ValueMember = "codecl";
                comboBox1.DataSource = dts.Tables["MesClients"];

            

                dv = new DataView(dts.Tables["MesClients"], "", "", DataViewRowState.ModifiedCurrent);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            dv1 = new DataView(dts.Tables["MesClients"], "codecl=" + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
            textBox1.Text = dv1[0].Row["nom_client"].ToString();
            textBox2.Text = dv1[0].Row["prenom_client"].ToString();
            textBox3.Text = dv1[0].Row["tel_client"].ToString();
            textBox4.Text = dv1[0].Row["email"].ToString();
            textBox5.Text = dv1[0].Row["ville"].ToString();
            textBox6.Text = dv1[0].Row["pays_client"].ToString();
            textBox7.Text = dv1[0].Row["adresse_client"].ToString();
           
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                dv1 = new DataView(dts.Tables["MesClients"], "codecl =" + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
                dv1[0].BeginEdit();
                dv1[0]["nom_client"] = textBox1.Text;
                dv1[0]["prenom_client"] = textBox2.Text;
           
                dv1[0].Row["tel_client"] = textBox3.Text ;
                dv1[0].Row["email"] = textBox4.Text;
                dv1[0].Row["ville"] = textBox5.Text;
                dv1[0].Row["pays_client"] = textBox6.Text;
                dv1[0].Row["adresse_client"] = textBox7.Text;
           
                dv1[0].EndEdit();
                MessageBox.Show("Modification Effectuée");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
