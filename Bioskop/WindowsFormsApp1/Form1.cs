using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int brojac;
        private void Form1_Load(object sender, EventArgs e)
        {
            Image sl = Image.FromFile(@"C:\Users\Private\Desktop\Marko Dj\WindowsFormsApp1\slika.jpeg");
            dtpDatum.MinDate = DateTime.Today;
            pictureBox1.Image = sl;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            brKarata.Value = 1;
            tipKarata.Value = 1;
            brojac = 0;
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            tbIme.Clear();
            tbPrezime.Clear();
            tbBroj.Clear();
            cbFilm.Text = "";
            dtpDatum.Value = DateTime.Now;
            brKarata.Value = 1;
            tipKarata.Value = 1;
        }
        
        private void btnIzbor_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string ime = tbIme.Text;
            string prezime = tbPrezime.Text;
            string film = cbFilm.Text;
            string brojtel=tbBroj.Text;
            brojac = 0;

            if (!Regex.IsMatch(ime, @"^[A-Za-z]{1,40}$"))
            {
                errorProvider1.SetError(tbIme, "Unesite ispravno ime");
               
                brojac++;
            }

            if (!Regex.IsMatch(brojtel, @"^[0-9]{0,40}$"))
            {
                errorProvider1.SetError(tbBroj, "Unesite ispravan broj telefona");

                brojac++;
            }

            if (!Regex.IsMatch(prezime, @"^[A-Za-z]{1,40}$"))
            {
                errorProvider1.SetError(tbPrezime, "Unesite ispravno prezime");
                
                brojac++;
            }

            if (film.Length <= 0)
            {
                errorProvider1.SetError(cbFilm, "Odaberite film");
                
                brojac++;
            }

            if(brojac == 0)
            {
                Podaci.Ime = tbIme.Text;
                Podaci.Prezime = tbPrezime.Text;
                Podaci.Film = cbFilm.Text;
                Podaci.BrojTel = tbBroj.Text;
                Podaci.BrKarata = brKarata.Value;
                if(tipKarata.Value == 1)
                {
                    Podaci.TipKarata = "Standard";
                    Podaci.Cena = 400 * int.Parse(brKarata.Value.ToString());
                }

                if(tipKarata.Value == 2)
                {
                    Podaci.TipKarata = "Premium";
                    Podaci.Cena = 600 * int.Parse(brKarata.Value.ToString());
                }

                if (tipKarata.Value == 3)
                {
                    Podaci.TipKarata = "VIP";
                    Podaci.Cena = 800 * int.Parse(brKarata.Value.ToString());
                }

                Podaci.Datum = dtpDatum.Value;

                Izbor forma = new Izbor();
                forma.ShowDialog();
                forma.Dispose();
            }

            else
            {
                MessageBox.Show("Niste uneli sve podatke pravilno","Poruka",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da zelite da izadjete?","Poruka", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }

            else 
                e.Cancel = true;
        }

        private void tbBroj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57))
            {
                e.Handled = false;
            }

            else
            { e.Handled = true; }
        }

        private void tbIme_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tbIme.Text, @"^[A-Za-z]{1,40}$"))
            
                errorProvider1.SetError(tbIme, "Unesite ispravno ime");
               
            
                else
                errorProvider1.SetError(tbIme, "");
            
        }

        private void tbPrezime_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tbPrezime.Text, @"^[A-Za-z]{1,40}$"))
                errorProvider1.SetError(tbPrezime, "Unesite ispravno prezime");

            else errorProvider1.SetError(tbPrezime, "");
        }

        private void tbBroj_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tbBroj.Text, @"^[0-9]{0,40}$"))
                errorProvider1.SetError(tbBroj, "Unesite ispravan broj telefona");

            else errorProvider1.SetError(tbPrezime, "");

        }

        private void cbFilm_Leave(object sender, EventArgs e)
        {
            if (cbFilm.Text == "")
                errorProvider1.SetError(cbFilm, "Odaberite film");

            else
                errorProvider1.SetError(cbFilm, "");
                
            
        }

        private void cbFilm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
