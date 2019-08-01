using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopAmsMakelaars.Models;
using TopAmsMakelaars.Helper;

namespace TopAmsMakelaars.CoreLogic
{
    public class TopMakelaarsOptimize
    {
        /// <summary>
        /// finding top ten Makelaars
        /// Time Complexity : O(n * 11) => O(n) where n is number for distinct makelaars
        /// Space Complexity : O(n)
        /// </summary>
        /// <param name="makelaars"></param>
        /// <returns></returns>
        public IEnumerable<Makelaar> GetTopTen(IEnumerable<Makelaar> makelaars)
        {
            //base case
            if (makelaars == null || !makelaars.Any()) return new List<Makelaar>();

            //creating count table
            var makCount = new Dictionary<int, int>();

            makCount.Add(0, 0);

            foreach (var mak in makelaars)
            {
                if (!makCount.ContainsKey(mak.Id))
                    makCount.Add(mak.Id, 0);

                makCount[mak.Id]++;
            }


            //temp array for storing top ten makelaars ids
            int[] top = new int[11];

            //finding top 10
            foreach (var item in makCount)
            {
                top[10] = item.Key;

                for (int i = 10; i > 0; i--)
                {
                    if (makCount[top[i]] > makCount[top[i - 1]])
                        Swap(top, i, i - 1);
                }
            }

            //final result
            var result = new List<Makelaar>();
            var common = new Common();
            var lookUp = common.GetLookup(makelaars);

            for (int i = 0; i < 10; i++)
            {
                if (top[i] == 0) break;

                result.Add(lookUp[top[i]]);
            }


            return result;
        }     

        private void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }     

     
    }
}
