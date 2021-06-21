using CSharpCollections.TestDataVaraibales;
using CSharpCollections.TestDataVaraibales.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCollections.Enumeration
{
    class ForeachEnumeration
    {
        private List<Country> countries = new List<Country>();
        Constants constants = new Constants();

        public ForeachEnumeration()
        {
            readFromCSVIntoAnObjectList();
        }

        private void readFromCSVIntoAnObjectList()
        {
            CsvReaderList reader = new CsvReaderList(constants.filePath);
            countries = reader.ReadFirstNCountries();
            displayCountries();
        }

        public void displayCountries()
        {
            foreach (Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"Number of countries - {countries.Count}");


            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
