using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopAmsMakelaars.Models;

namespace TopAmsMakelaars.Test
{
    public class TestData
    {

        Dictionary<int, Makelaar> source = new Dictionary<int, Makelaar>();

        public TestData()
        {
            source.Add(1, new Makelaar() { Id = 1, Name = "A" });
            source.Add(2, new Makelaar() { Id = 2, Name = "B" });
            source.Add(3, new Makelaar() { Id = 3, Name = "C" });
            source.Add(4, new Makelaar() { Id = 4, Name = "D" });
            source.Add(5, new Makelaar() { Id = 5, Name = "E" });
            source.Add(6, new Makelaar() { Id = 6, Name = "F" });
            source.Add(7, new Makelaar() { Id = 7, Name = "G" });
            source.Add(8, new Makelaar() { Id = 8, Name = "H" });
            source.Add(9, new Makelaar() { Id = 9, Name = "I" });
            source.Add(10, new Makelaar() { Id = 10, Name = "J" });
            source.Add(11, new Makelaar() { Id = 11, Name = "K" });
            source.Add(12, new Makelaar() { Id = 12, Name = "L" });
            source.Add(13, new Makelaar() { Id = 13, Name = "M" });
            source.Add(14, new Makelaar() { Id = 14, Name = "N" });
            source.Add(15, new Makelaar() { Id = 15, Name = "O" });
            source.Add(16, new Makelaar() { Id = 16, Name = "P" });
            source.Add(17, new Makelaar() { Id = 17, Name = "Q" });
            source.Add(18, new Makelaar() { Id = 18, Name = "R" });
            source.Add(19, new Makelaar() { Id = 19, Name = "S" });
            source.Add(20, new Makelaar() { Id = 20, Name = "T" });
            source.Add(21, new Makelaar() { Id = 21, Name = "U" });
            source.Add(22, new Makelaar() { Id = 22, Name = "V" });
            source.Add(23, new Makelaar() { Id = 23, Name = "W" });
            source.Add(24, new Makelaar() { Id = 24, Name = "X" });
            source.Add(25, new Makelaar() { Id = 25, Name = "Y" });
            source.Add(26, new Makelaar() { Id = 26, Name = "Z" });
        }



        public IEnumerable<Makelaar> GetTestData(int size)
        {
            var testData = new List<Makelaar>();
            Random rnd = new Random();
            for (int i = 1; i <= size; i++)
            {
                int alpha = rnd.Next(1, 27);
                testData.Add(source[alpha]);
            }

            return testData;
        }
            







    }
}
