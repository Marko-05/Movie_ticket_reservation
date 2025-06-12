using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Izbor : Form
    {
        public Izbor()
        {
            InitializeComponent();
        }

        private void Izbor_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "\n\n\t\t\t\tPlatno";
            Image slika =Image.FromFile(@"C:\Users\Private\Desktop\Marko Dj\WindowsFormsApp1\sediste.jpg");
            pictureBox1.Image = slika;
            Podaci.Brojac = 0;
            Podaci.Mesta = "";
            
            if (Podaci.TipKarata == "Standard")
            {
                V1.Enabled = false;
                V2.Enabled = false;
                V3.Enabled = false;
                V4.Enabled = false;
                P1.Enabled = false;
                P2.Enabled = false;
                P3.Enabled = false;
                P4.Enabled = false;
                S1.BackColor = Color.Gold;
                S2.BackColor = Color.Gold;
                S3.BackColor = Color.Gold;
                S4.BackColor = Color.Gold;
            }

            if(Podaci.TipKarata == "Premium")
            {
                V1.Enabled = false;
                V2.Enabled = false;
                V3.Enabled = false;
                V4.Enabled = false;
                S1.Enabled = false;
                S2.Enabled = false;
                S3.Enabled = false;
                S4.Enabled = false;
                P1.BackColor = Color.Gold;
                P2.BackColor = Color.Gold;
                P3.BackColor = Color.Gold;
                P4.BackColor = Color.Gold;
            }

            if(Podaci.TipKarata == "VIP")
            {
                S1.Enabled = false;
                S2.Enabled = false;
                S3.Enabled = false;
                S4.Enabled = false;
                P1.Enabled = false;
                P2.Enabled = false;
                P3.Enabled = false;
                P4.Enabled = false;
                V1.BackColor = Color.Gold;
                V2.BackColor = Color.Gold;
                V3.BackColor = Color.Gold;
                V4.BackColor = Color.Gold;
            }

            tbUkupno.Text = Podaci.Cena.ToString() + " RSD";
        }

        private void Dugmad(Button dugme)
        {
            if(Podaci.Brojac < Podaci.BrKarata)
            {
                dugme.Enabled = false;
                tbMesta.Text += dugme.Text + " ";
                Podaci.Brojac++;
                dugme.BackColor = Color.Red;
            }
            else
                MessageBox.Show("Već ste izabrali mesta. "  + "Ukoliko želite da promenite mesta pritisnite dugme Poništi mesta.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (Podaci.TipKarata == "Standard")
            {
                S1.Enabled = true;
                S2.Enabled = true;
                S3.Enabled = true;
                S4.Enabled = true;
                S1.BackColor = Color.Gold;
                S2.BackColor = Color.Gold;
                S3.BackColor = Color.Gold;
                S4.BackColor = Color.Gold;

            }

            if (Podaci.TipKarata == "Premium")
            {
                P1.Enabled = true;
                P2.Enabled = true;
                P3.Enabled = true;
                P4.Enabled = true;
                P1.BackColor = Color.Gold;
                P2.BackColor = Color.Gold;
                P3.BackColor = Color.Gold;
                P4.BackColor = Color.Gold;
            }

            if (Podaci.TipKarata == "VIP")
            {
                V1.Enabled = true;
                V2.Enabled = true;
                V3.Enabled = true;
                V4.Enabled = true;
                V1.BackColor = Color.Gold;
                V2.BackColor = Color.Gold;
                V3.BackColor = Color.Gold;
                V4.BackColor = Color.Gold;
            }

            tbMesta.Clear();
            Podaci.Brojac = 0;
        }



        

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void S1_Click(object sender, EventArgs e)
        {
            Dugmad(S1);
        }

        private void S2_Click(object sender, EventArgs e)
        {
            Dugmad(S2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Dugmad(S3);
        }

        private void S4_Click(object sender, EventArgs e)
        {
            Dugmad(S4);
        }

        private void P1_Click(object sender, EventArgs e)
        {
            Dugmad(P1);
        }

        private void P2_Click(object sender, EventArgs e)
        {
            Dugmad(P2);
        }

        private void P3_Click(object sender, EventArgs e)
        {
            Dugmad(P3);
        }

        private void P4_Click(object sender, EventArgs e)
        {
            Dugmad(P4);
        }

        private void V1_Click(object sender, EventArgs e)
        {
            Dugmad(V1);
        }

        private void V2_Click(object sender, EventArgs e)
        {
            Dugmad(V2);
        }

        private void V3_Click(object sender, EventArgs e)
        {
            Dugmad(V3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dugmad(V4);
        }

        private void btnPotvrda_Click(object sender, EventArgs e)
        {
            if (Podaci.Brojac == Podaci.BrKarata)
            {
                Podaci.Mesta = tbMesta.Text;
                Provera forma3 = new Provera();
                if (forma3.ShowDialog() == DialogResult.Cancel)
                {
                    Close();
                }

                else
                  Close();
                

                forma3.Dispose();
            }

            else
                MessageBox.Show("Molimo Vas da odaberete mesta.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void Izbor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Podaci.pom == 0)
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da izadjete?", "Poruka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {}

                else
                    e.Cancel = true;
            }

            else
            {
                Podaci.pom = 0;
                e.Cancel = false;
            }

            
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
