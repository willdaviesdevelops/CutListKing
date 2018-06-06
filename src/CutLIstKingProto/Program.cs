using System;
using System.Collections.Generic;
using System.Linq;

namespace CutListKing
{
    class Program
    {
        private static void Main(string[] args)
        {
            const int sixteenFeetInInches = 16 * 12;
            var cutItemCollection = GetCutList();
            Console.WriteLine($"The shoe moulding in this case is 16 feet or a total length of {sixteenFeetInInches} inches.{Environment.NewLine}");
            var cutListStack = new CutListStacker(sixteenFeetInInches);

            // While the following code could be simplified ( cutItemCollection.ForEach() ), it remains in this loop to be more maintainable.
            foreach (var cutItem in cutItemCollection)
            {
                cutListStack.AssignCutItemToStick(cutItem);
            }

            PrettyPrint(cutListStack.StickCollection);
            Console.ReadKey();
        }

        private static void PrettyPrint(IEnumerable<Stick> stickCollection)
        {
            Console.WriteLine($"Total sticks required: {stickCollection.Count()}{Environment.NewLine}");
            var stickNumber = 0;
            foreach (var stick in stickCollection)
            {
                Console.WriteLine($"Stick {stickNumber += 1}");
                Console.WriteLine($"----------------------------{Environment.NewLine}");
                foreach (var cutItem in stick.CutItemCollection)
                {
                    Console.WriteLine($"{cutItem.CutItemCode.PadRight(10)} \t\t- {cutItem.CutItemLength.ToString().PadLeft(6)}");
                }

                // these local variables are extracted from the formatting to adhere to Single responsibility.
                var totalUsed = stick.CutItemCollection.Sum(wp => wp.CutItemLength);
                var totalRemaining = stick.Length - stick.CutItemCollection.Sum(wp => wp.CutItemLength);
                Console.WriteLine($"{Environment.NewLine}Total used: {totalUsed} -=- remaining {totalRemaining}{Environment.NewLine}{Environment.NewLine}");
            }
        }

        /// <summary>
        /// Initially this static list would come from a data repository.  --> Repo pattern FTW !!!
        /// </summary>
        /// <returns>Collection of CutItem</returns>
        private static List<CutItem> GetCutList()
        {
            var workPieces = new List<CutItem>
            {
                /*
                new CutItem("alpha", 123),
                new CutItem("bravo", 12),
                new CutItem("charlie", 144),
                new CutItem("delta", 24),
                */

                new CutItem("LR South",162),
                new CutItem("LR East",176),
                new CutItem("LR North",138),
                new CutItem("LR West",96),
                new CutItem("LR Extra 1",5),
                new CutItem("LR Extra 2",15),
                new CutItem("LR Closet",24),
                new CutItem("LR Closet",24),
                new CutItem("LR Closet",60),
                new CutItem("Hall Closet",12),
                new CutItem("Hall Closet",12),
                new CutItem("Hall Closet",36),
                new CutItem("Hall South",38),
                new CutItem("Hall South",90),
                new CutItem("Hall South",20),
                new CutItem("Hall West",4),
                new CutItem("Hall West",4),
                new CutItem("Hall North",29),
                new CutItem("Hall North",150),
                new CutItem("BR-1-Closet",24),
                new CutItem("BR-1-Closet",24),
                new CutItem("BR-1-Closet",24),
                new CutItem("BR-1-Closet",72),
                new CutItem("BR-1-East",2),
                new CutItem("BR-1-East",22),
                new CutItem("BR-1-East",84),
                new CutItem("BR-1-South",118),
                new CutItem("BR-1-West",133),
                new CutItem("BR-1-North",84),
                new CutItem("BR-2-North",2),
                new CutItem("BR-2-East",94),
                new CutItem("BR-2-East",28),
                new CutItem("BR-2-East",9),
                new CutItem("BR-2-East",3),
                new CutItem("BR-2-South",127),
                new CutItem("BR-2-West",116),
                new CutItem("BR-2-North-b",83),
                new CutItem("BR-2-East",19),
                new CutItem("BR-2-East",37),
                new CutItem("BR-2-Closet",10),
                new CutItem("BR-2-Closet",28),
                new CutItem("BR-2-Closet",25),
                new CutItem("BR-2-Closet",28),
                new CutItem("BR-2-Closet",10),
                new CutItem("BR-3-South",48),
                new CutItem("BR-3-South",24),
                new CutItem("BR-3-West",144),
                new CutItem("BR-3-North",160),
                new CutItem("BR-3-East",4),
                new CutItem("BR-3-East",116),
                new CutItem("BR-3-East",24),
                new CutItem("MBath",4),
                new CutItem("MBath",67),
                new CutItem("MBath",6),
                new CutItem("MBath",20),
                new CutItem("MBath",33),
                new CutItem("MBath",22),
                new CutItem("MBath",25),
                new CutItem("MBath",40),
                new CutItem("MBath",21),
                new CutItem("MBath",27),
                new CutItem("MBath",3),
                new CutItem("MBath",6),
                new CutItem("MBath",38),
                new CutItem("K",77),
                new CutItem("K",144),
                new CutItem("K",87),
                new CutItem("K",49),
                new CutItem("K",40),
                new CutItem("K",36),
                new CutItem("K",12),
                new CutItem("BO",32),
                new CutItem("BO",105),
                new CutItem("BO",144),
                new CutItem("BO",144),
                new CutItem("BO",32),
                new CutItem("Cabinet",40),
                new CutItem("Cabinet",21),
                new CutItem("Cabinet",27),
                new CutItem("Cabinet",3),
                new CutItem("Cabinet",6),
                new CutItem("Cabinet",38)
                };

            return workPieces;
        }
    }
}
