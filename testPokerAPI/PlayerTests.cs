using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using pokerAPI;
namespace testPokerAPI
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerName_isNotNull()
        {
            //Arrange
            Player p;



            //Act
            p = new Player("");


            //Assert
            Assert.IsTrue(p.playerName != "");

        }


    }
}
