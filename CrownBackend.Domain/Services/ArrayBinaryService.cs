using CrownBackend.Domain.DTOs;
using CrownBackend.Domain.Interfaces.Services;
using CrownBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrownBackend.Domain.Services
{
    public class ArrayBinaryService : IArrayBinaryService
    {
        public ConvertArrayBinaryResponse ConvertToBinaryOrdered(ConvertArrayBinaryRequest arrayBinay)
        {
            string[] numberIn = arrayBinay.ArrayForOrdered
                .Replace("[", "")
                .Replace("]", "")
                .Split(',');
            Dictionary<string, string> numberBinary = ConvertFromIntegerToBinary(numberIn);
            string[] numbersOrdered = OrderArrayBinary(numberBinary);

            return new ConvertArrayBinaryResponse { ArrayOrdered = $"[{String.Join(',', numbersOrdered)}]" };
        }

        private Dictionary<string, string> ConvertFromIntegerToBinary(string[] numbers)
        {
            Dictionary<string, string> numbersBinary = new Dictionary<string, string>();
            int numAux;

            for (int i = 0; i < numbers.Length; i++)
            {
                numAux = Convert.ToInt32(numbers[i]);
                numbersBinary.Add(numbers[i], Convert.ToString(numAux, 2));
            }

            return numbersBinary;
        }

        private string[] OrderArrayBinary(Dictionary<string, string> numbersBinaries)
        {
            List<int> arrayNumbersOne = new List<int>();
            List<string> arrayNumbersOneAux = new List<string>();
            Dictionary<string, int> numbersBinariesAux = new Dictionary<string, int>();
            int i = 0;

            foreach (KeyValuePair<string, string> entry in numbersBinaries)
            {
                arrayNumbersOne.Add(CountOnes(entry.Value));
                numbersBinariesAux.Add(entry.Key, arrayNumbersOne[i]);
                i++;
            }

            arrayNumbersOne.Sort();

            foreach (var item in arrayNumbersOne)
            {
                string numberAux = numbersBinariesAux.FirstOrDefault(x => x.Value == item).Key;
                numbersBinariesAux.Remove(numberAux);

                arrayNumbersOneAux.Add(numberAux);
            }

            return arrayNumbersOneAux.ToArray();
        }

        private int CountOnes(string arrayBinary)
        { 
            return Regex.Matches(arrayBinary, "1").Count();
        }
    }
}
