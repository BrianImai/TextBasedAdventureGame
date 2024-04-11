using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame.Classes
{
    internal class Puzzle
    {
        public string name
        { get; set; }
        public bool solved
        { get; set; }
        public string item
        { get; set; }


        public Puzzle(string name, string item)
        {
            this.name = name;
            this.item = item;
        }
    }
}
