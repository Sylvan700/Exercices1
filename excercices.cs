using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static Dictionary<string, int> myInventory = new Dictionary<string, int>(); //L'inventaire, vide au départ

        static void Main(string[] args)
        {

            while (true)
            {



                string readMsg = Console.ReadLine();                  //capture ce que écrit le joueur
                string[] readMsgSplit = readMsg.Split(' ');             //puis coupe en deux et transmet les mots dans l'inde
                string comand = readMsgSplit[0];
                string item = readMsgSplit[1];



                switch (comand)                                        // L'index correspond a la première moitié de mot qui a été "capturé"
                {
                    case "pick":

                        if (!myInventory.ContainsKey(item))             // "si myInventory ne contiens pas l'item demandé..."
                        {
                            myInventory.Add(item, 1);                   // Ajoute 1 (item) dans la base du dictionnaire 
                        }
                        else                                            // sinon
                        {
                            myInventory[item]++;
                        }
                        Console.WriteLine("You have " + myInventory[item] + item + " in your inventory.");
                        break;
                    case "use":
                        if (item == "staff")
                        {
                            if (myInventory["staff"] >= 1)
                            {
                                Console.WriteLine("Vous lancez une boule de feu.");
                            }
                            else
                            {
                                Console.WriteLine("Vous n'avez pas de baton.");
                            }
                        }
                        else if (item == "potion")
                        {
                            if (myInventory["potion"] >= 1)
                            {
                                myInventory["potion"] -= 1;
                                Console.WriteLine("Vous vous sentez mieux.");
                            }
                            else
                            {
                                Console.WriteLine("Vous n'avez pas de potion.");
                            }
                        }
                        break;
                    case "drop":

                        {
                            if (myInventory.ContainsKey(item))
                            {
                                myInventory[item] -= 1;
                                Console.WriteLine("You have " + myInventory[item] + item + " in your inventory.");
                            }
                            else
                            {
                                Console.WriteLine("Vous n'avez rien a jeté.");
                            }
                        }
                        break;
                }




            }
        }
    }
}
