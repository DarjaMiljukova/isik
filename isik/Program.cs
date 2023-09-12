using System;



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
        public static void Main()
        {
            Console.WriteLine("Hei, kirjutage sinu isikukood: ");
            string kod = Console.ReadLine();

            IdCode idCode = new IdCode(kod);

            if (idCode.IsValid())
            {
                Console.WriteLine($"Sünniaasta: {idCode.GetFullYear()}");
                Console.WriteLine($"Sünnikuupäev: {idCode.GetBirthDate():dd.MM.yyyy}");
                Console.WriteLine("Isikukood on õige.");
            }
            else
            {
        
                Console.WriteLine("Isikukood on vale.");
            }
        }
    }


}




//using System;

//public class Program
//{
//    public static string sünnikoht(string ikood)
//    {
//        char[] ikood_list = ikood.ToCharArray();
//        string tahed_8910 = ikood_list[7].ToString() + ikood_list[8].ToString() + ikood_list[9].ToString();
//        int t = int.Parse(tahed_8910);
//        string haigla;

//        if (1 < t && t < 10)
//        {
//            haigla = "Kuressaare Haigla";
//        }
//        else if (11 < t && t < 19)
//        {
//            haigla = "Tartu Ülikooli Naistekliinik, Tartumaa, Tartu";
//        }
//        else if (21 < t && t < 220)
//        {
//            haigla = "Ida-Tallinna Keskhaigla, Pelgulinna sünnitusmaja, Hiiumaa, Keila, Rapla haigla, Loksa haigla";
//        }
//        else if (221 < t && t < 270)
//        {
//            haigla = "Ida-Viru Keskhaigla (Kohtla-Järve, endine Jõhvi)";
//        }
//        else if (271 < t && t < 370)
//        {
//            haigla = "Maarjamõisa Kliinikum (Tartu), Jõgeva Haigla";
//        }
//        else if (371 < t && t < 420)
//        {
//            haigla = "Narva Haigla";
//        }
//        else if (421 < t && t < 470)
//        {
//            haigla = "Pärnu Haigla";
//        }
//        else if (471 < t && t < 490)
//        {
//            haigla = "Pelgulinna Sünnitusmaja (Tallinn), Haapsalu haigla";
//        }
//        else if (491 < t && t < 520)
//        {
//            haigla = "Järvamaa Haigla (Paide)";
//        }
//        else if (521 < t && t < 570)
//        {
//            haigla = "Rakvere, Tapa haigla";
//        }
//        else if (571 < t && t < 600)
//        {
//            haigla = "Valga Haigla";
//        }
//        else if (601 < t && t < 650)
//        {
//            haigla = "Viljandi Haigla";
//        }
//        else if (651 < t && t < 700)
//        {
//            haigla = "Lõuna-Eesti Haigla (Võru), Põlva Haigla";
//        }
//        else
//        {
//            haigla = "Välismaal";
//        }

//        return haigla;
//    }

//    public static void Main()
//    {
//        string ikood = "1234567890";
//        string result = sünnikoht(ikood);
//        Console.WriteLine(result);
//    }
//}