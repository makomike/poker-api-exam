using System;
using System.Collections.Generic;
using System.Text;

namespace pokerAPI
{
    public struct Mock_HandValue
    {
        public int total { get; set; }
        public int highcard { get; set; }
        public int handrank { get; set; }

        public string playername { get; set; }
    }

    public class Mock_Evaluate
    {
        Player player;
        MockPlayer mockplayer;
        public  HandValue handvalue;


        int hightcard;
        int diamond = 0;
        int spade = 0;
        int heart = 0;
        int clover = 0;
        public int handrank = 0;
        private object p;

        public HandValue handvalues
        {
            get { return handvalue; }
            set { handvalue = value; }
        }


        public int handRankReturn { get { return handvalue.handrank; } }

        public Mock_Evaluate(MockPlayer m)
        {
            mockplayer = m;
            //score = new List<ScoreSheet>();
            getSuitCount();
            if (handvalue.handrank == 0) handvalue.handrank = FourOfAKind();
            if (handvalue.handrank == 0) handvalue.handrank = FullHouse();
            if (handvalue.handrank == 0) handvalue.handrank = Flush();
            if (handvalue.handrank == 0) handvalue.handrank = Straight();
            if (handvalue.handrank == 0) handvalue.handrank = ThreeOfAKind();

        }









