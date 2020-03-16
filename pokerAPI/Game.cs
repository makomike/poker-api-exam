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
            IEnumerable<ScoreSheet> temp = temp_score.OrderByDescending(x => x.handRank);
            score = new List<ScoreSheet>();
            score.Clear();
            foreach(ScoreSheet scoreSheet in temp)
            {
             score.Add(new ScoreSheet {
                    playername = scoreSheet.playername,
                    total = scoreSheet.total,
                    highCard = scoreSheet.highCard,
                    handRank = scoreSheet.handRank
                    }
            );
                 
            }

        }

        public void ShowWinner()
        {

            //List<ScoreSheet> winners = new List<ScoreSheet>();


       
            string[] winners = new string[playerCount];
            int res=0;
            int playerWin = 0;

           
            if (score.Count == 1) {
                Console.WriteLine("The Winner is: {0}", score[0].playername);
                return;
            }

            for (int i = 0;i < score.Count;i++)
            {
                res = score[0].handRank;
                if (score[0].handRank > score[i+1].handRank)
                {
                    //if no other rank is higher
                    Console.WriteLine("The Winner is: {0}", score[i].playername);
                    return;
                }
                else if (res == score[i].handRank) {


                  

                    if (score[i].highCard > score[i].highCard) {
                        winners[i] = score[0].playername;
                        return;
                    }
                    else if(score[i].highCard == score[i].highCard)
                    {
                     
                        winners[i] = score[i].playername;
                      
                    }
                    else
                    {
                        return;

                    }
                    
                }
                    
            }

            Console.WriteLine("The Winner is: {0}", winners);

        }

      
    }
}
