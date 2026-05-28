
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Izbor : Form
    {
        public Izbor()
        {
            InitializeComponent();
            GenerisiSalu();
            UcitajIzFajla();
        }

        //Broji odabrana mesta
        int brojac;


        //Metoda za kreiranje teksta cenovnika
        private void DodajObojeniTekst(RichTextBox rtb, string tekst, Color boja, bool naslov)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = boja;
            rtb.SelectionAlignment = (naslov) ? HorizontalAlignment.Center : HorizontalAlignment.Left;
            rtb.AppendText(tekst);
            rtb.SelectionColor = rtb.ForeColor;
        }

        private void Izbor_Load(object sender, EventArgs e)
        {
            brojac = 0;
            Icon = new Icon("ikona.ico");
            BackgroundImage = Image.FromFile("./pozadina.jpg");
            tbMesta.Text = "";
            tbUkupno.Text = "0 RSD";
            richTextBox1.Text = "\nPlatno";
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            Podaci.MakePictureBoxRound(pictureBox1);

            pictureBox1.Image = Image.FromFile(@"./logo.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


            //Kreiranje cenovnika
            richTextBox2.Clear();
            richTextBox2.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            DodajObojeniTekst(richTextBox2, "CENOVNIK:\n\n", Color.Black, true);
            DodajObojeniTekst(richTextBox2, "■ ", Color.Green, false);
            DodajObojeniTekst(richTextBox2, "- Standardna sedišta (500 RSD)\n", Color.Black, false);
            DodajObojeniTekst(richTextBox2, "■ ", Color.DeepPink, false);
            DodajObojeniTekst(richTextBox2, "- Love sedišta (800 RSD)\n", Color.Black, false);
            DodajObojeniTekst(richTextBox2, "■ ", Color.Goldenrod, false);
            DodajObojeniTekst(richTextBox2, "- VIP sedišta (1000 RSD)\n", Color.Black, false);

            
            richTextBox2.ReadOnly = true;
        }



        List<Sediste> svaSedista = new List<Sediste>();
        private void GenerisiSalu()
        {
            for (int i = 1; i <= 66; i++)
            {
                Sediste s = new Sediste { Broj = i };
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Height = 50;
                btn.ForeColor = Color.White;
                btn.Font = new Font(btn.Font, FontStyle.Bold);

                if (i > 46)
                {
                    s.Tip = "VIP";
                    btn.BackColor = Color.Gold;
                    btn.Width = 50;
                    btn.ForeColor = Color.Black;
                }
               
                
                else if (i == 23 || i == 26 || i == 41 || i == 44)
                {
                    s.Tip = "Love";
                    btn.BackColor = Color.HotPink;
                    btn.Width = 106;
                    btn.ForeColor = Color.Black;
                    btn.Text = "❤️" + i;
                }

                else
                {
                    s.Tip = "Standard";
                    btn.BackColor = Color.Green;
                    btn.Width = 50;
                }

                btn.Tag = s;
                btn.Click += Dugme_Click;
                flowLayoutPanel1.Controls.Add(btn);
                svaSedista.Add(s);
            }
        }

        private void Dugme_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Sediste s = (Sediste)btn.Tag;

            if (s.Status == "Zauzeto")
                return;

            
            else if (s.Status == "Slobodno")
            {
                if (brojac < 6)
                {
                    s.Status = "Odabrano";
                    btn.BackColor = Color.LightBlue;
                    brojac++;
                }

                else
                    MessageBox.Show("Moguće je rezervisati maksimalno 6 mesta!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                s.Status = "Slobodno";
                brojac--;
                if (s.Tip == "VIP")
                    btn.BackColor = Color.Gold;
                else if (s.Tip == "Love")
                    btn.BackColor = Color.HotPink;
                else
                    btn.BackColor = Color.Green;
            }

                var odabrana = svaSedista.Where(sed => sed.Status == "Odabrano").ToList();
                tbMesta.Text = string.Join(", ", odabrana.Select(sed => sed.Broj));

                double ukupnaCena = odabrana.Sum(sed => sed.Cena);
                tbUkupno.Text = ukupnaCena.ToString() + " RSD";
        }


        

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            var odabrana = svaSedista.Where(s => s.Status == "Odabrano").ToList();

            if (odabrana.Count == 0)
            {
                MessageBox.Show("Niste odabrali sediste!", "Greska");
                return;
            }

            double ukupno = odabrana.Sum(s => s.Cena);
            string brojevi = string.Join(", ", odabrana.Select(s => s.Broj));

            Podaci.Cena = ukupno;
            Podaci.OdabranaMesta = brojevi;

            Provera formaProvera = new Provera();
            DialogResult rezultat = formaProvera.ShowDialog();

            if (rezultat == DialogResult.OK)
            {
                foreach (var s in odabrana)
                {
                    s.Status = "Zauzeto";
                }

                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is Button b && b.Tag is Sediste sed && sed.Status == "Zauzeto")
                    {
                        b.BackColor = Color.Red;
                        b.Enabled = false;
                    }
                }

                
                SacuvajUFajl();

                
                tbMesta.Text = "";
                tbUkupno.Text = "0 RSD";

                MessageBox.Show("Uspešno ste sačuvali rezervaciju!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }



        private void SacuvajUFajl()
        {
            try
            {
                string json = JsonConvert.SerializeObject(svaSedista, Formatting.Indented);
                File.WriteAllText("bioskop_winforms.json", json);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Greska pri cuvanju: " + ex.Message);
            }
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Button btn && btn.Tag is Sediste s)
                {
                    if (s.Status == "Odabrano")
                    {   
                        s.Status = "Slobodno";

                        if (s.Tip == "VIP")
                            btn.BackColor = Color.Gold;
                        else if (s.Tip == "Love")
                            btn.BackColor = Color.HotPink;
                        else
                            btn.BackColor = Color.Green;
                    }
                }
            }

            tbMesta.Text = "";
            tbUkupno.Text = "0 RSD";
        }


        private void UcitajIzFajla()
        {
            string putanja = "bioskop_winforms.json";

            
            if (File.Exists(putanja))
            {
                try
                {
                    string json = File.ReadAllText(putanja);
                    var ucitanaSedista = JsonConvert.DeserializeObject<List<Sediste>>(json);

                    if (ucitanaSedista != null && ucitanaSedista.Count > 0)
                    {
                        svaSedista = ucitanaSedista;

                        foreach (Control c in flowLayoutPanel1.Controls)
                        {
                            
                            if (c is Button btn && btn.Tag is Sediste staroSediste)
                            {
                               
                                Sediste ucitano = svaSedista.FirstOrDefault(s => s.Broj == staroSediste.Broj);

                                if (ucitano != null)
                                {
                                    btn.Tag = ucitano;

                                    if (ucitano.Status == "Zauzeto")
                                    {
                                        btn.BackColor = Color.Red;
                                        btn.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Nije uspelo učitavanje prethodnih rezervacija.\nRazlog: " + ex.Message, "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Izbor_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult odgovor = MessageBox.Show("Da li ste sigurni da želite da zatvorite aplikaciju?", "Izlaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (odgovor == DialogResult.Yes)
                    Application.Exit();
                
                else
                    e.Cancel = true;
            }
        }

    }
}
