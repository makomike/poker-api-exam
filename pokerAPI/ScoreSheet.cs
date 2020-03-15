using System;
using System.Collections.Generic;
using System.Text;

namespace pokerAPI
{
    public class ScoreSheet
    {


      public string playername { get; set; }
      
      public int handRank { get; set; }

      public int total { get; set; }
      public int highCard { get; set; }
    }
}
