using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    /// <summary>
    /// Contrôle du jeu: Commandes en deux parties a taper = "pick [staff, potion]; use [staff, potion]; drop [staff, potion]; info [room]; go [north, south, west, east]"
    /// </summary>
    public class Game
    {
        //L'inventaire, vide au départ
        private Dictionary<string, int> myInventory = new Dictionary<string, int>();
        public int currentPos = 0;
        // Liste de Room(tiré de la classe Room). (myplan= liste, add(new room = ajoute une room, (0, description) = ajoute un ID de room et une description en string.
        List<Room> myPlan = new List<Room>();
        public void CreateGame()
        {

            CreateRooms();

            CreateExits();

            myPlan[2].myItem.Add("staff", 2);
            myPlan[3].myItem.Add("potion", 4);

        }

        public void Run()
        {

            // écrit la description de la room [position actuelle].
            Console.WriteLine(myPlan[currentPos].description);

            while (true)
            {

                //capture ce qu' écrit le joueur puis coupe en deux et transmet les mots dans deux index (comand & item).
                string readMsg = Console.ReadLine();
                string[] readMsgSplit = readMsg.Split(' ');
                string comand = readMsgSplit[0];
                string item = readMsgSplit[1];

                // comand correspond a la première moitié de mot qui a été "capturé"
                switch (comand)
                {
                    case "pick":                                        // pick, use, go, etc. = comand (c'est ce que le joueur écrit).
                        if (myPlan[currentPos].myItem.ContainsKey(item))   // Si a ma position myItem contiens bien l'item demander alors...
                        {

                            if (!myInventory.ContainsKey(item))             // "si myInventory ne contiens pas l'item demandé..."
                            {
                                myInventory.Add(item, 1);                   // Ajoute 1 (item) dans la base du dictionnaire 

                                Console.WriteLine("You have " + myInventory[item] + item + " in your inventory."); // écrit dans la console ( string + nombre d'(item) + nom item + string).
                            }
                            else                                            // sinon
                            {
                                Console.WriteLine("Il n'y a rien ici.");
                       
                            }
                        }
                        else
                        {
                            Console.WriteLine("Il n'y a rien ici.");
                        }

                        break;
                    case "use":

                        if (item == "staff")                            // Si (item) = string
                        {
                            if (myInventory["staff"] >= 1 & currentPos == 5) // & bossIsNotDead
                            {
                                Console.WriteLine("Vous lancez une boule de feu sur le capitaine de la garde.");
                                // bool bossIsDead == true
                                // bossIsNotDead == false
                            }
                            else if (myInventory["staff"] >= 1 & currentPos != 5)    // Si l'item "staff" a un nombre supérieur a 1 et que vous n'êtes pas dans la pièce 5
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
                        // vérification. On prend l'index qui correspond a la position actuelle puis on vérifie que le dictionnaire contiens bien le mot taper(l'item).
                        if (myPlan[currentPos].myExit.ContainsKey(item))
                        {   // La position actuelle deviens  l'ancienne position "actuelle" + l'index associé avec l'item que l'on viens de vérifier.
                            currentPos = myPlan[currentPos].myExit[item];
                            // On écrit dans la console la description asssociée avec l'ID de la position actuelle.
                            Console.WriteLine(myPlan[currentPos].description);
                        }
                        else
                        {
                            Console.WriteLine("Vous ne pouvez pas aller par là.");
                        }
                        break;
                    case "drop":

                        if (myInventory.ContainsKey(item))                // "si myInventory contiens l'item demandé..."
                        {
                            myInventory[item] -= 1;
                            Console.WriteLine("You have " + myInventory[item] + item + " in your inventory.");
                        }
                        else
                        {
                            Console.WriteLine("Vous n'avez rien a jeté.");
                        }
                        break;
                    case "info":
                        // si l'item est info et que la position du joueur est la room 2 et aussi que l'inventaire contiens staff alors...
                        if (item == "room" & currentPos == 2 & myInventory.ContainsKey("staff"))
                        {
                            NothingHere();
                        }
                        else if (item == "room" & currentPos == 3 & myInventory.ContainsKey("potion"))
                        {
                            NothingHere();
                        }
                        else if (item == "room" & currentPos == 2 & !myInventory.ContainsKey("staff"))
                        {
                            Console.WriteLine("Un baton étrange est posé contre un des murs. Vous êtes dans la pièce n°3.");
                        }
                        else if (item == "room" & currentPos == 3 & !myInventory.ContainsKey("potion"))
                        {
                            Console.WriteLine("Une petite fiole  contenant un liquide fluorescent est posée sur la table. Vous êtes dans la pièce n°4.");
                        }
                        else
                        {
                            NothingHere();
                        }
                        break;

                }

            }
        }

        public void CreateRooms()
        {
            myPlan.Add(new Room(0, "Une pièce sombre Illuminée par de faible rayon de soleil qui traverse la grille d'aération située en plein milieu du plafond. " +
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
            myPlan.Add(new Room(4, "D'autre cellule son dispersée a gauche et au devant de la pièce, mais leur grilles sont cellées, empèchant tout accès." +
                "A l'est, une porte mène vers la sortie de la prison."));
            myPlan.Add(new Room(5, "C'est une cave à vîn Certain fût sont prêt à servir quiconque tournera  leurs robinnets. " +
                "Une porte est  visible au fond de la pièce mais elle ne bouge pas quand vous tentez de l'ouvrir. Le seul moyen de sortie est donc a l'Ouest."));

        }
        public void CreateExits()
        {
            myPlan[0].myExit.Add("north", 1);
            myPlan[1].myExit.Add("south", 0);
            myPlan[1].myExit.Add("west", 2);
            myPlan[1].myExit.Add("east", 3);
            myPlan[2].myExit.Add("east", 1);
            myPlan[3].myExit.Add("west", 1);
            myPlan[3].myExit.Add("north", 4);
            myPlan[4].myExit.Add("south", 3);
            myPlan[4].myExit.Add("ea st", 5);
            myPlan[5].myExit.Add("west", 4);
        }
        public void NothingHere()
        {
            Console.WriteLine("Il n'y a rien ici. Vous êtes dans la pièce n°" + (currentPos + 1) + " .");
        }

    }
}
