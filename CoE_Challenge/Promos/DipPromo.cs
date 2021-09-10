using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unsolved;

namespace CoE_Challenge.Promos
{
    public class DipPromo : Promo
    {
        public override List<OrderLine> Apply(List<OrderLine> lines)
        {
            var result = new List<OrderLine>();
            int nachos = GetNachosCount(lines);
            if (nachos >= 2)
                result.Add(GenerteOrderLine("Dip", 0, 1));
            return result;
        }

        private int GetNachosCount(List<OrderLine> lines)
        {
            var nachos = lines.First(l => l.Item.Name == "Nachos");
            return nachos.Quantity;
        }
    }
}
