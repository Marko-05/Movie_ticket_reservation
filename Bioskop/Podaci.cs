using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    class Podaci
    {
        static string ime, prezime, film, brojTel, odabranaMesta;
        static DateTime datum;
        static double cena;

        public static string Ime { get => ime; set => ime = value; }
        public static string Prezime { get => prezime; set => prezime = value; }
        public static string Film { get => film; set => film = value; }
        public static string BrojTel { get => brojTel; set => brojTel = value; }
        public static string OdabranaMesta { get => odabranaMesta; set => odabranaMesta = value; }
        public static DateTime Datum { get => datum; set => datum = value; }
        public static double Cena { get => cena; set => cena = value; }


        //Metoda za kreiranje okrugle slike za logo
        public static void MakePictureBoxRound(PictureBox pb)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pb.Width, pb.Height);
            pb.Region = new Region(path);
        }
    }
}







