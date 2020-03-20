using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pokerAPI;
namespace testPokerAPI
{

   
    [TestClass]
    public class PlayerTests
    {


        [TestMethod]
        public void PlayerCard_HandIsFourOfAKind()
        {
            //Arrange
            Card cards = new Card();




            MockPlayer m; 

            m = new MockPlayer("Mako");

            m.cardHand.Add(new Card() { _rank = 2,_suit ="D"});
            m.cardHand.Add(new Card() { _rank = 2, _suit = "C" });
            m.cardHand.Add(new Card() { _rank = 2, _suit = "H" });
            m.cardHand.Add(new Card() { _rank = 2, _suit = "S" });
            m.cardHand.Add(new Card() { _rank = 4, _suit = "D" });

            //Act
            Mock_Evaluate mock_Evaluate = new Mock_Evaluate(m);




            //Assert
            Assert.AreEqual(7,mock_Evaluate.handRankReturn);

            
        }



        [TestMethod]
        public void PlayerCard_HandIsThreeOfAKind()
        {
            //Arrange
            Card cards = new Card();




            MockPlayer m;

            m = new MockPlayer("Mako");

            m.cardHand.Add(new Card() { _rank = 2, _suit = "D" });
            m.cardHand.Add(new Card() { _rank = 2, _suit = "C" });
            m.cardHand.Add(new Card() { _rank = 2, _suit = "H" });
            m.cardHand.Add(new Card() { _rank = 6, _suit = "S" });
            m.cardHand.Add(new Card() { _rank = 4, _suit = "D" });

            //Act
            Mock_Evaluate mock_Evaluate = new Mock_Evaluate(m);




            //Assert
            Assert.AreEqual(4, mock_Evaluate.handRankReturn);


        }


        [TestMethod]
        public void PlayerCard_HandIsFullHouse()
        {
            //Arrange
            Card cards;
            MockPlayer m;


            //Act
            m = new MockPlayer("Mako");

            m.cardHand.Add(new Card() { _rank = 2, _suit = "D" });
            m.cardHand.Add(new Card() { _rank = 2, _suit = "C" });
            m.cardHand.Add(new Card() { _rank = 2, _suit = "H" });
            m.cardHand.Add(new Card() { _rank = 4, _suit = "S" });
            m.cardHand.Add(new Card() { _rank = 4, _suit = "D" });

            Mock_Evaluate mock_Evaluate = new Mock_Evaluate(m);

            //Assert
            Assert.AreEqual(6, mock_Evaluate.handRankReturn);


        }


        [TestMethod]
        public void PlayerCard_HandIsStraight()
        {
            //Arrange
            Card cards;
            MockPlayer m;


            //Act
            m = new MockPlayer("Mako");

            m.cardHand.Add(new Card() { _rank = 2, _suit = "D" });
            m.cardHand.Add(new Card() { _rank = 3, _suit = "C" });
            m.cardHand.Add(new Card() { _rank = 4, _suit = "H" });
            m.cardHand.Add(new Card() { _rank = 5, _suit = "S" });
            m.cardHand.Add(new Card() { _rank = 6, _suit = "D" });

            Mock_Evaluate mock_Evaluate = new Mock_Evaluate(m);

            //Assert
            Assert.AreEqual(4, mock_Evaluate.handRankReturn);


        }


        [TestMethod]
        public void PlayerCard_HandIsFlush()
        {
            //Arrange
            Card cards;
            MockPlayer m;


            //Act
            m = new MockPlayer("Mako");

            m.cardHand.Add(new Card() { _rank = 2, _suit = "D" });
            m.cardHand.Add(new Card() { _rank = 6, _suit = "D" });
            m.cardHand.Add(new Card() { _rank = 9, _suit = "D" });
            m.cardHand.Add(new Card() { _rank = 8, _suit = "D" });
            m.cardHand.Add(new Card() { _rank = 4, _suit = "D" });

            Mock_Evaluate mock_Evaluate = new Mock_Evaluate(m);

            //Assert
            Assert.AreEqual(5, mock_Evaluate.handRankReturn);


        }
    }
}
