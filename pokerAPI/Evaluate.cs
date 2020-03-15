using System;
using System.Collections.Generic;
using System.Text;

namespace pokerAPI
{

    public struct HandValue
    {
        public int total { get; set; }
        public int highcard { get; set; }
        public int handrank { get; set; }

        public string playername { get; set; }
    }

    public class Evaluate
    {
        Player player;
        HandValue handvalue;


        int hightcard;
        int diamond = 0;
        int spade = 0;
        int heart = 0;
        int clover = 0;
        int handrank = 0;


        public HandValue handvalues
        {
            get { return handvalue; }
            set { handvalue = value; }
        }


        public Evaluate(Player p) {
            player = p;
            handvalue.playername = p.playerName;
            //score = new List<ScoreSheet>();
            getSuitCount();
           if (handvalue.handrank == 0) handvalue.handrank = FourOfAKind();
           if (handvalue.handrank == 0) handvalue.handrank = FullHouse();
           if (handvalue.handrank == 0) handvalue.handrank = Flush();
           if (handvalue.handrank == 0) handvalue.handrank = Straight();
           if (handvalue.handrank == 0) handvalue.handrank = ThreeOfAKind();
          // if (handrank == 0) handrank = Pairs();

        }


        //gets the suit count
        public void getSuitCount() {
            for (int i = 0; i < 5; i++) {

                switch (player.playerCard[i]._suit) {

                    case "D":
                        diamond++;
                        break;
                    case "S":
                        spade++;
                        break;
                    case "H":
                        heart++;
                        break;
                    case "C":
                        clover++;
                        break;


                }


            }
        }




        //Four Of A Kind(if card 1 value is equals to the value of card 2,3,4 or card 2 value is equals to the value of 3,4,5)
        public int FourOfAKind() {

            if (player.playerCard[0]._rank == player.playerCard[1]._rank && player.playerCard[1]._rank == player.playerCard[2]._rank
                && player.playerCard[2]._rank == player.playerCard[3]._rank)
            {
                Console.WriteLine(player.playerName + ": {0} {1} {2} {3} {4} (Four Of A Kind)",
                        player.playerCard[0]._rank + player.playerCard[0]._suit,
                        player.playerCard[1]._rank + player.playerCard[1]._suit,
                        player.playerCard[2]._rank + player.playerCard[2]._suit,
                        player.playerCard[3]._rank + player.playerCard[3]._suit,
                        player.playerCard[4]._rank + player.playerCard[4]._suit
                        );

                handvalue.total = player.playerCard[0]._rank * 4;
                handvalue.highcard = player.playerCard[4]._rank;

                return 7;
            }
            else if (player.playerCard[1]._rank == player.playerCard[2]._rank && player.playerCard[2]._rank == player.playerCard[3]._rank
                && player.playerCard[3]._rank == player.playerCard[4]._rank) {

                Console.WriteLine(player.playerName + ": {0} {1} {2} {3} {4} (Four Of A Kind)",
                     player.playerCard[0]._rank + player.playerCard[0]._suit,
                     player.playerCard[1]._rank + player.playerCard[1]._suit,
                     player.playerCard[2]._rank + player.playerCard[2]._suit,
                     player.playerCard[3]._rank + player.playerCard[3]._suit,
                     player.playerCard[4]._rank + player.playerCard[4]._suit
                     );

                handvalue.total = player.playerCard[1]._rank * 4;
                handvalue.highcard = player.playerCard[0]._rank;
                return 8;

            }
            else {
                return 0;
            }
        }

        public int ThreeOfAKind()
        {

            if (player.playerCard[0]._rank == player.playerCard[1]._rank && player.playerCard[1]._rank == player.playerCard[2]._rank && player.playerCard[2]._rank != player.playerCard[3]._rank && player.playerCard[3]._rank != player.playerCard[4]._rank )
            {
                Console.WriteLine(player.playerName + ": {0} {1} {2} {3} {4} (Three Of A Kind)",
                        player.playerCard[0]._rank + player.playerCard[0]._suit,
                        player.playerCard[1]._rank + player.playerCard[1]._suit,
                        player.playerCard[2]._rank + player.playerCard[2]._suit,
                        player.playerCard[3]._rank + player.playerCard[3]._suit,
                        player.playerCard[4]._rank + player.playerCard[4]._suit
                        );


                handvalue.total = player.playerCard[0]._rank * 3;
                handvalue.highcard = player.playerCard[3]._rank + player.playerCard[4]._rank;


                return 4;
            }
            else if (player.playerCard[0]._rank != player.playerCard[1]._rank && player.playerCard[1]._rank == player.playerCard[2]._rank && player.playerCard[2]._rank == player.playerCard[3]._rank && player.playerCard[3]._rank != player.playerCard[4]._rank)
            {

                Console.WriteLine(player.playerName + ": {0} {1} {2} {3} {4} (Three Of A Kind)",
                     player.playerCard[0]._rank + player.playerCard[0]._suit,
                     player.playerCard[1]._rank + player.playerCard[1]._suit,
                     player.playerCard[2]._rank + player.playerCard[2]._suit,
                     player.playerCard[3]._rank + player.playerCard[3]._suit,
                     player.playerCard[4]._rank + player.playerCard[4]._suit
                     );

                handvalue.total = player.playerCard[0]._rank * 3;
                handvalue.highcard = player.playerCard[0]._rank;
                return 4;

            }
            else if (player.playerCard[0]._rank != player.playerCard[1]._rank && player.playerCard[1]._rank != player.playerCard[2]._rank && player.playerCard[2]._rank == player.playerCard[3]._rank && player.playerCard[3]._rank == player.playerCard[4]._rank)
            {

                Console.WriteLine(player.playerName + ": {0} {1} {2} {3} {4} (Three Of A Kind)",
                     player.playerCard[0]._rank + player.playerCard[0]._suit,
                     player.playerCard[1]._rank + player.playerCard[1]._suit,
                     player.playerCard[2]._rank + player.playerCard[2]._suit,
                     player.playerCard[3]._rank + player.playerCard[3]._suit,
                     player.playerCard[4]._rank + player.playerCard[4]._suit
                     );

                handvalue.total = player.playerCard[0]._rank * 3;
                handvalue.highcard = player.playerCard[0]._rank;
                return 4;

            }

            else
            {
                return 0;
            }
        }

