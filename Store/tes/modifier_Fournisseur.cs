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
    public partial class modifier_Fournisseur : Form
    {
        public modifier_Fournisseur()
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

        private void modifier_Fournisseur_Load(object sender, EventArgs e)
        {
            dv1.AllowEdit = true;
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.fourniseur", co);
            dts.Clear();
            dtp.Fill(dts, "Mesfournisseur");

            try
            {
                comboBox1.DisplayMember = "codeFr";
                comboBox1.ValueMember = "codeFr";
                comboBox1.DataSource = dts.Tables["Mesfournisseur"];



                dv = new DataView(dts.Tables["Mesfournisseur"], "", "", DataViewRowState.ModifiedCurrent);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.fourniseur", co);
                dtp.Fill(dts, "Mesfournisseur");
                SqlCommandBuilder BldBq = new SqlCommandBuilder(dtp);
                dtp.Update(dts, "Mesfournisseur");

                MessageBox.Show("Enregistrer Effectuée");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            dv1 = new DataView(dts.Tables["Mesfournisseur"], "codeFr=" + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
            textBox1.Text = dv1[0].Row["nom_fournis"].ToString();
            textBox2.Text = dv1[0].Row["prenom_fournis"].ToString();
            textBox3.Text = dv1[0].Row["tel_fournis"].ToString();
            textBox4.Text = dv1[0].Row["email"].ToString();
            textBox5.Text = dv1[0].Row["ville"].ToString();
            textBox6.Text = dv1[0].Row["pays_fournis"].ToString();
            textBox7.Text = dv1[0].Row["adresse_fournis"].ToString();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dv1 = new DataView(dts.Tables["Mesfournisseur"], "codeFr =" + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
                dv1[0].BeginEdit();
                dv1[0]["nom_fournis"] = textBox1.Text;
                dv1[0]["prenom_fournis"] = textBox2.Text;

                dv1[0].Row["tel_fournis"] = textBox3.Text;
                dv1[0].Row["email"] = textBox4.Text;
                dv1[0].Row["ville"] = textBox5.Text;
                dv1[0].Row["pays_fournis"] = textBox6.Text;
                dv1[0].Row["adresse_fournis"] = textBox7.Text;

                dv1[0].EndEdit();
                MessageBox.Show("Modification Effectuée");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nom De Fourni")
            {
                textBox1.Text = "";

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Prenom De Fourni")
            {
                textBox2.Text = "";

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Telephon De Fourni")
            {
                textBox3.Text = "";

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Email Fourni")
            {
                textBox4.Text = "";

            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {

            if (textBox5.Text == " Ville Fourni")
            {
                textBox5.Text = "";

            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Pays Du Fourni")
            {
                textBox6.Text = "";

            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {

            if (textBox7.Text == "Adresse De Fourni")
            {
                textBox7.Text = "";

            }
        }
    }
}
