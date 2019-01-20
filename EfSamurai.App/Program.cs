using EfSamurai.Data;
using EfSamurai.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EfSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClearDatabase();
            //AddOneSamurai("Zelda");
            //AddSomeSamurais();

            //AddSomeBattles();

            //AddOneSamuraiWithRelatedData();
            //ListAllSamuraiNames();
            //ListAllSamuraisOrderByName();
            //ListAllSamuraisOrderByNameDescending();
            FindSamuraiWithRealName("unknown");
            ListAllQuotesOfType("Lame");
            ListAllQuotesOfType("Lame");
            ListAllQuotesOfTypeFromSamurai("Lame");
            ListAllBattles(new DateTime(1500, 1, 1), new DateTime(1600, 1, 1), true);
            AllSamuraisNameAndAlias();
            ListAllBattlesWithLog(new DateTime(1500, 1, 1), new DateTime(1600, 1, 1), true);
            
        }

        private static void ListAllBattlesWithLog(DateTime dateTime1, DateTime dateTime2, bool isBrutal)
        {
            var dataAccess = new DataAccess();
            List<BattleLog> listOfBattlesWithLog = dataAccess.ListOfBattlesWithLog(dateTime1, dateTime2, isBrutal);
            PrintBattelLog(listOfBattlesWithLog);
        }

        private static void PrintBattelLog(List<BattleLog> listOfBattlesWithLog)
        {
            Console.WriteLine("-----------------------------------------------------");

            foreach (var battle in listOfBattlesWithLog)
            {
                Console.WriteLine($"Name of Battle\t\t{battle.Battle.BattleName}");
                Console.WriteLine($"Log name\t\t{battle.Name}");
                foreach (var battleEvent in battle.BattleEvents)
                {
                    Console.WriteLine($"Event {battleEvent.EventTime.ToShortDateString()}\t\t{battleEvent.Description} ");
                }
            }
        }

        private static void AllSamuraisNameAndAlias()
        {
            var dataAccess = new DataAccess();

            List<string> allSamuraiNamesAndAlias = dataAccess.AllSamuraiNamesAndAlias();
            Console.WriteLine();
            PrintAllQuotesOfTypeFromSamurai(allSamuraiNamesAndAlias);
        }

        private static void ListAllBattles(DateTime dateTime1, DateTime dateTime2, bool brutalIsTrue)
        {
            var dataAccess = new DataAccess();

            List<string> brutaleBattles = dataAccess.ListOfBrutalBattles(dateTime1, dateTime2, brutalIsTrue);
            PrintAllQuotesOfTypeFromSamurai(brutaleBattles);
        }

        private static void ListAllQuotesOfTypeFromSamurai(string quoteType)
        {
            var dataAccess = new DataAccess();

            List<string> listOfSamuraiQuotesWithSamurai = dataAccess.ListAllQuotesOfTypeFromSamurai(quoteType);
            PrintAllQuotesOfTypeFromSamurai(listOfSamuraiQuotesWithSamurai);
        }

        private static void PrintAllQuotesOfTypeFromSamurai(List<string> listOfSamuraiQuotesWithSamurai)
        {
            foreach (var quote in listOfSamuraiQuotesWithSamurai)
            {
                Console.WriteLine(quote);
            }
        }

        private static void ListAllQuotesOfType(string quoteType)
        {
            var dataAccess = new DataAccess();

            List<Quote> quotesOfType = dataAccess.ListAllQuotesOfTypes(quoteType);
            PrintAllQuotesOfType(quotesOfType, quoteType);
        }

        private static void PrintAllQuotesOfType(List<Quote> quotesOfType, string quoteType)
        {
            Console.WriteLine($"Quotes of type '{quoteType}':");

            foreach (var quote in quotesOfType)
            {
                Console.WriteLine($"{quote.SamuraiQuote}");
            }
        }

        private static void FindSamuraiWithRealName(string realName)
        {
            var dataAccess = new DataAccess();
            List<Samurai> realNameSamurai = dataAccess.FindSamuraiRealName(realName);
            if (realNameSamurai.Count == 0)
                Console.WriteLine($"Sorry no Samurai with the name {realName}.");
            else
                PrintSamuraiNames(realNameSamurai);
        }

        private static void ListAllSamuraisOrderByNameDescending()
        {
            var dataAccess = new DataAccess();
            List<Samurai> allSamuraisNameDesc = dataAccess.ListAllSamuraisOrderByNameDesc();
            PrintSamuraiNames(allSamuraisNameDesc);
        }

        private static void ListAllSamuraisOrderByName()
        {
            var dataAccess = new DataAccess();

            List<Samurai> allSamuraisOrderByName= dataAccess.ListAllSamuraisOrderByName();
            PrintSamuraiNames(allSamuraisOrderByName);

        }

        private static void ListAllSamuraiNames()
        {
            var dataAccess = new DataAccess();

            List<Samurai> listOfSamuraiNames = dataAccess.NamesOfAllSamurais();

            PrintSamuraiNames(listOfSamuraiNames);
        }

        private static void PrintSamuraiNames(List<Samurai> listOfSamuraiNames)
        {
            foreach (var name in listOfSamuraiNames)
            {
                Console.WriteLine($"{name.Name}");
            }
        }

        private static void ClearDatabase()
        {
            var context = new SamuraiContext();
            var battleEvents = context.BattleEvents;
            context.RemoveRange(battleEvents);
            var battleLog = context.BattleLogs;
            context.RemoveRange(battleLog);
            var battles = context.Battles;
            context.RemoveRange(battles);
            var samuraiBattles = context.SamuraiBattles;
            context.RemoveRange(samuraiBattles);
            var secretId = context.SecretIdentities;
            context.RemoveRange(secretId);
            var qType = context.QuoteTypes;
            context.RemoveRange(qType);
            var quote = context.Quotes;
            context.RemoveRange(quote);
            var samurai = context.Samurais;
            context.RemoveRange(samurai);
            var hairCut = context.HairCuts;
            context.RemoveRange(hairCut);
            context.SaveChanges();
        }

        private static void AddOneSamuraiWithRelatedData()
        {
            var samurai1 = new Samurai
            {
                Name = "Oda Nobunaga",
                Age = 47,
                Weapon = "Pole weapons",
                Rank = "Daimyō",
                HairCut = new HairCut { SamuraiHairCut = "Western" },
                SecretIdentity = new SecretIdentity { Identity = "unknown" },
                Quote = new List<Quote>
                {
                    new Quote{SamuraiQuote = "unifying factors", QuoteType = new QuoteType { Type = "Lame" } },
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
                            StartDate = new DateTime(1546, 5, 28, 0, 0, 0),
                            EndDate = new DateTime(1546, 6, 24, 0, 0, 0),
                            BattleLog = new BattleLog
                            {
                                Name = "Battle of Odaihara Log",
                                BattleEvents = new List<BattleEvent>
                                {
                                    new BattleEvent { EventTime = new DateTime(1546, 5, 30, 0, 0, 0), Summary = "Ten smaurais dead", Description = "Bad" },
                                    new BattleEvent { EventTime = new DateTime(1546, 6, 10, 0, 0, 0), Summary = "Seven smaurais dead", Description = "Not good"},
                                    new BattleEvent { EventTime = new DateTime(1546, 6, 21, 0, 0, 0), Summary = "Four smaurais dead", Description = "Betterthan before" },
                                    new BattleEvent { EventTime = new DateTime(1546, 6, 24, 0, 0, 0), Summary = "Totaly 21 dead samurais", Description = "Wictory!!" },
                                },

                            },

                        },

                    },
                    new SamuraiBattle
                    {
                        BettleName = new Battle
                        {
                            BattleName = "Battle of Okehazama",
                            Description = "The Battle of Okehazama (桶狭間の戦い Okehazama-no-tatakai) took place in June 1560.",
                            Brutal = true,
                            StartDate = new DateTime(1560, 6, 5, 0, 0, 0),
                            EndDate = new DateTime(1546, 6, 15, 0, 0, 0),
                            BattleLog = new BattleLog
                            {
                                Name = "Battle of Okehazama Log",
                                BattleEvents = new List<BattleEvent>
                                {
                                    new BattleEvent { EventTime = new DateTime(1560, 6, 5, 0, 0, 0), Summary = "100 smaurais dead", Description = "Bad" },
                                    new BattleEvent { EventTime = new DateTime(1560, 6, 10, 0, 0, 0), Summary = "200 smaurais dead", Description = "Not good"},
                                    new BattleEvent { EventTime = new DateTime(1560, 6, 14, 0, 0, 0), Summary = "3000 smaurais dead", Description = "Betterthan before" },
                                    new BattleEvent { EventTime = new DateTime(1560, 6, 15, 0, 0, 0), Summary = "All dead samurais", Description = "Loss!!" },
                                },

                            },

                        },

                    },
                    new SamuraiBattle
                    {
                        BettleName = new Battle
                        {
                            BattleName = "Battle of Nagashino",
                            Description = "The Battle of Nagashino (長篠の戦い Nagashino no Tatakai) took place in 1575 near Nagashino Castle on the plain of Shitarabara in the Mikawa Province of Japan.",
                            Brutal = true,
                            StartDate = new DateTime(1575, 6, 15, 0, 0, 0),
                            EndDate = new DateTime(1575, 6, 29, 0, 0, 0),
                            BattleLog = new BattleLog
                            {
                                Name = "Battle of Nagashino Log",
                                BattleEvents = new List<BattleEvent>
                                {
                                    new BattleEvent { EventTime = new DateTime(1575, 6, 15, 0, 0, 0), Summary = "1001 smaurais dead", Description = "Bad" },
                                    new BattleEvent { EventTime = new DateTime(1575, 6, 17, 0, 0, 0), Summary = "3276 smaurais dead", Description = "Not good"},
                                    new BattleEvent { EventTime = new DateTime(1575, 6, 23, 0, 0, 0), Summary = "4500 smaurais dead", Description = "Betterthan before" },
                                    new BattleEvent { EventTime = new DateTime(1575, 6, 29, 0, 0, 0), Summary = "7654 dead samurais", Description = "Loss!!" },
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

        private static void AddOneSamurai(string samuraiName)
        {
            var newSamurai = new Samurai { Name = samuraiName};

            var context = new SamuraiContext();
            context.Samurais.Add(newSamurai);
            context.SaveChanges();
        }
    }
}
