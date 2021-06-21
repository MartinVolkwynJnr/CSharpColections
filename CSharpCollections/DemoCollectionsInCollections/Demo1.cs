using CSharpCollections.TestDataVaraibales;
using CSharpCollections.TestDataVaraibales.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections.DemoCollectionsInCollections
{
    class Demo1
    {
        public Dictionary<string, List<Country>> countriesPerRegion = new Dictionary<string, List<Country>>();
        private Constants constants = new Constants();

        public void readCountryCollectionRegions()
        {
            CsvReaderList csvReaderList = new CsvReaderList(constants.filePath);

            Dictionary<string, List<Country>> countries = csvReaderList.ReadAllCountriesBasedOnRegion();
            foreach (string region in countries.Keys)
                Console.WriteLine(region);

            Console.Write("Which of the above regions do you want? ");
            string chosenRegion = Console.ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                foreach (Country country in countries[chosenRegion].Take(10))
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            else
                Console.WriteLine("That is not a valid region"); 
        }
        
    }
}
