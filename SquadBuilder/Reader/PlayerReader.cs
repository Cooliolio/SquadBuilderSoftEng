using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadBuilder.Reader
{
    public class PlayerReader
    {
        public List<Player> players = new List<Player>();
        public List<Team> teams = new List<Team>();
        public List<Player> teamPlayers = new List<Player>();

        public List<Player> ReadPlayers()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("C:\\Users\\Yasin Yavuz\\Source\\Repos\\SquadBuilder\\SquadBuilder\\Reader\\epldata_final.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadLine();
                    Player player;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] array = line.Split(',');
                        if (array[3] == "RB" || array[3] == "LB" || array[3] == "CB")
                        {
                            player = new Player(array[0], array[1].Replace('+' , ' '), int.Parse(array[2]), "Defender");
                            players.Add(player);
                        }
                        if (array[3] == "AM" || array[3] == "CM" || array[3] == "LM" || array[3] == "RM")
                        {
                            player = new Player(array[0], array[1].Replace('+', ' '), int.Parse(array[2]), "Midfielder");
                            players.Add(player);
                        }
                        if (array[3] == "CF" || array[3] == "LW" || array[3] == "RW")
                        {
                            player = new Player(array[0], array[1].Replace('+', ' '), int.Parse(array[2]), "Attacker");
                            players.Add(player);
                        }
                        if (array[3] == "GK")
                        {
                            player = new Player(array[0], array[1].Replace('+', ' '), int.Parse(array[2]), "Goalkeeper");
                            players.Add(player);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return players;
        }

        public List<Team> MakeTeams()
        {
            ReadPlayers();
            List<string> teamNames = new List<string>();
            foreach(Player player in players)
            {
                teamNames.Add(player.TeamName.Replace('+', ' '));
            }
            teamNames = teamNames.Distinct().ToList();

            foreach(string teamName in teamNames)
            {
                teamPlayers = new List<Player>();

                foreach (Player player in players)
                {
                    if (player.TeamName.Replace('+', ' ') == teamName)
                        teamPlayers.Add(player);
                }
                Team team = new Team(teamPlayers, teamName);
                teams.Add(team);
            }
            return teams;
        }
    }
}
