using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Room
    {
        public int ID;
        public string description;
        public Room(int myID, string myDescription)
        {
            ID = myID;
            description = myDescription;
        }

        public Dictionary<string, int> myExit = new Dictionary<string, int>(); 
        
    }
}
