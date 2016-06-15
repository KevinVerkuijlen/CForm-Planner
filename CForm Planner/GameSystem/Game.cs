using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner
{
    public class Game
    {
        public string Name { get; private set; }
        public string Genre { get; private set; }

        public Game(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }
    }
}
