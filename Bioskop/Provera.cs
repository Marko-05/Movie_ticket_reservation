using System;
using System.Drawing;

using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Provera : Form
    {
        public Provera()
        {
            InitializeComponent();
        }
        

        private void Provera_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"./logo.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            Podaci.MakePictureBoxRound(pictureBox1);

            
            Icon = new Icon("ikona.ico");
            BackgroundImage = Image.FromFile("./pozadina.jpg");

            rtbProvera.ReadOnly = true;
            rtbProvera.Text += "\nIme i prezime: " + Podaci.Ime + " " + Podaci.Prezime;
            if(Podaci.BrojTel != string.Empty)
                rtbProvera.Text += $"\n\nBroj telefona: {Podaci.BrojTel}";
            rtbProvera.Text += $"\n\nOdabran film: {Podaci.Film}";
            rtbProvera.Text += $"\n\nDatum: {Podaci.Datum.ToShortDateString()}";
            rtbProvera.Text += $"\n\nOdabrana mesta: {Podaci.OdabranaMesta}";
            rtbProvera.Text += $"\n\nUkupna cena: {Podaci.Cena.ToString()} RSD";

        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

    }
}
