using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unsolved;

namespace CoE_Challenge.Promos
{
    public class DiscountPromo : Promo
    {
        private readonly string[] _promoItems = { "Shampoo", "Soap" };

        public override List<OrderLine> Apply(List<OrderLine> lines)
        {
            var result = new List<OrderLine>();
            foreach (var line in lines)
                result.Add(Eval(line));
            return result;
        }

        private OrderLine Eval(OrderLine line)
        {
            if (!_promoItems.Contains(line.Item.Name))
                return line;
            int inPromo = line.Quantity >= 2 ? line.Quantity / 2 : 0;
            return GenerteOrderLine(line.Item.Name, line.Item.Price, line.Quantity - inPromo);
        }
    }
}
