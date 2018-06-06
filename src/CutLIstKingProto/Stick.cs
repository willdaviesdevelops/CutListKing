using System.Collections.Generic;
using System.Linq;

namespace CutListKing
{
    /// <summary>
    /// Stick represents a whole work piece.
    /// Example: 16 foot piece of shoe moulding.
    /// </summary>
    public class Stick
    {
        public Stick(int length)
        {
            Length = length;
            CutItemCollection = new List<CutItem>();
        }

        public int Length { get; set; }

        public int RemainingSpace => Length - CutItemCollection.Sum(wp => wp.CutItemLength);
        public List<CutItem> CutItemCollection {get; set;}

        public void AddCutItemToStick(CutItem cutItem)
        {
            CutItemCollection.Add(cutItem);
        }

        // todo: sort longest to shortest
        // todo: sort shortest to longest
    }
}