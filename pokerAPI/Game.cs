using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace pokerAPI
{
    public class Game : IPokerInterface
    {




        List<Player> players;
        List<ScoreSheet> score = new List<ScoreSheet>();
        Evaluate evaluate;

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
            ShowWinner();

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

                evaluate =  new Evaluate(p);
                score.Add(new ScoreSheet { playername = p.playerName, 
                                           total = evaluate.handvalues.total, 
                                           highCard = evaluate.handvalues.highcard,
                                           handRank = evaluate.handvalues.handrank});
            }

            //sorting
            List<ScoreSheet> temp_score = new List<ScoreSheet>();
            temp_score = score;
            IEnumerable<ScoreSheet> temp = temp_score.OrderBy(x => x.handRank);
            score = new List<ScoreSheet>();
            foreach (ScoreSheet c in temp)
            {
                score.Add(new ScoreSheet
                {
                    playername = evaluate.handvalues.playername,
                    total = evaluate.handvalues.total,
                    highCard = evaluate.handvalues.highcard,
                    handRank = evaluate.handvalues.handrank
                }); ;
            }

        }

        public void ShowWinner()
        {

          

            int temp_total = 0;
            int temp_hightcard = 0;

            for (int i = 0;i < playerCount;i++)
            {
               

                    
            }

        }

      
    }
}
