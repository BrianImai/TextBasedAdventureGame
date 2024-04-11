using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame.Classes
{
    public class PlayerClass
    {
        public string name
        { get; set; }
        public List<string> items = new List<string>();
        
        public int beaconPieces = 0;

        public PlayerClass() { 
        }
    }
}
