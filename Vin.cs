using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIN_LIB.Model;

namespace VIN_LIB
{
    public class Vin
    {
        private List<Wmi> wmiCodes = new List<Wmi>();
        private List<char> visYearCodes = new List<char> { 'A', 'B', 'C', 'Y' };
        private List<(char, int)> simbolsWeight = new List<(char, int)>();
        private List<(int, int)> positionWeight = new List<(int, int)>();

        public bool CheckVIN(string vin)
        {
            if (vin.Length != 17)
                return false;

            var upperVin = vin.ToUpper().ToList();
            var errorSimbols = new List<char> { 'Q', 'I', 'O' };

            foreach (var item in errorSimbols)
            {
                if (upperVin.Contains(item))
                    return false;
            }

            string currentWmi = upperVin.GetRange(0, 3).ToString();

            if (currentWmi == "0")
                return false;

            if (isVdsCheck(upperVin.GetRange(3, 6).ToString()) == false)
                return false;

            string currentVis = upperVin.GetRange(9, 8).ToString();

            if (isVisCheck(currentVis) == false)
                return false;

            if (hashSumCheck(upperVin.ToString()) == false)
                return false;

            return true;
        }

        public string GetVINCountry(string vin)
        {
            return vin;
        }

        public int GetTransportYear(string vin)
        {
            return 0;
        }

        private bool hashSumCheck(string str)
        {
            string alphabet = "ABCDEFGHJKLMNPRSTUVWXYZ";
            string weightAlphabet = "876543210X98765432";

            for (int i = 1; i <= 9; i++)
            {
                simbolsWeight.Add((alphabet[i - 1], i));
            }

            for (int i = 1; i <= 17; i++)
            {
                if (str[i] == 'X')
                    positionWeight.Add((0, 0));

                positionWeight.Add((i, weightAlphabet[i - 1]));
            }

            int hashSum = 0;

            for (int i = 1; i <= 17; i++)
            {
                if (i == 9)
                    continue;

                hashSum += simbolsWeight[i - 1].Item2 * positionWeight[i - 1].Item2;
            }

            int sum = hashSum / 11;
            int sum1 = sum * 11;

            string number;
            if (sum1 == 10)
                number = "X";
            else
                number = sum1.ToString();

            if (number != str[10].ToString())
                return false;

            return true;
        }

        private bool isVisCheck(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && visYearCodes.Contains(str[i]) == false)
                    return false;

                else if (i > 3 && char.IsNumber(str[i]) == false)
                    return false;
            }

            return true;
        }

        private bool isVdsCheck(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i]) == false)
                    return false;

                else if ((i == str.Length - 1) && str[i] == 'X')
                {
                    return true;
                }
            }

            return true;
        }
    }
}