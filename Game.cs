using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Game
    {

        private Dictionary<string, int> myInventory = new Dictionary<string, int>(); //L'inventaire, vide au départ

        public void Main()
        {
            List<Room> myPlan = new List<Room>();
            myPlan.Add(new Room(0, "Une pièce sombre Illuminée par de faible rayon de soleil qui travere la grille d'aération située en plein milieu du plafond. " +
                 "De vieux mur de pierre constitue la cellule, l'humidité y a fait poussé des étranges champignons verdâtre. Une unique porte se dresse devant vous, au nord. " +
                 "Elle semble usée par le temps et est rouillée en de multiples endroits."));
            myPlan.Add(new Room(1, "Des torches font joué des ombres sur les murs de pierre du couloir. " +
                "Bien qu'un peu étroit, il y a sufisament de place pour les rondes des gardes. Une autre cellule se trouve ver l'ouest. " +
                "Au sud, se trouve votre propre cellule et a l'est, le couloir semble débouler sur une autre pièce."));
            myPlan.Add(new Room(2, "Une odeur de mort emplis la pièce. Similaire à votre cellule, il n'y a qu'un seul accès par l'est. " +
                "Un cadavre qui semble être la depuis longtemps, se repose couché dans un coin."));
            myPlan.Add(new Room(3, "Il s'agit du corps de garde, qui semble dépeupler. Une grande table encerclée de tabouret est installée au centre. " +
                "Trace de vomi, entaille de couteau et reste du repas de la veille parsème son vieux bois. " +
                "Aucune arme ne semble avoir étée laissée, toutes on du être emportée par les gardes. A l'ouest, l'accès au couloir. " +
                "Au nord, Une porte d'un certain gabaris, avec des gravures."));
            myPlan.Add(new Room(4, "D'autre cellule son dispersée a gauche et au devant de la pièce, mais leur grilles sont cellées. Empèchant tout accès." +
                "A l'est, une porte mène vers la sortie de la prison."));
            myPlan.Add(new Room(5, "C'est une cave à vîn Certain fût sont prêt à servir quiconque tournera  leurs robinnets. " +
                "Une porte est  visible au fond de la pièce mais elle ne bouge pas quand vous tentez de l'ouvrir. Le seul moyen de sortie est donc a l'Ouest."));
            Console.WriteLine(myPlan[0].description);
            Console.ReadLine();
            myPlan[0].myExit.Add("north", 1);
            myPlan[1].myExit.Add("south", 0);
            myPlan[1].myExit.Add("west", 2);
            myPlan[1].myExit.Add("est", 3);
            myPlan[2].myExit.Add("est", 1);
            myPlan[3].myExit.Add("west", 1);
            myPlan[3].myExit.Add("north", 4);
            myPlan[4].myExit.Add("south", 3);
            myPlan[4].myExit.Add("est", 5);
            myPlan[5].myExit.Add("ouest", 4);

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
                    case "go":

                        if (item == "north")
                        {
                            Console.WriteLine(myPlan[1].description);
                        }
                        else if (item == "south")
                        {

                        }
                        else if (item == "west")
                        {

                        }
                        else if (item == "est")
                        {

                        }
                        break;
                    case "drop":

                        if (myInventory.ContainsKey(item))
                        {
                            myInventory[item] -= 1;
                            Console.WriteLine("You have " + myInventory[item] + item + " in your inventory.");
                        }
                        else
                        {
                            Console.WriteLine("Vous n'avez rien a jeté.");
                        }
                        break;
                }

            }


        }



    }
}
