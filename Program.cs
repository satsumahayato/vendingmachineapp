using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace vendingmachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var finished = false;
            var item_inventory = new Dictionary<string,int>();
            item_inventory["Coca Cola"] = 12;
            item_inventory["Snickers"] = 8;
            var item_prices = new Dictionary<string, int>();
            item_prices["Coca Cola"] = 2;
            item_prices["Snickers"] = 1;

            var machine_wallet = 20;
            var user_wallet = 0;
            // var machine_change = 0;

            // Prompt the user to enter the money they have at their disposal and do not move on until the amount is greater than 0.
            Console.WriteLine("Welcome to the Vending Machine.");
            Console.WriteLine("How much money do you have?");
            var user_wallet_str = Console.ReadLine();
            user_wallet = Convert.ToInt32(user_wallet_str);

            while (user_wallet <= 0)
            {
                Console.WriteLine("Please enter a sum greater than $0: ");
                user_wallet_str = Console.ReadLine();
                user_wallet = Convert.ToInt32(user_wallet_str);
            }

            while (!finished)
            {
                Console.Clear();

                if (user_wallet == 0)
                {
                    finished = true;
                    Console.WriteLine("Enjoy your snacks! :)");
                    return;
                }

                Console.WriteLine("You currently have " + user_wallet.ToString() + " dollars in your wallet.");

                // The loop below will display each item's price
                item_prices.Keys.ToList().ForEach((item_key) =>
                {
                    if (item_prices[item_key] >= 1)
                    {
                        Console.WriteLine("For " + item_key + " the price is " + item_prices[item_key].ToString() + " dollars.");
                    }
                });

                // The loop below steps through each item_inventory key
                // It will show the current inventory in the vending machine
                item_inventory.Keys.ToList().ForEach((item_key) =>
                {
                    if(item_inventory[item_key] >= 1)
                    {
                        Console.WriteLine("For " + item_key + " there are currently " + item_inventory[item_key] + " left.");
                    }
                });

                Console.WriteLine("What would you like to buy?");
                var choice = Console.ReadLine().Trim();

                // If the user's choice actually corresponds to an item in the inventory
                if (item_inventory.ContainsKey(choice))
                {
                    // If the user's chosen item is in stock in the vending machine
                    if (item_inventory[choice] > 0)
                    {
                        // If the user has enough money to purchase the item
                        if (user_wallet >= item_prices[choice])
                        {
                            Console.WriteLine("Vending... please wait.");
                            var current_stock = item_inventory[choice];
                            var new_stock = current_stock - 1;
                            item_inventory[choice] = new_stock;
                            user_wallet = user_wallet - item_prices[choice];
                            Console.WriteLine("Item has been dispensed. You now have " + user_wallet.ToString() + " dollars remaining.");
                        }
                        // If the user does not have enough money to purchase the item
                        else
                        {
                            Console.WriteLine("A " + choice.ToString() + " costs " + item_prices[choice] + " dollars but you only have " + user_wallet.ToString() + " dollars.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that item is out of stock. Please select another item.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid choice.");
                }

                Thread.Sleep(5000);

                /*
                 * Todo:
                 * Check if what they type is a valid choice....
                 * Check if they can afford it
                 * If they can afford it, print out that the item was dispensed
                 * Modify wallet and inventory
                 # Ask if they want to order something else
                 */

                // ml.net

                // For the line below, the string that was converted has to be converted into Boolean (e.g., use an if/then statement)
                Console.WriteLine("Are you done today? (yes = true, no = false");
                //finished = Console.ReadLine();
            }
        }
    }
}
