using System;
using System.Collections.Generic;
using System.Text;

namespace pokerAPI
{
    interface IPokerInterface
    {
        //this method create a player
        void CreatePlayer(string _playerName);

        //this method evaluate the player cards
        void EvaluateCard(List<Player> _player);




    }   
}
