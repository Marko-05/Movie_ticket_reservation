using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class UnosPodataka : Form
    {
        public UnosPodataka()
        {
            InitializeComponent();
        }

        
        int brojacGreske;

        private void Form1_Load(object sender, EventArgs e)
        {
            //ResetujMestaUFajlu();
            
            Podaci.MakePictureBoxRound(pictureBox1);
            BackgroundImage = Image.FromFile("./pozadina.jpg");
            Icon = new Icon("ikona.ico");
            pictureBox1.Image = Image.FromFile(@"./logo.png");
            dtpDatum.MinDate = DateTime.Today;
            dtpDatum.MaxDate = DateTime.Today.AddDays(7);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            brojacGreske = 0;
            
            //Dinamicko ucitavanje comboBox podataka kroz json
            try
            {
                string jsonContent = File.ReadAllText("Filmovi.json");
                List<Film> filmovi = JsonConvert.DeserializeObject<List<Film>>(jsonContent);
                cbFilm.DataSource = filmovi;
                cbFilm.DisplayMember = "NazivVreme";
                cbFilm.ValueMember = "NazivVreme";
                cbFilm.SelectedIndex = -1;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju Filmova","Greska");
                cbFilm.Items.Add("Film1");
                cbFilm.Items.Add("Film2");
                cbFilm.SelectedIndex = -1;
            }

        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            tbIme.Clear();
            tbPrezime.Clear();
            tbBroj.Clear();
            cbFilm.Text = "";
            dtpDatum.Value = DateTime.Now;
        }
        

        //Provera podataka i otvaranje naredne forme
        private void btnIzbor_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string ime = tbIme.Text;
            string prezime = tbPrezime.Text;
            string film = cbFilm.Text;
            string brojtel=tbBroj.Text;
            brojacGreske = 0;

            if (!Regex.IsMatch(ime, @"^[A-Za-z]{3,40}$"))
            {
                errorProvider1.SetError(tbIme, "Unesite ispravno ime (3+ slova)");

                brojacGreske++;
            }

            if (!Regex.IsMatch(brojtel, @"^[0-9]{0,40}$"))
            {
                errorProvider1.SetError(tbBroj, "Unesite ispravan broj telefona");

                brojacGreske++;
            }

            if (!Regex.IsMatch(prezime, @"^[A-Za-z]{1,40}$"))
            {
                errorProvider1.SetError(tbPrezime, "Unesite ispravno prezime (3+ slova)");

                brojacGreske++;
            }

            if (film.Length <= 0)
            {
                errorProvider1.SetError(cbFilm, "Odaberite film");

                brojacGreske++;
            }

            if(brojacGreske == 0)
            {
                Podaci.Ime = tbIme.Text;
                Podaci.Prezime = tbPrezime.Text;
                Podaci.Film = cbFilm.Text;
                Podaci.BrojTel = tbBroj.Text;
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

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Da li ste sigurni da želite da zatvorite aplikaciju?", "Izlaz", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }



        //Sigurniji unos podataka (Za telefon samo brojevi i space, za ime i prezime samo slova i space)
        private void tbBroj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57))
            {
                e.Handled = false;
            }

            else
            { e.Handled = true; }
        }

        private void tbIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Korisnik ne moze da unosi sam ime filma, nego mora da ga izabere od ponudjenih
        private void cbFilm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }




        //ErrorProvider podesavanje gresaka kada korisnik napusti kontrolu (ili uklanjanje istih)
        private void tbIme_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tbIme.Text, @"^[A-Za-z]{1,40}$"))
            
                errorProvider1.SetError(tbIme, "Unesite ispravno ime");
               
            
                else
                errorProvider1.SetError(tbIme, "");
            
        }

        private void tbPrezime_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(tbPrezime.Text, @"^[A-Za-z]{3,40}$"))
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



        private void ResetujMestaUFajlu()
        {
            string putanja = "bioskop_winforms.json";

            if (File.Exists(putanja))
            {
                try
                {
                    string stariJson = File.ReadAllText(putanja);
                    List<Sediste> privremenaLista = JsonConvert.DeserializeObject<List<Sediste>>(stariJson);

                    if (privremenaLista != null)
                    {
                        foreach (var s in privremenaLista)
                        {
                            s.Status = "Slobodno";
                        }

                        string noviJson = JsonConvert.SerializeObject(privremenaLista, Formatting.Indented);
                        File.WriteAllText(putanja, noviJson);

                        MessageBox.Show("Fajl je uspešno resetovan! Pri sledećem pokretanju aplikacije sva mesta će biti slobodna.", "Testiranje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri resetovanju fajla: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
