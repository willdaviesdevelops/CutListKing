using System;
using System.Collections.Generic;
using System.Linq;

namespace CutListKing
{
    public class CutListStacker
    {
        private readonly int _stickLength; // this assumes that all sticks are the same length;

        public CutListStacker(int stickLength)
        {
            _stickLength = stickLength;
            StickCollection = new List<Stick>();
        }

        public List<Stick> StickCollection { get; set; }
        public List<CutItem> UnassignedCutItems { get; set; }

        public void AssignCutItemToStick(CutItem cutItem)  // this is like a push (or store) in a push-pop scenario;
        {
            if (StickCollection.Capacity <= 0)
            {
                StickCollection.Add(new Stick(_stickLength));
            }

            var stickIsPlaced = false;
            foreach (var stick in StickCollection)
            {
                // assigning the condition to the variable is self-describing code; here it describes the intent w/o a comment per-se
                var cutItemWillFitInStick = (cutItem.CutItemLength <= stick.RemainingSpace); // if it fits it ships
                if (cutItemWillFitInStick)
                {
                    stick.AddCutItemToStick(cutItem);
                    stickIsPlaced = true;
                    break;
                }
            }

            if (!stickIsPlaced)
            {
                var freshStick = new Stick(_stickLength);
                if (cutItem.CutItemLength <= freshStick.RemainingSpace)
                {
                    freshStick.AddCutItemToStick(cutItem);
                    StickCollection.Add(freshStick);
                    stickIsPlaced = true;
                }
            }

            /*
             todo: Unassigned CutItems; what if the cut is too large for the stick????
             Example 18 foot cut for a 16 foot stick.
             */
            if (!stickIsPlaced)
            {
                UnassignedCutItems.Add(cutItem);
                stickIsPlaced = true;
            }
        }

        public void PrettyPrint() // depcrecated
        {
            var stickNumber = 0;
            foreach (var stick in StickCollection)
            {
                Console.WriteLine($"Stick {stickNumber += 1}");
                Console.WriteLine("----------------------------");
                Console.WriteLine();
                foreach (var cutItem in stick.CutItemCollection)
                {
                    Console.WriteLine($"{cutItem.CutItemCode.PadRight(10)} \t\t- {cutItem.CutItemLength}");
                }

                var totalUsed = stick.CutItemCollection.Sum(wp => wp.CutItemLength);
                var totalRemaining = stick.Length - stick.CutItemCollection.Sum(wp => wp.CutItemLength);
                Console.WriteLine($"Total used: {totalUsed} -=- remaining {totalRemaining}");
                Console.WriteLine("**************************************************");
                Console.WriteLine("**************************************************");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}