using System;
using System.Collections.Generic;
using System.Text;

namespace pokerAPI
{
    public class Game : IPokerInterface
    {




        List<Player> players;

        int playerCount = 0;
        string playerName;
        public Game() {
            players = new List<Player>();
         
            Console.Write("Enter number of players: ");
            playerCount = Convert.ToInt32(Console.ReadLine());
         
           

            for (int i = 0; i < playerCount; i++) {
                Console.Write("Enter Player Name: ");
                playerName = Console.ReadLine();

                CreatePlayer(playerName);


            }

            EvaluateCard(players);

            //foreach (Player p in players) { Console.WriteLine(p.playerName); }

        }


    

        public void CreatePlayer(string _playerName)
        {
            players.Add(new Player(_playerName));
          
        }

        public Card[] CreatePlayerCard(string _playerName)
        {
            throw new NotImplementedException();
        }


        public void EvaluateCard(List<Player> player_list)
        {

            foreach (Player p in player_list) {
                new Evaluate(p);    
            }
        }
    }
}
