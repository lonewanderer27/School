using System;
using System.Collections.Generic;

// 1) Separate cs file for the SchoolSupply class
// where a) add item and b) display inventory methods are implemented
namespace School
{
    /// <summary>
    /// Represents a school supply with a list of items.
    /// </summary>
    public class SchoolSupply
    {
        /// <summary>
        /// A 2-dimensional, always 3 column, infinite row list of items.
        /// </summary>
        private List<List<Item>> _items;

        /// <summary>
        /// Initializes a new instance of the SchoolSupply class.
        /// </summary>
        public SchoolSupply()
        {
            _items = new List<List<Item>>();
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        public List<List<Item>> items
        {
            get { return _items; }
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>A 2-dimensional list of items.</returns>
        public List<List<Item>> GetItems()
        {
            return this._items;
        }

        /// <summary>
        /// Displays the current inventory.
        /// </summary>
        public void DisplayInventory()
        {
            Console.WriteLine("Current inventory: ");
            Console.WriteLine("===================================");

            foreach(List<Item> row in _items)
            {
                foreach(Item item in row)
                {
                    Console.WriteLine($"{item.Name} (₱{item.Price}) x {item.Quantity}");
                    Console.WriteLine("----------------------------------");
                }
            }
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="price">The price of the item.</param>
        /// <param name="quantity">The quantity of the item.</param>
        private void AddItem(string name, double price, int quantity)
        {
            Item newItem = new Item(name, price, quantity);
            if (_items.Count == 0 || _items[_items.Count - 1].Count == 3)
            {
                _items.Add(new List<Item> { newItem });
            }
            else
            {
                _items[_items.Count - 1].Add(newItem);
            }
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        private void AddItem(Item item)
        {
            if (_items.Count == 0 || _items[_items.Count - 1].Count == 3)
            {
                _items.Add(new List<Item> { item });
            }
            else
            {
                _items[_items.Count - 1].Add(item);
            }
        }

        /// <summary>
        /// Fills the _items list with a specified number of random items.
        /// </summary>
        /// <param name="fillHowManyItems">The number of random items to add to the _items list. Default is 9.</param>
        public void FillWithRandomItems(int fillHowManyItems = 9)
        {
            for (int i = 0; i < fillHowManyItems; i++)
            {
                AddItem(Item.GenerateRandomItem());
            }
        }

        /// <summary>
        /// Displays the items in a table.
        /// </summary>
        public void DisplayItemsInTable()
        {
            Console.WriteLine("Current inventory: ");
            Console.WriteLine("===================================");
            Console.WriteLine("-----------------------------------");

            foreach (var row in _items)
            {
                Console.Write("| ");
                for (var i = 0; i < 3; i++)
                {
                    if (i < row.Count)
                    {
                        Console.Write("X".PadRight(9) + " | ");
                    }
                    else
                    {
                        Console.Write("O".PadRight(9) + " | ");
                    }
                }
                Console.WriteLine("\n-----------------------------------");
            }
        }

        /// <summary>
        /// Asks the user for items to add to the list.
        /// </summary>
        public void AskForItems()
        {
            // ask the no. of items to add
            Console.Write("How many items would you like to add? ");
            int toBeAddedItems = 0;
            try {
                toBeAddedItems = int.Parse(Console.ReadLine());
            }
            catch {
                Console.WriteLine("Invalid amount of items. Please try again!");
                return;
            }

            for (int i = 0; i < toBeAddedItems; i++)
            {
                string name;
                double price;
                int qty;
                Console.WriteLine($"Item #{i + 1}");

                // ask for details
                Console.Write("Name: ");
                name = Console.ReadLine();

                Console.Write("Price: ");
                try
                {
                    price = Double.Parse(Console.ReadLine());
                    // check if price is a positive number
                    if (price <= 0)
                    {
                        Console.WriteLine("Price must be a positive number. Aborting...\n");
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid price. Aborting...\n");
                    return;
                }

                Console.Write("Quantity: ");
                try
                {
                    qty = int.Parse(Console.ReadLine());
                    // check if qty is a positive number
                    if (qty <= 0)
                    {
                        Console.WriteLine("Quantity must be a positive number. Aborting...\n");
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid quantity. Aborting...\n");
                    return;
                }

                // create the item then add it to the list of items
                AddItem(name, price, qty);
            }
        }
    }
}