using SquadBuilder.Reader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SquadBuilder
{
    class Program
    {
        static readonly PlayerReader _playerReader = new PlayerReader();
        static void Main(string[] args)
        {
            List<Player> team = _playerReader.ReadPlayers(); 
            foreach (Player t in team)
            {
                Console.WriteLine(t.TeamName);
            }
            Console.Write("First Team: ");
            var chosenTeam1 = Console.ReadLine();
            

            Console.Write("Second Team: ");
            var chosenTeam2 = Console.ReadLine();
            

            SimulateMatch(ChooseTeam(chosenTeam1),ChooseTeam(chosenTeam2));

            Console.ReadKey();
        }



        public static List<Player> ChooseTeam(string teamName)
        {

            List<Player> teamList = new List<Player>();
            foreach (var team in _playerReader.MakeTeams())
            {
                foreach (var player in team.Players.Where(n => n.TeamName.ToLower() == teamName.ToLower()))
                {
                    teamList.Add(player);
                    //Console.WriteLine(player.Name + "  Position:" + player.Position);
                }
            }
            return teamList;
        }

        public static void SimulateMatch(List<Player> team1, List<Player> team2)
        {
            Random random = new Random();
            Player player;
            int totalGoalsTeam1 = random.Next(0,6);
            int totalGoalsTeam2 = random.Next(0,6);

            int goalScorer;

            for (int i = 1; i < totalGoalsTeam1+1; i++)
            {
                goalScorer = random.Next(10);
                if (goalScorer < 5)
                {
                    List<Player> scorers = team1.Where(p => p.Position == "Attacker").ToList();
                    player = scorers[random.Next(scorers.Count)];

                    Console.WriteLine("GOAAALLLLLL " + player.TeamName);
                    Console.WriteLine(player.Name + " scored");
                }
                if (goalScorer > 5 && goalScorer < 10)
                {
                    List<Player> scorers = team1.Where(p => p.Position == "Midfielder").ToList();
                    player = scorers[random.Next(scorers.Count)];

                    Console.WriteLine("GOAAALLLLLL " + player.TeamName);
                    Console.WriteLine(player.Name + " scored");
                }
                if (goalScorer == 10)
                {
                    List<Player> scorers = team1.Where(p => p.Position == "Defender").ToList();
                    player = scorers[random.Next(scorers.Count)];

                    Console.WriteLine("GOAAALLLLLL " + player.TeamName);
                    Console.WriteLine(player.Name + " scored");
                }
                Thread.Sleep(random.Next(1500, 4500));
                
            }
            for (int j = 1; j < totalGoalsTeam2 + 1; j++)
            {
                goalScorer = random.Next(10);
                if (goalScorer < 5)
                {
                    List<Player> scorers = team2.Where(p => p.Position == "Attacker").ToList();
                    player = scorers[random.Next(scorers.Count)];

                    Console.WriteLine("GOAAALLLLLL " + player.TeamName);
                    Console.WriteLine(player.Name + " scored");
                }
                if (goalScorer > 5 && goalScorer < 10)
                {
                    List<Player> scorers = team2.Where(p => p.Position == "Midfielder").ToList();
                    player = scorers[random.Next(scorers.Count)];

                    Console.WriteLine("GOAAALLLLLL " + player.TeamName);
                    Console.WriteLine(player.Name + " scored");
                }
                if (goalScorer == 10)
                {
                    List<Player> scorers = team2.Where(p => p.Position == "Defender").ToList();
                    player = scorers[random.Next(scorers.Count)];

                    Console.WriteLine("GOAAALLLLLL " + player.TeamName);
                    Console.WriteLine(player.Name + " scored");
                }
                Thread.Sleep(random.Next(1500,4500));
            }

            

            Console.WriteLine(totalGoalsTeam1 + ":" + totalGoalsTeam2);
            // goals score odds  --> 0-5 = forward 6-9 = midfielder 10 = defender
        }
    }
}
