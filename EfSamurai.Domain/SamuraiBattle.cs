using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public Samurai SamuraiName { get; set; }

        public int BattleId { get; set; }
        public Battle BettleName { get; set; }
    }
}
