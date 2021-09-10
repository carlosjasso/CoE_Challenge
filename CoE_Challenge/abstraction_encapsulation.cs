//The following code belongs to an online shopping cart
//Your job is to make the code able to handle the following business rules:

//add a promotional 2X1 discount for every product but any snack
//for each bundle of 1 shampoo and 1 soap you get another free soap
//when you buy 2 bags of nachos or more you get 1 dip for free
//for each bundle of 1 2 lts soda and 1 bag of chips, you get another bag of chips for free

//restrictions: 
//no more than 5 lines per method

//Please apply the OOP tenets: Encapsulation, Polymorphism, 
//Abstraction and Inheritance as you see fit to make this code
//object oriented


using CoE_Challenge.Promos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace unsolved
{
    public class Test
    {
        public static void Main()
        {
            
            var shampoo = new Item { Name = "Shampoo", Price = 12.95m };
            var soap = new Item { Name = "Soap", Price = 8m };
            var nachos = new Item{Name ="Nachos", Price = 7m};
            var soda = new Item{Name ="Soda (2 lts)", Price = 13.50m};
            var chips = new Item{Name ="Potato chips", Price = 10m};
            var dip = new Item { Name = "Dip", Price = 10m };
            
            var order = new Order();
            order.AddLine(new OrderLine { Item = shampoo, Quantity = 2 });
            order.AddLine(new OrderLine { Item = shampoo, Quantity = 2 });
            order.AddLine(new OrderLine { Item = soap, Quantity = 5 });
            order.AddLine(new OrderLine{Item = nachos, Quantity = 2});
            order.AddLine(new OrderLine{Item = soda, Quantity = 1});
            order.AddLine(new OrderLine{Item = chips, Quantity = 1});

            
            decimal total = 0;
            foreach (var line in order.GetLines())
            {
                total += line.Quantity * line.Item.Price;
            }

            decimal tax = total * 0.16m;//total * 0.16m;
            Console.WriteLine($"the expected cost is 101.3840. The actual cost is {total + tax}");

            // Present a visual representation of the order lines
            var options = new JsonSerializerOptions { WriteIndented = true };
            string orderLines = JsonSerializer.Serialize(order.GetLines(), options);
            Console.WriteLine($"\"OrderLines\": {orderLines}");
        }
    }

    public class Order
    {
        private List<OrderLine> _lines;

        public Order()
        {
            _lines = new List<OrderLine>();
        }

        public void AddLine(OrderLine line)
        {
            int count = _lines.Count(l => l.Item.Name == line.Item.Name);
            if (count == 0)
                _lines.Add(line);
            else
                IncrementQuantity(line); // Prevents having duplicates in _lines
        }

        private void IncrementQuantity(OrderLine line)
        {
            var item = _lines.First(l => l.Item.Name == line.Item.Name);
            int index = _lines.IndexOf(item);
            _lines[index].Quantity += line.Quantity;
        }

        public List<OrderLine> GetLines()
        {
            var lines = new List<OrderLine>(new DiscountPromo().Apply(_lines));
            lines.AddRange(new SoapPromo().Apply(_lines));
            lines.AddRange(new DipPromo().Apply(_lines));
            lines.AddRange(new ChipsPromo().Apply(_lines));
            return lines;
        }
    }

    public class OrderLine
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }


    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}