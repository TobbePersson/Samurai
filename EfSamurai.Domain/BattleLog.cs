using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfSamurai.Domain
{
    public class BattleLog
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BattleEvent> BattleEvents { get; set; }
        public Battle Battle { get; set; }
    }
}
