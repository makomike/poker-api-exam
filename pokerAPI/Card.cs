using System;
using System.Collections.Generic;
using System.Text;

namespace pokerAPI
{
    public class Card
    {

        string[] suit = { "D","H","S","C"};
        int[] rank = {2,3,4,5,6,7,8,9,10,11,12,13,14};


        public string _suit { get; set; }
        public int _rank { get; set; }

    }
}
