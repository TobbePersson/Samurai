using EfSamurai.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfSamurai.Data
{
    public class DataAccess
    {
        private readonly SamuraiContext context;

        public DataAccess()
        {
            context = new SamuraiContext();
        }

        public List<Samurai> NamesOfAllSamurais()
        {
            var listOfAllSamuraiNames = context.Samurais.ToList();
            return listOfAllSamuraiNames;
        }

        public List<Samurai> ListAllSamuraisOrderByName()
        {
            var listOfAllSamuraiNames = context.Samurais.OrderBy(x => x.Name).ToList();
            return listOfAllSamuraiNames;
        }

        public List<Samurai> ListAllSamuraisOrderByNameDesc()
        {
            var listOfAllSamuraiNamesDesc = context.Samurais.OrderByDescending(x => x.Id).ToList();
            return listOfAllSamuraiNamesDesc;
        }

        public List<string> ListAllQuotesOfTypeFromSamurai(string quoteType)
        {
            //var listQuoteFromSamurai = context.Samurais
            //                            .Include(x => x.Quote)
            //                            .ThenInclude(y => y.QuoteType)
            //                            .Select(x => $"{x.Quote} from {x.Name}").ToList();
            var listQuoteFromSamurai = context.Quotes
                                            .Include(x => x.QuoteType)
                                            .Include(x => x.Samurai)
                                            .Where(x => x.QuoteType.Type == quoteType)
                                            .Select(x => $"{x.SamuraiQuote} is a {quoteType} from {x.Samurai.Name}")
                                            .ToList();



            return listQuoteFromSamurai;
        }

        public List<String> ListOfBrutalBattles(DateTime dateTime1, DateTime dateTime2, bool brutalIsTrue)
        {
            var listOfBrutalBattles = context.Battles
                                            .Where(x => x.StartDate > dateTime1 && x.EndDate < dateTime2)
                                            .Select(x => (x.Brutal == brutalIsTrue) ? $"{x.BattleName} is a brutal battle" : $"{x.BattleName} is not a brutal battle")
                                            .Distinct()
                                            .ToList();
            return listOfBrutalBattles;
        }

        public List<Quote> ListAllQuotesOfTypes(string quoteType)
        {
            var allQuotesOfType = context.Quotes.Include(x => x.QuoteType).Where(x => x.QuoteType.Type == quoteType).ToList();
            return allQuotesOfType;
        }

        public List<Samurai> FindSamuraiRealName(string realName)
        {
            var secretName = context.Samurais.Include(x => x.SecretIdentity).Where(x => x.SecretIdentity.Identity == realName).ToList();
            return secretName;
        }
    }
}
