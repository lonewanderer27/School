using System;
using System.Collections.Generic;

namespace School
{
    public class Item
    {
        public readonly string Name;
        public readonly double Price;
        public readonly int Quantity;

        public Item(string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
        
        /// <summary>
        /// Generates a random Item.
        /// </summary>
        /// <returns>A new Item with a random name, price, and quantity.</returns>
        public static Item GenerateRandomItem()
        {
            var random = new Random();
            var names = new List<string>
            {
                "Pencil", 
                "Pen", 
                "Notebook", 
                "Eraser", 
                "Ruler", 
                "Scissor", 
                "Glue", 
                "Marker", 
                "Crayons", 
                "Calculator"
            };

            var randomName = names[random.Next(names.Count)];
            var randomPrice = Math.Round(random.NextDouble() * (100 - 1) + 1, 2); // Random price between 1 and 100
            var randomQuantity = random.Next(1, 101); // Random quantity between 1 and 100

            return new Item(randomName, randomPrice, randomQuantity);
        }
    }
}
