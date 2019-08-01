using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopAmsMakelaars.Models;
using TopAmsMakelaars.Helper;


namespace TopAmsMakelaars.CoreLogic
{

    class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }

    public class TopMakelaars
    {
        /// <summary>
        /// max heap based implementation
        /// Time Complexity => O(nlogn) where n is number for distinct makelaars
        /// Space Complexity => O(n)
        /// </summary>
        /// <param name="makelaars"></param>
        /// <returns></returns>
        public IEnumerable<Makelaar> GetTopTen(IEnumerable<Makelaar> makelaars)
        {
            //base case
            if (makelaars == null || !makelaars.Any()) return new List<Makelaar>();

            //creating count table
            var makCount = new Dictionary<int, int>();

            foreach (var mak in makelaars)
            {
                if (!makCount.ContainsKey(mak.Id))
                    makCount.Add(mak.Id, 0);

                makCount[mak.Id]++;
            }

            //building max heap
            //further optimization would be to set max heap size to 10 
            //unfortunately C# does not provide feature to set sorted dictionary size
            var maxHeap = new SortedDictionary<int, List<Makelaar>>(new DescendingComparer<int>());            
            var common = new Common();
            var lookup = common.GetLookup(makelaars);

            foreach (var mak in makCount)
            {
                if (!maxHeap.ContainsKey(mak.Value))
                    maxHeap.Add(mak.Value, new List<Makelaar>());

                maxHeap[mak.Value].Add(lookup[mak.Key]);
            }

            //final result           
            var result = new List<Makelaar>();
            var values = 10;

            foreach (var item in maxHeap)
            {
                result.AddRange(item.Value.Take(values));

                values -= item.Value.Count;

                if (values <= 0) break;

            }

            return result;

        }

  
    }
}
