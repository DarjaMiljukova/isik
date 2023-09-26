using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;



//public Sunnikoht()
//{

//    def sünnikoht(ikood: str)->str:
//    ikood_list = list(ikood)
//tahed_8910 = ikood_list[7] + ikood_list[8] + ikood_list[9]
//t = int(tahed_8910)
//if 1 < t < 10:
//    haigla = "Kuressaare Haigla"
//elif 11 < t < 19:
//    haigla = "Tartu Ülikooli Naistekliinik, Tartumaa, Tartu"
//elif 21 < t < 220:
//    haigla = "Ida-Tallinna Keskhaigla, Pelgulinna sünnitusmaja, Hiiumaa, Keila, Rapla haigla, Loksa haigla"
//elif 221 < t < 270:
//    haigla = "Ida-Viru Keskhaigla (Kohtla-Järve, endine Jõhvi)"
//elif 271 < t < 370:
//    haigla = "Maarjamõisa Kliinikum (Tartu), Jõgeva Haigla"
//elif 371 < t < 420:
//    haigla = "Narva Haigla"
//elif 421 < t < 470:
//    haigla = "Pärnu Haigla"
//elif 471 < t < 490:
//    haigla = "Pelgulinna Sünnitusmaja (Tallinn), Haapsalu haigla"
//elif 491 < t < 520:
//    haigla = "Järvamaa Haigla (Paide)"
//elif 521 < t < 570:
//    haigla = "Rakvere, Tapa haigla"
//elif 571 < t < 600:
//    haigla = "Valga Haigla"
//elif 601 < t < 650:
//    haigla = "Viljandi Haigla"
//elif 651 < t < 700:
//    haigla = "Lõuna-Eesti Haigla (Võru), Põlva Haigla"
//else:
//    haigla = "Välismaal"
//return haigla
//}




namespace isik
{

    public class Program
    {
        static void ChangeConsoleColor(ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;

        }
        public static void Main()
        {
            Console.WriteLine("Hei, kirjutage sinu isikukood: \n");
            string kod = Console.ReadLine();
            Console.WriteLine(" ");
            IdCode idCode = new IdCode(kod);

            if (idCode.IsValid())
            {
                Console.WriteLine($"Sünniaasta: {idCode.GetFullYear()}");
                Console.WriteLine($"Sünnikuupäev: {idCode.GetBirthDate():dd.MM.yyyy}");
                Console.WriteLine($"Sugu: {idCode.GetGender()} ");
                Console.WriteLine($"Haiglasse: {idCode.GetHospital()} \n");
                ChangeConsoleColor(ConsoleColor.Green);
                Console.WriteLine("Isikukood on õige.");
                Console.ResetColor();
            }
            else
            {
                ChangeConsoleColor(ConsoleColor.Red);
                Console.WriteLine("Isikukood on vale.");
                Console.ResetColor();
            }
        }
    }


}