        //gets the suit count
        public void getSuitCount()
        {
            for (int i = 0; i < 5; i++)
            {

                switch (mockplayer.cardHand[i]._suit)
                {

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
        public int FourOfAKind()
        {

            if (mockplayer.cardHand[0]._rank == mockplayer.cardHand[1]._rank && mockplayer.cardHand[1]._rank == mockplayer.cardHand[2]._rank
                && mockplayer.cardHand[2]._rank == mockplayer.cardHand[3]._rank)
            {
                Console.WriteLine(mockplayer.playerName + ": {0} {1} {2} {3} {4} (Four Of A Kind)",
                          testCardRank(mockplayer.cardHand[0]._rank) + mockplayer.cardHand[0]._suit,
                          testCardRank(mockplayer.cardHand[1]._rank) + mockplayer.cardHand[1]._suit,
                          testCardRank(mockplayer.cardHand[2]._rank) + mockplayer.cardHand[2]._suit,
                          testCardRank(mockplayer.cardHand[3]._rank) + mockplayer.cardHand[3]._suit,
                          testCardRank(mockplayer.cardHand[4]._rank) + mockplayer.cardHand[4]._suit
                        );

                handvalue.total = mockplayer.cardHand[0]._rank * 4;
                handvalue.highcard = mockplayer.cardHand[4]._rank;

                return 7;
            }
            else if (mockplayer.cardHand[1]._rank == mockplayer.cardHand[2]._rank && mockplayer.cardHand[2]._rank == mockplayer.cardHand[3]._rank
                && mockplayer.cardHand[3]._rank == mockplayer.cardHand[4]._rank)
            {

                Console.WriteLine(mockplayer.playerName + ": {0} {1} {2} {3} {4} (Four Of A Kind)",
                         testCardRank(mockplayer.cardHand[0]._rank) + mockplayer.cardHand[0]._suit,
                         testCardRank(mockplayer.cardHand[1]._rank) + mockplayer.cardHand[1]._suit,
                         testCardRank(mockplayer.cardHand[2]._rank) + mockplayer.cardHand[2]._suit,
                         testCardRank(mockplayer.cardHand[3]._rank) + mockplayer.cardHand[3]._suit,
                         testCardRank(mockplayer.cardHand[4]._rank) + mockplayer.cardHand[4]._suit
                     );

                handvalue.total = mockplayer.cardHand[1]._rank * 4;
                handvalue.highcard = mockplayer.cardHand[0]._rank;
                return 7;

            }
            else
            {
                return 0;
            }
        }

        public int ThreeOfAKind()
        {

            if (mockplayer.cardHand[0]._rank == mockplayer.cardHand[1]._rank && mockplayer.cardHand[1]._rank == mockplayer.cardHand[2]._rank && mockplayer.cardHand[2]._rank != mockplayer.cardHand[3]._rank && mockplayer.cardHand[3]._rank != mockplayer.cardHand[4]._rank)
            {
                Console.WriteLine(mockplayer.playerName + ": {0} {1} {2} {3} {4} (Three Of A Kind)",
                        testCardRank(mockplayer.cardHand[0]._rank) + mockplayer.cardHand[0]._suit,
                     testCardRank(mockplayer.cardHand[1]._rank) + mockplayer.cardHand[1]._suit,
                     testCardRank(mockplayer.cardHand[2]._rank) + mockplayer.cardHand[2]._suit,
                     testCardRank(mockplayer.cardHand[3]._rank) + mockplayer.cardHand[3]._suit,
                     testCardRank(mockplayer.cardHand[4]._rank) + mockplayer.cardHand[4]._suit
                        );


                handvalue.total = mockplayer.cardHand[0]._rank * 3;
                handvalue.highcard = mockplayer.cardHand[3]._rank + mockplayer.cardHand[4]._rank;


                return 4;
            }
            else if (mockplayer.cardHand[0]._rank != mockplayer.cardHand[1]._rank && mockplayer.cardHand[1]._rank == mockplayer.cardHand[2]._rank && mockplayer.cardHand[2]._rank == mockplayer.cardHand[3]._rank && mockplayer.cardHand[3]._rank != mockplayer.cardHand[4]._rank)
            {

                Console.WriteLine(mockplayer.playerName + ": {0} {1} {2} {3} {4} (Three Of A Kind)",
                      testCardRank(mockplayer.cardHand[0]._rank) + mockplayer.cardHand[0]._suit,
                     testCardRank(mockplayer.cardHand[1]._rank) + mockplayer.cardHand[1]._suit,
                     testCardRank(mockplayer.cardHand[2]._rank) + mockplayer.cardHand[2]._suit,
                     testCardRank(mockplayer.cardHand[3]._rank) + mockplayer.cardHand[3]._suit,
                     testCardRank(mockplayer.cardHand[4]._rank) + mockplayer.cardHand[4]._suit
                     );

                handvalue.total = mockplayer.cardHand[0]._rank * 3;
                handvalue.highcard = mockplayer.cardHand[0]._rank;
                return 4;

            }
            else if (mockplayer.cardHand[0]._rank != mockplayer.cardHand[1]._rank && mockplayer.cardHand[1]._rank != mockplayer.cardHand[2]._rank && mockplayer.cardHand[2]._rank == mockplayer.cardHand[3]._rank && mockplayer.cardHand[3]._rank == mockplayer.cardHand[4]._rank)
            {

                Console.WriteLine(mockplayer.playerName + ": {0} {1} {2} {3} {4} (Three Of A Kind)",
                     testCardRank(mockplayer.cardHand[0]._rank) + mockplayer.cardHand[0]._suit,
                     testCardRank(mockplayer.cardHand[1]._rank) + mockplayer.cardHand[1]._suit,
                     testCardRank(mockplayer.cardHand[2]._rank) + mockplayer.cardHand[2]._suit,
                     testCardRank(mockplayer.cardHand[3]._rank) + mockplayer.cardHand[3]._suit,
                     testCardRank(mockplayer.cardHand[4]._rank) + mockplayer.cardHand[4]._suit
                     );

                handvalue.total = mockplayer.cardHand[0]._rank * 3;
                handvalue.highcard = mockplayer.cardHand[0]._rank;
                return 4;

            }

            else
            {
                return 0;
            }
        }

        //Full House(if card 1 is equals to the value of card 2 and 3 and  card 4 is equals to the value of 5 
        //OR card 1 is equals to the value card 2 and card 3 is equals to the value of card 4 and 5)
        public int FullHouse()
        {

            if ((mockplayer.cardHand[0]._rank == mockplayer.cardHand[1]._rank &&
                mockplayer.cardHand[1]._rank == mockplayer.cardHand[2]._rank &&
                mockplayer.cardHand[3]._rank == mockplayer.cardHand[4]._rank)
                ||
                (mockplayer.cardHand[0]._rank == mockplayer.cardHand[1]._rank &&
                mockplayer.cardHand[2]._rank == mockplayer.cardHand[3]._rank &&
                mockplayer.cardHand[3]._rank == mockplayer.cardHand[4]._rank)
                )
            {

                Console.WriteLine(mockplayer.playerName + ": {0} {1} {2} {3} {4} (Full House)",
                     testCardRank(mockplayer.cardHand[0]._rank) + mockplayer.cardHand[0]._suit,
                     testCardRank(mockplayer.cardHand[1]._rank) + mockplayer.cardHand[1]._suit,
                     testCardRank(mockplayer.cardHand[2]._rank) + mockplayer.cardHand[2]._suit,
                     testCardRank(mockplayer.cardHand[3]._rank) + mockplayer.cardHand[3]._suit,
                     testCardRank(mockplayer.cardHand[4]._rank) + mockplayer.cardHand[4]._suit
                     );


                handvalue.total = mockplayer.cardHand[0]._rank + mockplayer.cardHand[1]._rank +
                                  mockplayer.cardHand[2]._rank + mockplayer.cardHand[3]._rank + mockplayer.cardHand[4]._rank;

                return 6;
            }
            else
            {
                return 0;
            }



        }

        //Straight
        public int Straight()
        {
            int _root = mockplayer.cardHand[0]._rank;
            int i;
            for (i = 1; i < 4; i++)
            {
                _root++;
                if (mockplayer.cardHand[i]._rank == _root)
                {

                }
                else
                {
                    return 0;
                }

            }

            if (i == 4 && diamond != 5 && heart != 5 && spade != 5 && clover != 5)
            {

                Console.WriteLine(mockplayer.playerName + ": {0} {1} {2} {3} {4} (Straight)",
                   testCardRank(mockplayer.cardHand[0]._rank) + mockplayer.cardHand[0]._suit,
                   testCardRank(mockplayer.cardHand[1]._rank) + mockplayer.cardHand[1]._suit,
                   testCardRank(mockplayer.cardHand[2]._rank) + mockplayer.cardHand[2]._suit,
                   testCardRank(mockplayer.cardHand[3]._rank) + mockplayer.cardHand[3]._suit,
                   testCardRank(mockplayer.cardHand[4]._rank) + mockplayer.cardHand[4]._suit
                   );


                handvalue.total = mockplayer.cardHand[0]._rank + mockplayer.cardHand[1]._rank + mockplayer.cardHand[2]._rank + mockplayer.cardHand[3]._rank + mockplayer.cardHand[4]._rank;

                return 4;
            }
            else
            {
                return 0;
            }


        }


        //Flush
        public int Flush()
        {
            if (diamond == 5 || heart == 5 || spade == 5 || clover == 5 && Straight() == 0)
            {
                Console.WriteLine(mockplayer.playerName + ": {0} {1} {2} {3} {4} (Flush)",
                 testCardRank(mockplayer.cardHand[0]._rank) + mockplayer.cardHand[0]._suit,
                 testCardRank(mockplayer.cardHand[1]._rank) + mockplayer.cardHand[1]._suit,
                 testCardRank(mockplayer.cardHand[2]._rank) + mockplayer.cardHand[2]._suit,
                 testCardRank(mockplayer.cardHand[3]._rank) + mockplayer.cardHand[3]._suit,
                 testCardRank(mockplayer.cardHand[4]._rank) + mockplayer.cardHand[4]._suit
                 );


                handvalue.total = mockplayer.cardHand[0]._rank + mockplayer.cardHand[1]._rank + mockplayer.cardHand[2]._rank + mockplayer.cardHand[3]._rank + mockplayer.cardHand[4]._rank;
                return 5;
            }
            else
            {
                return 0;
            }


        }


        //Pairs
        public bool Pairs()
        {

            int pairCount = 0;

            if (mockplayer.cardHand[0]._rank == mockplayer.cardHand[1]._rank && mockplayer.cardHand[2]._rank == mockplayer.cardHand[3]._rank)
            {
                hightcard = mockplayer.cardHand[4]._rank;
            }
            else if (mockplayer.cardHand[0]._rank == mockplayer.cardHand[1]._rank && mockplayer.cardHand[3]._rank == mockplayer.cardHand[4]._rank)
            {
                hightcard = mockplayer.cardHand[2]._rank;
            }
            else if (mockplayer.cardHand[1]._rank == mockplayer.cardHand[2]._rank && mockplayer.cardHand[3]._rank == mockplayer.cardHand[4]._rank)
            {
                hightcard = mockplayer.cardHand[0]._rank;
            }


            return true;

        }




        public string testCardRank(int r)
        {
            if (r == 11)
            {
                return "J";
            }
            else if (r == 12)
            {
                return "Q";
            }
            else if (r == 13)
            {
                return "K";
            }
            else if (r == 14)
            {
                return "A";
            }
            else
            {
                return r.ToString();
            }

        }

    }
}
