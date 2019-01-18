using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Weapon { get; set; }
        public string Rank { get; set; }
        public HairCut HairCut { get; set; }
        public  SecretIdentity SecretIdentity { get; set; }
        public List<Quote> Quote { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
    }
}
