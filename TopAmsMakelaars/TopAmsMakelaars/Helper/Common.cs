using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopAmsMakelaars.Models;

namespace TopAmsMakelaars.Helper
{
    public class Common
    {
        public  Dictionary<int, Makelaar> GetLookup(IEnumerable<Makelaar> makelaars)
        {
            var lookup = new Dictionary<int, Makelaar>();

            foreach (var m in makelaars)
            {
                if (lookup.ContainsKey(m.Id)) continue;

                lookup.Add(m.Id, m);
            }

            return lookup;

        }
    }
}
