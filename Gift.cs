using System;

namespace лаба4_2
{
    public class Gift
    {
        public List<Sweet> Sweets { get; set; }

        public Gift()
        {
            Sweets = new List<Sweet>();
        }

        public void AddSweet(Sweet sweet)
        {
            Sweets.Add(sweet);
        }

        public List<Sweet> FindBestFitBySugarContent(double sugarContent)
        {
            return Sweets.Where(s => Math.Abs(s.SugarContent - sugarContent) <= 10).ToList();
        }

        public double TotalWeightForSelectedSweets(List<Sweet> selectedSweets)
        {
            return selectedSweets.Sum(s => s.Weight);
        }

        public void ShowSweets()
        {
            foreach (var sweet in Sweets)
            {
                Console.WriteLine(sweet);
            }
        }
    }
}
