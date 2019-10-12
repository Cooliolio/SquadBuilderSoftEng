using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadBuilder
{
    public class Team
    {
        public List<Player> Players = new List<Player>();
        public string Name { get; set; }
        public Team(List<Player> players, string name)
        {
            this.Players = players;
            this.Name = name;
        }
    }
}
