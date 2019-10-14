using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadBuilder
{
    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }

        public Player(string name, string teamName, int age, string position)
        {
            this.Name = name;
            this.TeamName = teamName;
            this.Age = age;
            this.Position = position;
        }

    }
}
