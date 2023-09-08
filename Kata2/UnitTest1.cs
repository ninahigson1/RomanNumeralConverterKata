using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Kata2
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]


        public void given_units_return_numeral(int number, string numeral)
        {
            
            var result = RomanNumeralConvertor.Convert(number);

            Assert.Equal(numeral, result);
        }

        [Theory]
        [InlineData(10, "X")]
        [InlineData(20, "XX")]
        [InlineData(30, "XXX")]
        [InlineData(40, "XL")]
        [InlineData(50, "L")]
        [InlineData(60, "LX")]
        [InlineData(70, "LXX")]
        [InlineData(80, "LXXX")]
        [InlineData(90, "XC")]


        public void given_tens_return_numeral(int number, string numeral)
        {

            var result = RomanNumeralConvertor.Convert(number);

            Assert.Equal(numeral, result);
        }

        [Theory]
        [InlineData(100, "C")]
        [InlineData(200, "CC")]
        [InlineData(300, "CCC")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(600, "DC")]
        [InlineData(700, "DCC")]
        [InlineData(800, "DCCC")]
        [InlineData(900, "CM")]


        public void given_hundreds_return_numeral(int number, string numeral)
        {

            var result = RomanNumeralConvertor.Convert(number);

            Assert.Equal(numeral, result);
        }

        [Theory]
        [InlineData(1000, "M")]
        [InlineData(2000, "MM")]
        [InlineData(3000, "MMM")]
        


        public void given_thousands_return_numeral(int number, string numeral)
        {

            var result = RomanNumeralConvertor.Convert(number);

            Assert.Equal(numeral, result);
        }

        [Theory]
        [InlineData(39, "XXXIX")]
        [InlineData(246, "CCXLVI")]
        [InlineData(789, "DCCLXXXIX")]
        [InlineData(2421, "MMCDXXI")]
        public void given_complex_numbers_return_numeral(int number, string numeral)
        {

            var result = RomanNumeralConvertor.Convert(number);

            Assert.Equal(numeral, result);
        }
    }

    public static class RomanNumeralConvertor
    {
        public static string Convert(int number) //2409
        {

            string numeral = string.Empty;

            numeral += CalculateThousands(number);

            numeral += CalculateHundreds(number);

            numeral += CalculateTens(number);

            numeral += CalculateUnits(number);

            return numeral;
        }

        private static string CalculateThousands(int number)
        {
            int numberOfThousands = number / 1000;

            return numberOfThousands switch
            {
                1 => "M",
                2 => "MM",
                3 => "MMM",
                _ => ""
            };
        }

        private static string CalculateHundreds(int number)
        {
            int numberOfThousands = number / 1000;

            int numberOfHundreds = (number - (numberOfThousands * 1000)) / 100;
            return numberOfHundreds switch
            {
                1 => "C",
                2 => "CC",
                3 => "CCC",
                4 => "CD",
                5 => "D",
                6 => "DC",
                7 => "DCC",
                8 => "DCCC",
                9 => "CM",
                _ => ""
            };
        }

        private static string CalculateTens(int number)
        {
            int numberOfThousands = number / 1000;

            int numberOfHundreds = (number - (numberOfThousands * 1000)) / 100;

            int numberOfTens = (number - (numberOfThousands * 1000) - (numberOfHundreds * 100)) / 10;

            return numberOfTens switch
            {
                1 => "X",
                2 => "XX",
                3 => "XXX",
                4 => "XL",
                5 => "L",
                6 => "LX",
                7 => "LXX",
                8 => "LXXX",
                9 => "XC",
                _ => ""
            };
        }

        private static string CalculateUnits(int number)
        {
            int numberOfThousands = number / 1000;

            int numberOfHundreds = (number - (numberOfThousands * 1000)) / 100;

            int numberOfTens = (number - (numberOfThousands * 1000) - (numberOfHundreds * 100)) / 10;

            int numberOfUnits = (number - (numberOfThousands * 1000) - (numberOfHundreds * 100) - (numberOfTens * 10));

            return numberOfUnits switch
            {
                1 => "I",
                2 => "II",
                3 => "III",
                4 => "IV",
                5 => "V",
                6 => "VI",
                7 => "VII",
                8 => "VIII",
                9 => "IX",
                _ => ""
            };
        }
    }
}