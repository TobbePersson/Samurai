using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string SamuraiQuote { get; set; }
        public Samurai Samurai { get; set; }
        public QuoteType QuoteType { get; set; }
    }
}
