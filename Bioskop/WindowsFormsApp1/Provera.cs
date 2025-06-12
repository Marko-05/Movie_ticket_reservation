using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
            Podaci.pom = 1;
            rtbProvera.Enabled = false;
            rtbProvera.Text = "\nIme i prezime: " + Podaci.Ime + " " + Podaci.Prezime + "\n\nBroj telefona: " + Podaci.BrojTel +
                              "\n\nOdabran film: " + Podaci.Film + "\n\nDatum: " + Podaci.Datum.ToShortDateString() + 
                              "\n\nBroj i tip karata: " + Podaci.BrKarata.ToString() + " " + Podaci.TipKarata +
                              "\n\nUkupna cena: " + Podaci.Cena.ToString() + "\n\nOdabrana mesta: " + Podaci.Mesta;

            saveFileDialog1.InitialDirectory = @"C:\Users\Private\Desktop\";
            saveFileDialog1.Filter = "rtf fajl| *.rtf";
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
                Close();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                
               rtbProvera.SaveFile(saveFileDialog1.FileName);
                
                
                MessageBox.Show("Uspesna prijava.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
            
            
        }

        private void Provera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da zelite da izadjete?", "Poruka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Otkazali ste rezervaciju.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = false;
            }

            else
            e.Cancel = true;
        }
    }
}
