using CSharpCollections.TestDataVaraibales;
using CSharpCollections.TestDataVaraibales.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCollections.Collections
{
    class DictionariesCollection
    {
        private Dictionary<string, Country> countries = new Dictionary<string, Country>();
        Constants constants = new Constants();

        public DictionariesCollection()
        {
            
        }

        public void addDictionaryItem(Country country)
        {
            //if (!countries.ContainsKey(country.Code))
            //{
            //    countries.Add(country.Code, country);
            //}

            //displayCountries();

            bool exists = countries.TryGetValue(country.Code, out Country countryOut);

            if (exists)
            {
                Console.WriteLine("Country code alreaedy exist in dictionary");
            }
            else
            {
                countries.Add(countryOut.Code, countryOut);
            }
            displayCountries();
        }



        public void removeDictionaryItem(string key)
        {
            if (countries.TryGetValue(key, out Country country))
                countries.Remove(country.Code);
            else
                Console.WriteLine("key is not present in the dictionary");
            displayCountries();
        }


        public void readFromCSVIntoAnDictionary()
        {
            CsvReaderDictionary reader = new CsvReaderDictionary(constants.filePath);
            countries = reader.ReadCountries();
            displayCountries();
        }

        private void displayCountries()
        {
            foreach (Country country in countries.Values)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"Number of countries - {countries.Count}");


            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
