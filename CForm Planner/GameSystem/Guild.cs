using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner
{
    public class Guild
    {
        public List<Character> Members { get; private set; }
        public string Name { get; private set; }
        public Game Game { get; private set; }
        public int TotalMembers { get; private set; }

        public Guild(string name, Game game, int totalMembers)
        {
            Name = name;
            Game = game;
            TotalMembers = totalMembers;

            Members = new List<Character>();
        }

        public void AddMember(Character character)
        {
            if (Members.Contains(character) == false)
            {
                Members.Add(character);
            }
            else
            {
                throw new PlannerExceptions("Member already exist");
            }
        }

        public int Number_Members()
        {
            return Members.Count();
        }

        public override string ToString()
        {
            return "Guild: "+Name+", Game: "+Game.Name+" members: "+TotalMembers.ToString();
        }
    }
}
