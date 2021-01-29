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
    public partial class AjoutCommande : Form
    {
        public AjoutCommande()
        {
            InitializeComponent();
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
        SqlConnection co = new SqlConnection(@"Data Source=DESKTOP-JD5J0V0\SQLEXPRESS;Initial Catalog=Gestion_Stock2;Integrated Security=True");
        DataSet dts = new DataSet();

        private void AjoutCommande_Load(object sender, EventArgs e)
        {

            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.commande", co);
            DataSet dts = new DataSet();
            dts.Clear();
            dtp.Fill(dts, "Mescommande");

            SqlDataAdapter dtp2 = new SqlDataAdapter("select * from dbo.Client", co);
            DataSet dt = new DataSet();
            dt.Clear();
            dtp2.Fill(dt, "MesClient");
            try
            {
                comboBox1.DisplayMember = "codecl";
                comboBox1.ValueMember = "codecl";
                comboBox1.DataSource = dt.Tables["MesClient"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from dbo.commande", co);
            DataSet dts = new DataSet();
            dts.Clear();
            dtp.Fill(dts, "Mescommande");

            if (dateTimePicker1.Text != "")
            {
                try
                {
                    DataRow ligne;
                    ligne = dts.Tables["Mescommande"].NewRow();

                    ligne["dateCom"] = dateTimePicker1.Text;
                    ligne["codecl"] = comboBox1.SelectedValue;

                    dts.Tables["Mescommande"].Rows.Add(ligne);





                    MessageBox.Show("Ajout Effectué");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problème : " + ex.Message);
                }
            }
            else MessageBox.Show("Saisie Incompléte"); 
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dtp = new SqlDataAdapter("select * from commande", co);
            DataSet dts = new DataSet();
            dts.Clear();
            dtp.Fill(dts, "Mescommande");
            try
            {


                SqlCommandBuilder cmd = new SqlCommandBuilder(dtp);
                dtp.Update(dts.Tables["Mescommande"]);
                MessageBox.Show("Bien Enregistrer");
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème : " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}