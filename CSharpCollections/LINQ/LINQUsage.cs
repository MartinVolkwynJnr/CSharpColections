using CSharpCollections.TestDataVaraibales;
using CSharpCollections.TestDataVaraibales.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCollections.LINQ
{
    class LINQUsage
    {
        Constants constants = new Constants();

        public List<Country> readFromCSVIntoAnObjectList()
        {
            CsvReaderList reader = new CsvReaderList(constants.filePath);
            var countries = reader.ReadAllCountries();

            return countries;
        }

        public void displayTopNCountries(int takeValue, List<Country> countries)
        {
            foreach (Country country in countries.Take(takeValue))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        public void displayAndOrderByNameCountries(List<Country> countries)
        {
            foreach (Country country in countries.OrderBy(country => country.Name).Take(10))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        public void displayNoCommaCountries(int takeValue, List<Country> countries)
        {
            foreach (Country country in countries.Where(x => !x.Name.Contains(',')).Take(takeValue)) 
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        public void displayNoCommaCountriesLinqQuerySyntax(int takeValue, List<Country> countries)
        {
            var filteredCountries = countries.Where(x => !x.Name.Contains(',')).Take(takeValue);
            var filteredCountries2 = from country in countries
                                     where !country.Name.Contains(',')
                                     select country; // take is not supported in linqquery syntax

            foreach (Country country in filteredCountries2)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }
    }
}
