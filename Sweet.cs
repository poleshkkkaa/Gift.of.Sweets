using System;

namespace лаба4_2
{
    public abstract class Sweet
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double SugarContent { get; set; }

        protected Sweet(string name, double weight, double sugarContent)
        {
            Name = name;
            Weight = weight;
            SugarContent = sugarContent;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
