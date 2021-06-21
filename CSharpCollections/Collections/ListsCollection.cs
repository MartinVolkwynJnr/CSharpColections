using CSharpCollections.TestDataVaraibales;
using CSharpCollections.TestDataVaraibales.Constants;
using System;
using System.Collections.Generic;

namespace CSharpCollections.Collections
{
    class ListsCollection
    {
        public List<string> daysOfWeek = new List<string>();
        public List<int> ints = new List<int>();
        private List<Country> countries = new List<Country>();
        Constants constants = new Constants();



        //{
        //    "Monday",
        //    "Tuesday",
        //    "Wednesday",
        //    "Thursday",
        //    "Friday",
        //    "Saturday",
        //    "Sunday"
        //};


        public ListsCollection()
        {
            daysOfWeek.Add("Monday");
            daysOfWeek.Add("Tuesday");
            daysOfWeek.Add("Wednesday");
            daysOfWeek.Add("Thursday");
            daysOfWeek.Add("Friday");
            daysOfWeek.Add("Saturday");
            daysOfWeek.Add("Sunday");
        }

        public void displayDaysOfWeek()
        {
            Console.WriteLine("Displaying the days of the week");



            foreach (string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }

        public void displayASpecificDayOfWeek()
        {
            Console.WriteLine("Which day do you want to display ?");
            Console.Write("(Monday = 1, etc. ) > ");
            int iDay = int.Parse(Console.ReadLine());

            string chosenDay = daysOfWeek[iDay - 1]; // -1 array is zero indexed
            Console.WriteLine($"That day is {chosenDay}");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }

        public void replaceElementByIndex(int index, string replacement)
        {
            Console.WriteLine("");
            Console.WriteLine($"Before value = {daysOfWeek[index]}");

            //actual replacement reassigning array index value to new value
            daysOfWeek[index] = replacement;

            Console.WriteLine($"Before value = {daysOfWeek[index]}");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }


        public void insertElement()
        {
            Country lilliput = new Country("Lilliput", "LIL", "Somewehere", 2_000_000);
            int lilliputIndex = countries.Count > 0 ? countries.FindIndex(country => country.Population < 2_000_000) : 0;
            countries.Insert(lilliputIndex, lilliput);
            displayCountries();
        }

        

        public void removeElement()
        {
            int lilliputIndex = countries.FindIndex(country => country.Name == "Lilliput");
            countries.RemoveAt(lilliputIndex);

            displayCountries();
        }


        public void readFromCSVIntoAnObjectList()
        {
            CsvReaderList reader = new CsvReaderList(constants.filePath);
            countries = reader.ReadFirstNCountries();
            displayCountries();
        }

        private void displayCountries()
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
