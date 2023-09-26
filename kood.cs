using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace isik
{
    public class IdCode
    {
        private readonly string _idCode;

        public IdCode(string idCode)
        {
            _idCode = idCode;
        }


        public IdCode()
        {
            _idCode = " ";
        }
        //проверка длинны исикукода
        private bool IsValidLength()
        {
            return _idCode.Length == 11;
        }



        //проверка на отсутвие других символов
        private bool ContainsOnlyNumbers()
        {
            // return _idCode.All(Char.IsDigit);

            for (int i = 0; i < _idCode.Length; i++)
            {
                if (!Char.IsDigit(_idCode[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private int GetGenderNumber()
        {
            return Convert.ToInt32(_idCode.Substring(0, 1));
        }
        //определение пола по исикукоод, четные женщины и нечетные мужчины
        private bool IsValidGenderNumber()
        {
            int genderNumber = GetGenderNumber();
            return genderNumber > 0 && genderNumber < 7;
        }

        private int Get2DigitYear()
        {
            return Convert.ToInt32(_idCode.Substring(1, 2));
        }


        
        public int GetFullYear()
        { 
            //определение пола по исикукоод, четные женщины и нечетные мужчины
            int genderNumber = GetGenderNumber();
            // 1, 2 => 18xx
            // 3, 4 => 19xx
            // 5, 6 => 20xx
            return 1800 + (genderNumber - 1) / 2 * 100 + Get2DigitYear();
        }

        private int GetMonth()
        {
            return Convert.ToInt32(_idCode.Substring(3, 2));
        }

        //проверка месяца, если больше 13 или меньше 0, то возращает 
        private bool IsValidMonth()
        {
            int month = GetMonth();
            return month > 0 && month < 13;
        }



        //определение обычный год или високосный, если делится на 4 без остатка и не делится на 100, то это високосный год
        private static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
        private int GetDay()
        {
            return Convert.ToInt32(_idCode.Substring(5, 2));
        }

        private bool IsValidDay()
        {
            int day = GetDay();
            int month = GetMonth();
            int maxDays = 31;
            if (new List<int> { 4, 6, 9, 11 }.Contains(month)) //определение месяца, апрель/июнь/сентябрь/ноябрь, если это они то 30 дней
            {
                maxDays = 30;
            }
            if (month == 2) //если февраль
            {
                if (IsLeapYear(GetFullYear())) //если високосный год, то 29 дней, если обычный год, то 28 дней
                {
                    maxDays = 29;
                }
                else
                {
                    maxDays = 28;
                }
            }
            return 0 < day && day <= maxDays;
        }

        private int CalculateControlNumberWithWeights(int[] weights)
        {
            int total = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                total += Convert.ToInt32(_idCode.Substring(i, 1)) * weights[i];
            }
            return total;
        }

        private bool IsValidControlNumber()
        {
            int controlNumber = Convert.ToInt32(_idCode[^1..]);
            int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            int total = CalculateControlNumberWithWeights(weights);
            if (total % 11 < 10)
            {
                return total % 11 == controlNumber;
            }
            // second round
            int[] weights2 = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            total = CalculateControlNumberWithWeights(weights2);
            if (total % 11 < 10)
            {
                return total % 11 == controlNumber;
            }
            // third round, control number has to be 0
            return controlNumber == 0;
        }

        public bool IsValid()//если хотя бы что-то неверно, то возращение идет как ошибка
        {
            return IsValidLength() && ContainsOnlyNumbers()
                && IsValidGenderNumber() && IsValidMonth()
                && IsValidDay()
                && IsValidControlNumber();
        }

        public DateOnly GetBirthDate()
        {
            int day = GetDay();
            int month = GetMonth();
            int year = GetFullYear();
            return new DateOnly(year, month, day);
        }
        public string GetGender()
        {
            int genderNumber = GetGenderNumber();

            if (genderNumber % 2 == 0)
            {
                return "Naine";
            }
            else
            {
                return "Mees";
            }
        }

        public string GetHospital()
        {
            int birthNumber = int.Parse(_idCode.Substring(7, 3));

            if (1 < birthNumber && birthNumber < 10)
            {
                return "Kuressaare Haigla";
            }
            else if (11 < birthNumber && birthNumber < 19)
            {
                return "Tartu Ülikooli Naistekliinik, Tartumaa, Tartu";
            }
            else if (21 < birthNumber && birthNumber < 220)
            {
                return "Ida-Tallinna Keskhaigla, Pelgulinna sünnitusmaja, Hiiumaa, Keila, Rapla haigla, Loksa haigla";
            }
            else if (221 < birthNumber && birthNumber < 270)
            {
                return "Ida-Viru Keskhaigla (Kohtla-Järve, endine Jõhvi)";
            }
            else if (271 < birthNumber && birthNumber < 370)
            {
                return "Maarjamõisa Kliinikum (Tartu), Jõgeva Haigla";
            }
            else if (371 < birthNumber && birthNumber < 420)
            {
                return "Narva Haigla";
            }
            else if (421 < birthNumber && birthNumber < 470)
            {
                return "Pärnu Haigla";
            }
            else if (471 < birthNumber && birthNumber < 490)
            {
                return "Pelgulinna Sünnitusmaja (Tallinn), Haapsalu haigla";
            }
            else if (491 < birthNumber && birthNumber < 520)
            {
                return "Järvamaa Haigla (Paide)";
            }
            else if (521 < birthNumber && birthNumber < 570)
            {
                return "Rakvere, Tapa haigla";
            }
            else if (571 < birthNumber && birthNumber < 600)
            {
                return "Valga Haigla";
            }
            else if (601 < birthNumber && birthNumber < 650)
            {
                return "Viljandi Haigla";
            }
            else if (651 < birthNumber && birthNumber < 700)
            {
                return "Lõuna-Eesti Haigla (Võru), Põlva Haigla";
            }
            else
            {
                return "Välismaal";
            }
        }
    }
}