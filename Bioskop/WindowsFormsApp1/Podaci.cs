using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Podaci
    {
        static string ime, prezime, film, brojTel, tipKarata;
        static decimal brKarata;
        static DateTime datum;
        static int cena;
        static string mesta;
        public static int Brojac = 0;
        internal static int pom;
        public static string Ime { get => ime; set => ime = value; }
        public static string Prezime { get => prezime; set => prezime = value; }
        public static string Film { get => film; set => film = value; }
        public static string BrojTel { get => brojTel; set => brojTel = value; }
        public static string TipKarata { get => tipKarata; set => tipKarata = value; }
        public static decimal BrKarata { get => brKarata; set => brKarata = value; }
        public static DateTime Datum { get => datum; set => datum = value; }
        public static int Cena { get => cena; set => cena = value; }
        public static string Mesta { get => mesta; set => mesta = value; }
    }
}
