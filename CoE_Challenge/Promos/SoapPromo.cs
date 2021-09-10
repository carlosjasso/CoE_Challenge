using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unsolved;

namespace CoE_Challenge.Promos
{
    public class SoapPromo : Promo
    {
        public override List<OrderLine> Apply(List<OrderLine> lines)
        {
            var result = new List<OrderLine>();
            int freeSoapsCount = GetFreeSoapsCount(lines);
            if (freeSoapsCount > 0)
                result.Add(GenerteOrderLine("Soap", 0, freeSoapsCount));
            return result;
        }

        private int GetFreeSoapsCount(List<OrderLine> lines)
        {
            int shampoos = lines.First(l => l.Item.Name == "Shampoo").Quantity;
            int soaps = lines.First(l => l.Item.Name == "Soap").Quantity;
            return Math.Min(shampoos, soaps);
        }
    }
}
