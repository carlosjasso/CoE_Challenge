using System;
using System.Collections.Generic;
using System.Text;
using unsolved;

namespace CoE_Challenge.Promos
{
    public abstract class Promo
    {
        public abstract List<OrderLine> Apply(List<OrderLine> lines);

        internal OrderLine GenerteOrderLine(string name, decimal price, int quantity)
        {
            return new OrderLine
            {
                Item = new Item { Name = name, Price = price },
                Quantity = quantity
            };
        }
    }
}
