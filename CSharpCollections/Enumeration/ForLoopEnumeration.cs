using CSharpCollections.TestDataVaraibales;
using CSharpCollections.TestDataVaraibales.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCollections.Enumeration
{
    class ForLoopEnumeration
    {
        private List<Country> countries = new List<Country>();
        Constants constants = new Constants();

        public ForLoopEnumeration()
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
            Console.Write("Enter the no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int result);
            if (!inputIsInt || result <= 0)
            {
                Console.WriteLine("You must type in a +ve integer. Exiting");
                return;
            }

            ///

            int maxToDisplay = Math.Min(result, countries.Count);

            for (int i = 0; i < maxToDisplay; i++)
            {
                Country country = countries[i];
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"Number of countries - {countries.Count}");


            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }


        public void displayBatchCountries()
        {
            Console.Write("Enter the no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int result);
            if (!inputIsInt || result <= 0)
            {
                Console.WriteLine("You must type in a +ve integer. Exiting");
                return;
            }

            ///

            int maxToDisplay = result;

            for (int i = 0; i < countries.Count; i++)
            {
                if(i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }

                Country country = countries[i];
                Console.WriteLine($"{i+1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"Number of countries - {countries.Count}");


            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }


        public void displayBatchCountriesInReverse()
        {
            Console.Write("Enter the no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int result);
            if (!inputIsInt || result <= 0)
            {
                Console.WriteLine("You must type in a +ve integer. Exiting");
                return;
            }
            int maxToDisplay = result;

            for (int i = countries.Count; i >= 0; i--)
            {
                var displayindex = countries.Count - 1 - i;
                if (displayindex > 0 && (displayindex % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }

                Country country = countries[i];
                Console.WriteLine($"{displayindex + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"Number of countries - {countries.Count}");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }

        public void displayBatchCountriesRemoveAllCommaCountryNames()
        {
            Console.Write("Enter the no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int result);
            if (!inputIsInt || result <= 0)
            {
                Console.WriteLine("You must type in a +ve integer. Exiting");
                return;
            }
            int maxToDisplay = result;
            for (int i = 0; i < countries.Count; i++)
            {
                if (i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }
                Country country = countries[i];
                Console.WriteLine($"{i + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"Number of countries - {countries.Count}");
        }

    }
}
