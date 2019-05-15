using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Room
    {
        // déclaration de variable
        public int ID;
        public string description;
        public Dictionary<string, int> myExit = new Dictionary<string, int>();
        public Dictionary<string, int> myItem = new Dictionary<string, int>();

        // Indique les variable a récupéré et a utiliser dans Room.
        public Room(int myID, string myDescription)
        {
            ID = myID;
            description = myDescription;
        }

        public void GetDescription()
        {

        }
        
    }
}
