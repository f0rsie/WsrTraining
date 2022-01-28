using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class RegMark
    {
        private List<char> gostAlphabet = new List<char> { 'А', 'В', 'Е', 'К', 'М', 'Н', 'О', 'Р', 'С', 'Т', 'У', 'Х' };
        private List<int> regionCodes = new List<int> { };

        public bool CheckMark(string mark)
        {
            if ((mark.Length >= 5 && mark.Length <= 6) == false)
                return false;

            string seria = $"{mark[0]}{mark[4]}{mark[5]}".ToUpper();

            if (isSeriaCheck(seria) == false)
                return false;

            string number = "";
            for (int i = 0; i < mark.Length; i++)
            {
                if (i == 1 || i == 2 || i == 3 || i >= 6)
                    number += mark[i].ToString().ToUpper();
            }

            if (isNumberCheck(number) == false)
                return false;

            if (isCurrentNumberCheck(number) == false)
                return false;

            return true;
        }

        public string GetNextMarkAfter(string mark)
        {
            return mark;
        }

        public string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            return prevMark;
        }

        public int GetCombinationsCountInRange(string mark1, string mark2)
        {
            return 0;
        }

        private bool isCurrentNumberCheck(string str)
        {
            var regNumber = $"{str[0]}{str[1]}{str[2]}";

            var regionCode = str.Replace(regNumber, "");

            return true;
        }

        private bool isNumberCheck(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i]) == false)
                    return false;
            }

            return true;
        }

        private bool isSeriaCheck(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (gostAlphabet.Contains(str[i]) == false)
                    return false;
            }

            return true;
        }
    }
}
