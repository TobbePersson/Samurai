using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfSamurai.Domain
{
    public class BattleEvent
    {
        public int Id { get; set; }
        public DateTime EventTime { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }

        
        public int BattleLogId { get; set; }
        [ForeignKey("BattleLogId")]
        public BattleLog BattleLog { get; set; }
    }
}
