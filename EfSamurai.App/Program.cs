using EfSamurai.Data;
using EfSamurai.Domain;
using System;
using System.Collections.Generic;

namespace EfSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ClearDatabase();
            //AddOneSamurai();
            //AddSomeSamurais();

            //AddSomeBattles();

            AddOneSamuraiWithRelatedData();
        }

        private static void ClearDatabase()
        {
            
        }

        private static void AddOneSamuraiWithRelatedData()
        {
            var samurai1 = new Samurai
            {
                Name = "Takeda Shingen",
                Age = 52,
                Weapon = "Japanese swords",
                Rank = "Daimyō",
                HairCut = new HairCut { SamuraiHairCut = "Chonmage" },
                SecretIdentity = new SecretIdentity { Identity = "Tiger of Kai" },
                Quote = new List<Quote>
                {
                    new Quote{SamuraiQuote = "Wind, Forest, Fire, Mountain", QuoteType = new QuoteType { Type = "Awesome" } },
                },
                SamuraiBattles = new List<SamuraiBattle>
                {
                    new SamuraiBattle
                    {
                        BettleName = new Battle
                        {
                            BattleName = "Battle of Odaihara",
                            Description = "The 1546 Battle of Odaihara was one of many steps taken by Takeda Shingen, one of Japan's great warlords of the Sengoku period of Japan, in his bid to take over Shinano province.",
                            Brutal = true,
                            StartDate = new DateTime(2011, 5, 28, 0, 0, 0),
                            EndDate = new DateTime(2011, 6, 24, 0, 0, 0),
                            BattleLog = new BattleLog
                            {
                                Name = "Battle of Odaihara Log",
                                BattleEvents = new List<BattleEvent>
                                {
                                    new BattleEvent { EventTime = new DateTime(2011, 5, 30, 0, 0, 0), Summary = "Ten smaurais dead", Description = "Bad" },
                                    new BattleEvent { EventTime = new DateTime(2011, 6, 10, 0, 0, 0), Summary = "Seven smaurais dead", Description = "Not good"},
                                    new BattleEvent { EventTime = new DateTime(2011, 6, 21, 0, 0, 0), Summary = "Four smaurais dead", Description = "Betterthan before" },
                                    new BattleEvent { EventTime = new DateTime(2011, 6, 24, 0, 0, 0), Summary = "Totaly 21 dead samurais", Description = "Wictory!!" },
                                },

                            },

                        },
                    },
                },
            };
            var context = new SamuraiContext();
            context.Samurais.Add(samurai1);
            context.SaveChanges();
        }

        private static void AddSomeBattles()
        {

            var battle1 = new Battle
            {
                BattleName = "Battle of Sacheon",
                BattleLog = new BattleLog
                {
                    Name = "Battle of Sacheon Log",
                    BattleEvents = new List<BattleEvent>
                    {
                        new BattleEvent { EventTime = DateTime.Now, Summary = "Tio döda smauraier" },
                        new BattleEvent { EventTime = DateTime.Now, Summary = "Fem döda smauraier" },
                        new BattleEvent { EventTime = DateTime.Now, Summary = "Två döda smauraier" },
                        new BattleEvent { EventTime = DateTime.Now, Summary = "Alla smauraier är döda" },
                    },
                   
                },

            };
            var context = new SamuraiContext();
            context.Battles.Add(battle1);
            context.SaveChanges();
        }

        private static void AddSomeSamurais()
        {
            var newSamurai1 = new Samurai { Name = "Takayama Ukon" };
            var newSamurai2 = new Samurai { Name = "Akechi Mitsuhide" };
            var newSamurai3 = new Samurai { Name = "Hattori Hanzō" };
            var newSamurai4 = new Samurai { Name = "Saitō Hajime" };

            var context = new SamuraiContext();
            context.Samurais.AddRange(newSamurai1, newSamurai2, newSamurai3, newSamurai4);
            context.SaveChanges();
        }

        private static void AddOneSamurai()
        {
            var newSamurai = new Samurai { Name = "Zelda"};

            var context = new SamuraiContext();
            context.Samurais.Add(newSamurai);
            context.SaveChanges();
        }
    }
}