        //Full House(if card 1 is equals to the value of card 2 and 3 and  card 4 is equals to the value of 5 
        //OR card 1 is equals to the value card 2 and card 3 is equals to the value of card 4 and 5)
        public int FullHouse() {

            if ((player.playerCard[0]._rank == player.playerCard[1]._rank &&
                player.playerCard[1]._rank == player.playerCard[2]._rank &&
                player.playerCard[3]._rank == player.playerCard[4]._rank)
                ||
                (player.playerCard[0]._rank == player.playerCard[1]._rank &&
                player.playerCard[2]._rank == player.playerCard[3]._rank &&
                player.playerCard[3]._rank == player.playerCard[4]._rank)
                )
            {

                Console.WriteLine(player.playerName + ": {0} {1} {2} {3} {4} (Full House)",
                     player.playerCard[0]._rank + player.playerCard[0]._suit,
                     player.playerCard[1]._rank + player.playerCard[1]._suit,
                     player.playerCard[2]._rank + player.playerCard[2]._suit,
                     player.playerCard[3]._rank + player.playerCard[3]._suit,
                     player.playerCard[4]._rank + player.playerCard[4]._suit
                     );

                return 7;
            }
            else {
                return 0;
            }



        }

        //Straight
        public int Straight() {
            int _root = player.playerCard[0]._rank;
            int i;
            for (i = 1; i < 4; i++) {
                _root++;
                if (player.playerCard[i]._rank == _root)
                {

                }
                else {
                    return 5;
                }

            }

            if (i == 4 && diamond != 5 && heart != 5 && spade != 5 && clover != 5)
            {

                Console.WriteLine(player.playerName + ": {0} {1} {2} {3} {4} (Straight)",
                   player.playerCard[0]._rank + player.playerCard[0]._suit,
                   player.playerCard[1]._rank + player.playerCard[1]._suit,
                   player.playerCard[2]._rank + player.playerCard[2]._suit,
                   player.playerCard[3]._rank + player.playerCard[3]._suit,
                   player.playerCard[4]._rank + player.playerCard[4]._suit
                   );

                return 5;
            }
            else {
                return 0;
            }

           
        }


        //Flush
        public int Flush() {
            if (diamond == 5 || heart == 5 || spade == 5 || clover == 5 && Straight() == 0)
            {
                Console.WriteLine(player.playerName + ": {0} {1} {2} {3} {4} (Flush)",
                 player.playerCard[0]._rank + player.playerCard[0]._suit,
                 player.playerCard[1]._rank + player.playerCard[1]._suit,
                 player.playerCard[2]._rank + player.playerCard[2]._suit,
                 player.playerCard[3]._rank + player.playerCard[3]._suit,
                 player.playerCard[4]._rank + player.playerCard[4]._suit
                 );
                return 6;
            }
            else {
                return 0;
            }
           

        }


        //Pairs
        public bool Pairs() {
            
            int pairCount = 0;

            if (player.playerCard[0]._rank == player.playerCard[1]._rank && player.playerCard[2]._rank == player.playerCard[3]._rank)
            {
                hightcard = player.playerCard[4]._rank;
            }
            else if (player.playerCard[0]._rank == player.playerCard[1]._rank && player.playerCard[3]._rank == player.playerCard[4]._rank)
            {
                hightcard = player.playerCard[2]._rank;
            }
            else if (player.playerCard[1]._rank == player.playerCard[2]._rank && player.playerCard[3]._rank == player.playerCard[4]._rank) {
                hightcard = player.playerCard[0]._rank;
            }


            return true;

        }

    }
}
