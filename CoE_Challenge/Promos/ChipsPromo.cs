using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unsolved;

namespace CoE_Challenge.Promos
{
    public class ChipsPromo : Promo
    {
        public override List<OrderLine> Apply(List<OrderLine> lines)
        {
            var result = new List<OrderLine>();
            int freeChipsCount = GetFreeChipsCount(lines);
            if (freeChipsCount > 0)
                result.Add(GenerteOrderLine("Potato chips", 0, freeChipsCount));
            return result;
        }

        private int GetFreeChipsCount(List<OrderLine> lines)
        {
            var sodas = lines.First(l => l.Item.Name == "Soda (2 lts)");
            var chips = lines.First(l => l.Item.Name == "Potato chips");
            return Math.Min(sodas.Quantity, chips.Quantity);
        }
    }
}
