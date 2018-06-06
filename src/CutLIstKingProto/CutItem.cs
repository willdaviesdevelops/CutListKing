namespace CutListKing
{
    public class CutItem
    {
        public CutItem(string cutItemCode, int cutItemLength)
        {
            CutItemCode = cutItemCode;
            CutItemLength = cutItemLength;
        }

        public string CutItemCode { get; set; }
        public int CutItemLength { get; set; }
    }
}