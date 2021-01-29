using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace tes
{
    public partial class Ventes : Form
    {
        public Ventes()
        {
            InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
        DataSet dts = new DataSet();
        DataView dv = new DataView();
        DataView dv1 = new DataView();
        DataView dv2 = new DataView();

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
        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Ventes_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select codecl,nom_client,prenom_client,adresse_client,tel_client,pays_client,ville, email from dbo.Client", co);
            dts.Clear();
            dtp.Fill(dts, "MesClients");

            SqlDataAdapter dtp2 = new SqlDataAdapter("select nom_client,prenom_client,tel_client,ville,dateCom,Qte,nom_profuit,prix_produit from Client cl, commande cmd, detail dt, produit pr where cl.codecl = cmd.codecl and dt.id_produit = pr. id_produit", co);
            DataSet d = new DataSet();
            dtp2.Fill(d, "Mesvents");




            try
            {
                comboBox1.DisplayMember = "codecl";
                comboBox1.ValueMember = "codecl";
                comboBox1.DataSource = dts.Tables["MesClients"];

                dataGridView1.DataSource = d.Tables["Mesvents"];

                dv = new DataView(dts.Tables["MesClients"], "", "", DataViewRowState.ModifiedCurrent);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dv1 = new DataView(dts.Tables["MesClients"], "codecl=" + comboBox1.SelectedValue, "", DataViewRowState.CurrentRows);
            textBox2.Text = dv1[0].Row["nom_client"].ToString();
            textBox3.Text = dv1[0].Row["prenom_client"].ToString();
            textBox4.Text = dv1[0].Row["tel_client"].ToString();
           
            textBox5.Text = dv1[0].Row["ville"].ToString();

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
