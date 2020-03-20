using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace pokerAPI
{
    public class Game
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

                //CreatePlayerCard();
                //SortPlayerCard();

            }

            EvaluateCard(players);
            ShowWinner();

            //foreach (Player p in players) { Console.WriteLine(p.playerName); }

        }


    

        public void CreatePlayer(string _playerName)
        {
            players.Add(new Player(_playerName));
            
          
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

            List<ScoreSheet> winners = new List<ScoreSheet>();


       
            int res=0;
            string[] winnersname = new string[playerCount] ;

           
            if (score.Count == 1) {
                Console.WriteLine("The Winner is: {0}", score[0].playername);
                return;
            }

            for (int i = 0;i < score.Count;i++)
            {
                if (score[0].handRank >= score[i].handRank) {
                    winners.Add(new ScoreSheet { handRank = score[i].handRank, playername = score[i].playername, highCard = score[i].highCard, total = score[i].total });
                }
            }

            List<ScoreSheet> temp_score = new List<ScoreSheet>();
            temp_score = winners;
            IEnumerable<ScoreSheet> temp = temp_score.OrderByDescending(x => x.total);
            winners = new List<ScoreSheet>();
            winners.Clear();
            foreach (ScoreSheet scoreSheet in temp)
            {
                winners.Add(new ScoreSheet
                {
                    playername = scoreSheet.playername,
                    total = scoreSheet.total,
                    highCard = scoreSheet.highCard,
                    handRank = scoreSheet.handRank
                }
               );

            }

            for (int i = 0; i < winners.Count; i++)
            {
                if (winners[0].total > winners[i].total)
                {
                    break;
                }
                else if (winners[0].total == winners[i].total)
                {
                    if (winners[0].highCard == winners[i].highCard)
                    {
                        winnersname[i] = winners[i].playername;
                        
                    }
                    else if(winners[0].highCard < winners[i].highCard)
                    {
                        winnersname[0] = winners[i].playername;
      
                    }

                }
              
            }



            string _winners="";


            for (int i = 0; i < winnersname.Count(); i++) {
                _winners += " " + winnersname[i] ;
            }

            if (winnersname.Count() > 1)
            {
                Console.WriteLine("The winners are: {0}", _winners);
            }
            else {
                Console.WriteLine("The winner is: {0}", _winners);
            }
           
            
        }

      
    }
}
