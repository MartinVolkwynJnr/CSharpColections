using CSharpCollections.TestDataVaraibales;
using CSharpCollections.TestDataVaraibales.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCollections.Collections
{
    class ArraysCollection
    {
        Constants constants = new Constants();
        public string[] daysOfWeek =
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };


        public void displayDaysOfWeek()
        {
            Console.WriteLine("Displaying the days of the week");
           
            foreach(string day in daysOfWeek)
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


        public void readFromCSVIntoAnObjectArray()
        {
            
            CsvReaderArray reader = new CsvReaderArray(constants.filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (Country country in countries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }
    }
}
