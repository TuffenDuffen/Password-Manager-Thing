﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    public class latinizeLOL
    {
        private static string ReverseConvertStringToLatinNumber(string numberInStrings) {
		string finalString = "";
		string[] numbers = numberInStrings.Split(new string[] { " , " }, StringSplitOptions.None);
		foreach (string test in numbers) {
			var numberBackFromLatin = ReversePrintNumberInLatin(test);
			finalString += ((char) numberBackFromLatin).ToString();
		}
		
		return finalString;
	}
	
	private static string ConvertStringToLatinNumber(string numberInString) {
		int[] IntArrayWithCharsInNumberForm = new int[numberInString.Length];
		int indexInArray = 0;
		string finalString = "";
		
		foreach (char c in numberInString) {
			IntArrayWithCharsInNumberForm[indexInArray] = Convert.ToInt16(c);	
			indexInArray++;
		}
		
		foreach (int number in IntArrayWithCharsInNumberForm) {
			string numberInLatin = PrintLatinNumber(number.ToString());
			
			finalString += numberInLatin + " , ";
		}
		
		finalString = finalString[..^3];
		return finalString;
	}
        public static string PrintLatinNumber(string numberString)
        {
            var numbersInLatin = new Dictionary<string, string>
            {
                {"1s", "Unos"},
                {"2s", "Duo"},
                {"3s", "Tres"},
                {"4s", "Quattuor"},
                {"5s", "Quinque"},
                {"6s", "Sex"},
                {"7s", "Septem"},
                {"8s", "Octo"},
                {"9s", "Novem"},
                
                {"1tenth", "Decem"},
                {"2tenth", "Viginti"},
                {"3tenth", "Triginta"},
                {"4tenth", "Quadraginta"},
                {"5tenth", "Quinquaginta"},
                {"6tenth", "Sexaginta"},
                {"7tenth", "Septuaginta"},
                {"8tenth", "Octoginta"},
                {"9tenth", "Nonaginta"},
                
                {"1hundredth", "Centum"},
                {"2hundredth", "Ducenti"},
                {"3hundredth", "Trecenti"},
                {"4hundredth", "Quadrigenti"},
                {"5hundredth", "Quingenti"},
                {"6hundredth", "Sescenti"},
                {"7hundredth", "Septingenti"},
                {"8hundredth", "Octingenti"},
                {"9hundredth", "Nongenti"},
                
                {"1thousandth", "Mille"},
                {"2thousandth", "Duo Mille"},
                {"3thousandth", "Tres Mille"},
                {"4thousandth", "Quattuor Mille"},
                {"5thousandth", "Quinque Milia"},
                {"6thousandth", "Sex Milia"},
                {"7thousandth", "Septem Milia"},
                {"8thousandth", "Octo Milia"},
                {"9thousandth", "Novem Milia"},
                
                {"1tenthousandth", "Decem Milia"},
                {"2tenthousandth", "Viginti Milia"},
                {"3tenthousandth", "triginta Milia"},
                {"4tenthousandth", "Quadraginta Milia"},
                {"5tenthousandth", "Quinquaginta Milia"},
                {"6tenthousandth", "Sexaginta Milia"},
                {"7tenthousandth", "Septuaginta Milia"},
                {"8tenthousandth", "Octoginta Milia"},
                {"9tenthousandth", "Nonaginta Milia"},
                
                {"1hundredthousandth", "Centum Milia"},
                {"2hundredthousandth", "Ducenti Milia"},
                {"3hundredthousandth", "Trecenta Millia"},
                {"4hundredthousandth", "Quadrigenti Milia"},
                {"5hundredthousandth", "Quingenta Milia"},
                {"6hundredthousandth", "Sescenti Milia"},
                {"7hundredthousandth", "Septigenti Milia"},
                {"8hundredthousandth", "Octingenti Milia"},
                {"9hundredthousandth", "Nongenti Milia"},
                
                {"1million", "Deciec centena milia"}
            };
            
            int indexInNumber = numberString.Length;

            var stringOfNumberInLatin = "";
            
            if (indexInNumber == 1 && numberString[0] == '0')
            {
                return "Nihil";
            }

            foreach (char cc in numberString)
            {
                var alteredNumberString = "";

                if (cc == '0')
                {
                    indexInNumber--;
                    continue;
                }
                
                switch (indexInNumber)
                {
                    case 1:
                    {
                        alteredNumberString += cc.ToString() + "s";
                        break;
                    }
                    case 2:
                    {
                        alteredNumberString += cc.ToString() + "tenth";
                        break;
                    }
                    case 3:
                    {
                        alteredNumberString += cc.ToString() + "hundredth";
                        break;
                    }
                    case 4:
                    {
                        alteredNumberString += cc.ToString() + "thousandth";
                        break;
                    }
                    case 5:
                    {
                        alteredNumberString += cc.ToString() + "tenthousandth";
                        break;
                    }
                    case 6:
                    {
                        alteredNumberString += cc.ToString() + "hundredthousandth";
                        break;
                    }
                }

                if (indexInNumber == 7 && cc == '1')
                {
                    alteredNumberString += cc.ToString() + "million";
                }
                else if (indexInNumber == 7 && cc != '1')
                {
                    return "Error 1: To high of a number, cant exceed 1999999";
                }

                stringOfNumberInLatin += numbersInLatin[alteredNumberString] + ",";

                indexInNumber--;
            }
            
            stringOfNumberInLatin = stringOfNumberInLatin[..^1];

            return stringOfNumberInLatin;
        }

        internal static ulong ReversePrintNumberInLatin(string stringOfNumberInLatin)
        {
            var reverseNumbersInLatin = new Dictionary<string, int>
            {
                {"Unos", 1},
                {"Duo", 2},
                {"Tres", 3},
                {"Quattuor", 4},
                {"Quinque", 5},
                {"Sex", 6},
                {"Septem", 7},
                {"Octo", 8},
                {"Novem", 9},
                
                {"Decem", 10},
                {"Viginti", 20},
                {"Triginta", 30},
                {"Quadraginta", 40},
                {"Quinquaginta", 50},
                {"Sexaginta", 60},
                {"Septuaginta", 70},
                {"Octoginta", 80},
                {"Nonaginta", 90},
                
                {"Centum", 100},
                {"Ducenti", 200},
                {"Trecenti", 300},
                {"Quadrigenti", 400},
                {"Quingenti", 500},
                {"Sescenti", 600},
                {"Septingenti", 700},
                {"Octingenti", 800},
                {"Nongenti", 900},
                
                {"Mille", 1000},
                {"Duo Mille", 2000},
                {"Tres Mille", 3000},
                {"Quattuor Mille", 4000},
                {"Quinque Milia", 5000},
                {"Sex Milia", 6000},
                {"Septem Milia", 7000},
                {"Octo Milia", 8000},
                {"Novem Milia", 9000},
                
                {"Decem Milia", 10000},
                {"Viginti Milia", 20000},
                {"triginta Milia", 30000},
                {"Quadraginta Milia", 40000},
                {"Quinquaginta Milia", 50000},
                {"Sexaginta Milia", 60000},
                {"Septuaginta Milia", 70000},
                {"Octoginta Milia", 80000},
                {"Nonaginta Milia", 90000},
                
                {"Centum Milia", 100000},
                {"Ducenti Milia", 200000},
                {"Trecenta Millia", 300000},
                {"Quadrigenti Milia", 400000},
                {"Quingenta Milia", 500000},
                {"Sescenti Milia", 600000},
                {"Septigenti Milia", 700000},
                {"Octingenti Milia", 800000},
                {"Nongenti Milia", 900000},
                
                {"Deciec centena milia", 1000000}
            };
            
            
            string[] backToNumberFromLatin = stringOfNumberInLatin.Split(',');

            for (var i = 0; i < backToNumberFromLatin.Length; i++)
            {
                backToNumberFromLatin[i] = reverseNumbersInLatin[backToNumberFromLatin[i]].ToString();
            }

            return backToNumberFromLatin.Aggregate<string, ulong>(0, (current, t) => current + (ulong) Convert.ToInt64(t));
        }

        public static string ToRoman(int number)
        {
            return number switch
            {
                < 0 or > 1999999 => throw new ArgumentOutOfRangeException("Insert value betwheen 1 and 3999"),
                < 1 => string.Empty,
                >= 1000000 => "M(|)" + "," + ToRoman(number - 1000000),
                >= 900000 => "CM(|)" + "," + ToRoman(number - 900000),
                >= 500000 => "D(|)" + "," + ToRoman(number - 500000),
                >= 400000 => "CD(|)" + "," + ToRoman(number - 400000),
                >= 100000 => "C(|)" + "," + ToRoman(number - 100000),
                >= 90000 => "XC" + "," + ToRoman(number - 90000),
                >= 50000 => "L" + "," + ToRoman(number - 50000),
                >= 40000 => "XL" + "," + ToRoman(number - 40000),
                >= 10000 => "X" + "," + ToRoman(number - 10000),
                >= 9000 => "IX" + "," + ToRoman(number - 9000),
                >= 5000 => "V" + "," + ToRoman(number - 5000),
                >= 4000 => "IV" + "," + ToRoman(number - 4000),
                >= 1000 => "M" + "," + ToRoman(number - 1000),
                >= 900 => "CM" + "," + ToRoman(number - 900),
                >= 500 => "D" + "," + ToRoman(number - 500),
                >= 400 => "CD" + "," + ToRoman(number - 400),
                >= 100 => "C" + "," + ToRoman(number - 100),
                >= 90 => "XC" + "," + ToRoman(number - 90),
                >= 50 => "L" + "," + ToRoman(number - 50),
                >= 40 => "XL" + "," + ToRoman(number - 40),
                >= 10 => "X" + "," + ToRoman(number - 10),
                >= 9 => "IX" + "," + ToRoman(number - 9),
                >= 5 => "V" + "," + ToRoman(number - 5),
                >= 4 => "IV" + "," + ToRoman(number - 4),
                _ => "I" + "," + ToRoman(number - 1)
            };
        }
    }
}
