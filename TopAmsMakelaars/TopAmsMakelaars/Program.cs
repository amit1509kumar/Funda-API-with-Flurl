using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopAmsMakelaars.Models;
using TopAmsMakelaars.CoreLogic;

namespace TopAmsMakelaars
{
    class Program
    {
        static void Main(string[] args) => Run();        

        static void Run()
        {
            Console.WriteLine("Getting Makelaars...");

            try
            {
                var repo = new FundaAPIRepo();
                var makelaars = new List<Makelaar>();
                var makelaarsWithTuin = new List<Makelaar>();

                //getting makelaars data for first 10 pages
                for (int i = 1; i < 11; i++)
                {
                    var mak = repo.GetMakelaars(i, 25)?.Result?.Makelaars;

                    var makWithTuin = repo.GetMakelaarsWithTuin(i, 25)?.Result?.Makelaars;

                    if (mak != null)
                        makelaars.AddRange(mak);

                    if (makWithTuin != null)
                        makelaarsWithTuin.AddRange(makWithTuin);
                }             

                Process(makelaars, "makelaars");

                Console.WriteLine("================================================");

                Process(makelaarsWithTuin, "makelaars with tuin");
            }
            catch (Exception ex)
            {
                Console.Write($"Exception {ex.Message}");
            }
        }

        static void Process(List<Makelaar> makelaars, string message)
        {
            var validMakelaars = makelaars?.Where(m => m.Id > 0);

            if (validMakelaars == null || validMakelaars.Count() == 0)
            {
                Console.WriteLine($"No result found for {message}.");
                return;
            }

            Console.WriteLine($"{validMakelaars.Count()} {message} found...");

            Console.WriteLine($"Showing Top 10 {message} in Amsterdam.");

            int i = 0;

            Console.WriteLine($"No.  Id   Name");

            var coreLogic = new TopMakelaarsOptimize();

            foreach (var mak in coreLogic.GetTopTen(validMakelaars))
            {
                Console.WriteLine($"{++i} {mak.Id} {mak.Name}");
            }
        }

       
    }
}
