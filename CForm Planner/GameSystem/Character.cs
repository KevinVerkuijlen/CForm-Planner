using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CForm_Planner.AgendaSystem;

namespace CForm_Planner
{
    public class Character
    {
        public string Name { get; private set; }
        public Guild Guild { get; private set; }
        public Game Game { get; private set; }
        public string Role { get; private set; }
        public int EXPLevel { get; private set; }
        public string Gendre { get; private set; }

        public Character(string name, Guild guild, Game game, string role, int exp, string gendre)
        {
            Name = name;
            Guild = guild;
            Game = game;
            Role = role;
            EXPLevel = exp;
            Gendre = gendre;
        }

        public override bool Equals(object obj)
        {
            if (obj is Character)
            {
                Character other = ((Character)obj);
                return this.Name == other.Name
                    && this.Guild == other.Guild
                    && this.Game == other.Game;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Guild.GetHashCode() ^ Game.GetHashCode();
        }
    }
}
