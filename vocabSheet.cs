using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        // modificateur d'accès
        public bool monBouleEtBill = false; // Par défaut en privé, public ouvre l'accè a la variable en dehors de la classe

        private int onePunch = 1; //ne peux pas sortir de la classe
        protected string secret = "gg"; //Variable seulement accecible par les children(classes qui hérite de la classe, private sinon
        var maVariable =?; // variable locale, utiliser pour ne pas indiquer le type de la variable

        static void Main(string[] args)
        {
            // vrai ou faux
            bool b = default(bool); // par défaut un bool est false si non indiqué

            // nombres entier 0 est pris par défaut si non indiqué
            byte Boyte = 8; //8
            short shortDePlage = 0; //16
            int integrale = 1; //32
            long longueur = 7; //64
            // bites signé(sans négatif)
            sbyte soByd = 0;
            ushort uShort = 0; // non signé
            uint uInt = 0;
            ulong monLong = 0;

            // nombres décimaux
            decimal monDecimal = 1.0m;
            float monFloat = 1.1f; // très précis sur des petits nombres, plus le chiffre est grand, moins le float sera précis.
            double monDouble = 1.2d;

            // string et caractères
            char monChar = 'c'; // un seul cara
            string monString = "mdr";

            // les conditionelles
            if (monBouleEtBill && b == false) // >= <= == ne jamais utiliser le "==" avec des floats
            {

            }
            else if ()
            {

            }
            else
            {

            }

            switch (integrale) // les valeurs comparées doivent être du même type (short <= short, byte >= byte) le switch ne marche qu'avec des short, byte, int et char
            {
                case 0: // compare la variable au case
                case 1:
                    int anotherInt = 0;
                    break; // termine le switch
                default: // Optionnel, pour le cas ou aucune case ne correspond a la variable
            }

            // Collections

            int[] monTableau = new int[6]; // ou monTableau = {1,2,3,4,5,6,7}

            List<int> maListe = new List<int>(); //

            Queue<int> maQueueHum = new Queue<int>(); // le premier de la "file" est retirer, en premier

            Stack monStack = new Stack(); // ajoute derrière, retire au dessus

            Dictionary<int,string> monDictionnaire new Dictionary<string, int> (); // Tableau a variable de type différent
            monDictionnaire[15]; // vas chercher la valeur int a qui correspond a string

            // Boucle(loop)

            for (int i = 0; i < 4; i++) // boucle ou i tant qu'il n'est pas a 4 gagne 1(1++)
            {

            }

            foreach (var item in maListe)
            {

            }

            do
            {

            }
            while (monBouleEtBill) nn
            {

            }

            //methode 

            string indx1 = lol.Split(' ')[1]; // prend la variable "lol" et la coupe en deux a partir de (' ') donc espace. [1] stoque l'élément dans indx1


        }
        void maMethode()
        {
            return 
        } // void ne retourne rien
        enum monEnumerateur
        {
            un,
            deux,
            trois
        }
    }
}
