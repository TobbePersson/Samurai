using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class QuoteType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int QuoteId { get; set; }
        public  Quote Quote { get; set; }
    }
}
