using System;

namespace School
{
    class MainClass
    {
        /// <summary>
        /// Constant that allows the program to fill the inventory with random items for testing purposes.
        /// </summary>
        private const bool TESTING_MODE = true;

        /// <summary>
        /// Displays the main menu of the application.
        /// </summary>
        static void DisplayMenu()
        {
            Console.WriteLine("Welcome to the AdU Supplies Store!");
            Console.WriteLine("Please select an option");
            Console.WriteLine("1. Add Items to inventory");
            Console.WriteLine("2. Display Inventory");
            Console.WriteLine("3. Exit");
            if (TESTING_MODE)
            {
                Console.WriteLine("4. Fill with random items");
            }
            Console.Write("Enter your choice: ");
        }

        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        public static void Main(string[] args)
        {
            // Instantiate SchoolSupplies
            SchoolSupply SSupply = new SchoolSupply();

            // Ask for the user's choice
            // Don't quit unless they enter 3

            // Use a while loop to keep the program running until the user chooses to exit.
            int choice = 0;
            while (choice != 3)
            {
                DisplayMenu();
                // Use Console.ReadLine() to read the entire line as a string
                string input = Console.ReadLine();

                // Parse the input to an integer
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid option, please try again!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        {
                            // Add items to inventory
                            SSupply.AskForItems();
                            break;
                        }

                    case 2:
                        {
                            // Display inventory
                            SSupply.DisplayInventory();
                            break;
                        }
                    case 3:
                        {
                            // Quit immediately without prompts
                            break;
                        }
                    case 4:
                        {
                            // Only execute if TESTING_MODE is true
                            // Otherwise ignore
                            if (!TESTING_MODE)
                            {
                                Console.WriteLine("This option is only available in testing mode.");
                                break;
                            }

                            Console.WriteLine("Filling with random items...");

                            // Fill the SchoolSupplies with random items
                            SSupply.FillWithRandomItems();

                            Console.WriteLine("Items added successfully!");

                            // Visualize the inventory
                            SSupply.DisplayItemsInTable();
                            break;
                        }
                    default:
                        {
                            // For every incorrect entry of choice,
                            // Prompt message should appear to inform that the selection is invalid,
                            // Then display again the main menu.
                            Console.WriteLine("Selected option invalid [1, 2, 3 only]");
                            break;
                        }
                }
            }

            // The system must be terminated immediately
            // When the user selected the choice # 3.

            // Uncomment the following to show message to user before exiting
            // User chose 3 so we exit
            // And use Console.ReadLine() to prevent the console from closing immediately

            // Console.Write("Thank you for shopping with us! Have a great day");
            // Console.ReadLine();
        }
    }
}
