using SquadBuilder.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerReader playerReader = new PlayerReader();
            /*foreach (Player player in playerReader.ReadPlayers())
            {
                Console.WriteLine(player.Name);
            }*/
            foreach (Team team in playerReader.MakeTeams())
            {
                Console.WriteLine("---------");
                Console.WriteLine(team.Name);
                Console.WriteLine("---------");
                foreach (Player player in team.Players)
                {
                    Console.WriteLine(player.Name);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
