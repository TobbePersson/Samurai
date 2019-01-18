using EfSamurai.Domain;
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
    }
}
