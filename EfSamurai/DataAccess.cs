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

        public List<Samurai> FindSamuraiRealName(string realName)
        {
            var secretName = context.Samurais.Include(x => x.SecretIdentity).Where(x => x.SecretIdentity.Identity == realName).ToList();
            return secretName;
        }
    }
}
