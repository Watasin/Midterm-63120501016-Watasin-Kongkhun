using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string decide = "y";
            string selectFlower;
            FlowerStore flowerStore = new FlowerStore();
            do
            {
                flowerStore.PrintMessage("Select number for buy flower :");
                foreach (string i in flowerStore.flowerList)
                {
                    flowerStore.PrintMessage((flowerStore.flowerList.IndexOf(i) + 1) + " ");
                    flowerStore.PrintMessage(i);
                }

                selectFlower = Console.ReadLine();
                switch (selectFlower)
                {
                    case "1":
                        flowerStore.addToCart(flowerStore.flowerList[0]);
                        flowerStore.PrintMessage("Added " + flowerStore.flowerList[0]);
                        break;
                    case "2":
                        flowerStore.addToCart(flowerStore.flowerList[1]);
                        flowerStore.PrintMessage("Added " + flowerStore.flowerList[1]);
                        break;
                    default:
                        flowerStore.PrintMessage("Not Added to cart. found select number of flower");
                        break;
                }

                flowerStore.PrintMessage("You can stop this progress ? exit for >> exit << progress and press any key for continue");
                decide = Console.ReadLine();
                if (decide == "exit")
                {
                    flowerStore.PrintMessage("Current my cart");
                    flowerStore.showCart();
                }
            } while (decide != "exit");
        }


    }

    class FlowerStore
    {
        public List<string> flowerList = new List<string>();
        List<string> cart = new List<string>();

        public FlowerStore()
        {
            flowerList.Add("Rose");
            flowerList.Add("Lotus");
        }

        public void addToCart(string name)
        {
            cart.Add(name);
        }

        public void showCart()
        {
            if (cart.Count == 0)
            {
                PrintMessage("Cart is empty");
            }
            else
            {
                PrintMessage("My Cart :");
                foreach (string i in cart)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public void PrintMessage(string message)
        {
            Console.Write(message);
        }
    }
}
