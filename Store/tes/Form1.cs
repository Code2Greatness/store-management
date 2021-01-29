using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tes
{
    public partial class Main : Form
    {

        //int TogMove;
        //int MValX;
        //int MValY;
        private const int cGrip = 16;
        private const int cCaption = 32;
        public Main()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
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
        public void activerform()
        {
            bunifuFlatButton2.Enabled = true;
            bunifuFlatButton3.Enabled = true;
            bunifuFlatButton4.Enabled = true;
            bunifuFlatButton5.Enabled = true;
            bunifuFlatButton6.Enabled = true;
            bunifuImageButton1.Enabled = true;
            bunifuImageButton2.Enabled = true;
            bunifuImageButton3.Enabled = true;
            bunifuImageButton4.Enabled = true;
            bunifuImageButton5.Enabled = true;
            bunifuImageButton6.Enabled = true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            produits ven = new produits();
            ven.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            login log = new login(this);
            log.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bunifuFlatButton2.Enabled = false;
            bunifuFlatButton3.Enabled = false;
            bunifuFlatButton4.Enabled = false;
            bunifuFlatButton5.Enabled = false;
            bunifuFlatButton6.Enabled = false;
            bunifuImageButton1.Enabled = false;
            bunifuImageButton2.Enabled = false;
            bunifuImageButton3.Enabled = false;
            bunifuImageButton4.Enabled = false;
            bunifuImageButton5.Enabled = false;
            bunifuImageButton6.Enabled = false;
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Achat ach = new Achat();
            ach.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            clientforniss clfr = new clientforniss();
            clfr.Show();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            stock stk = new stock();
            stk.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            produits ven = new produits();
            ven.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            login log = new login(this);
            log.Show();
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Ventes vt = new Ventes();
            vt.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Achat ach = new Achat();
            ach.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            {
                clientforniss clfr = new clientforniss();
                clfr.Show();
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            stock stk = new stock();
            stk.Show();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Ventes vn = new Ventes();
            vn.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Restauration RES = new Restauration();
            RES.Show();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {

            //if (TogMove == 1)
            //{
            //    this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            //}


        }


        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            //TogMove = 1;
            //MValX = e.X;
            //MValY = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            //TogMove = 0;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //TogMove = 1;
            //MValX = e.X;
            //MValY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //TogMove = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            //if (TogMove == 1)
            //{
            //    this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            //}
        }
    }
}
