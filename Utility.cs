using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWeek7
{
    public class Utility
    {
        public double GetFloor(double input)
        {
            return Math.Floor(input);
        }

        public string ConcatName(string firstName, string lastName)
        {
            return $"{firstName}, {lastName}";
        }

        public string HashString(string input)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                var bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public bool IsPrime(int input)
        {
            if (input <= 1) return false;
            if (input == 2) return true;
            if (input % 2 == 0) return false;

            var limit = Math.Ceiling(Math.Sqrt(input));

            for (int i = 3; i <= limit; i++)
            {
                if (input % i == 0) return false;
            }

            return true;
        }

        public List<int> GetNonPrimeDivisors(int input)
        {
            List<int> found = new List<int>();

            var limit = Math.Ceiling((double)input / 2);

            for (int i = 2; i <= limit; i++)
            {
                if (input % i == 0 && !IsPrime(i))
                {
                    found.Add(i);
                }
            }

            return found;
        }

        public double GetDivisionFloor(int a, int b)
        {
            double numerator = a > b ? a : b;
            double denominator = a > b ? b : a;

            if (denominator == 0) return 0;

            return Math.Floor(numerator / denominator);
        }

        public Dictionary<int, int> GetDivisorDictionary(int input)
        {
            List<int> divisors = GetNonPrimeDivisors(input).OrderBy(x => x).ToList();
            Dictionary<int, int> output = new Dictionary<int, int>();

            int key = 1;

            foreach (var divisor in divisors)
            {
                output.Add(key, divisor);
                key += 2;
            }

            return output;
        }
    }
}
