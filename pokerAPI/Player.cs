using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace pokerAPI
{
    public class Player
    {

        List<Card> hand;
        List<Card> temp_hand; //Used for sorting of cards

        string _name;

        public Player(string name) {
            hand = new  List<Card>();
            _name = name;
            pickCard();
            sortCards();
            printCards();



        }

        public List<Card> playerCard { get { return hand; } }
        public string playerName { get { return _name;}}
     
        public void pickCard() {

            Console.WriteLine("Pick 5 cards for " + _name);


            int p_rank;
            string p_suit;
            
            string x_card;

            for (int i = 0; i < 5; i++) {
                x_card = Console.ReadLine();
              
                if (x_card.Length == 3)
                {
                    p_suit = x_card.Substring(2, 1);
                    p_rank = 10;
                    hand.Add(new Card { _rank = p_rank, _suit = p_suit });
                }
                else {
                    p_suit = x_card.Substring(1, 1);
                    if (x_card.Substring(0, 1) == "A")
                    {
                        p_rank = 14;
                    }
                    else if (x_card.Substring(0, 1) == "J")
                    {
                        p_rank = 11;
                    }
                    else if (x_card.Substring(0, 1) == "Q")
                    {
                        p_rank = 12;
                    }
                    else if (x_card.Substring(0, 1) == "K")
                    {
                        p_rank = 13;
                    }
                    else {
                        p_rank = Convert.ToInt32(x_card.Substring(0, 1));
                    }
                    hand.Add(new Card { _rank = p_rank, _suit = p_suit });
                }
           
            }

        }


        //Sorting the cards
        public void sortCards() {
            Console.WriteLine("--------------");

            temp_hand = hand;
            IEnumerable<Card> temp = temp_hand.OrderBy(x => x._rank);
            hand = new List<Card>();
            foreach (Card c in temp) {
                hand.Add(new Card { _rank = c._rank, _suit = c._suit });
            }
        }

        //Print Cards

        public void printCards() {
            foreach (Card cards in hand) {
                if (cards._rank == 11)
                {
                    Console.WriteLine("J" + cards._suit);
                }
                else if (cards._rank == 12)
                {
                    Console.WriteLine("Q" + cards._suit);
                }
                else if (cards._rank == 13)
                {
                    Console.WriteLine("K" + cards._suit);
                }
                else if (cards._rank == 14)
                {
                    Console.WriteLine("A" + cards._suit);
                }
                else {
                    Console.WriteLine(cards._rank + cards._suit);
                }

              
            }
        }



    }
}
